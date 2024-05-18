﻿using DNN.WokPickerDNN.YounglingSlayer.WokPicker.Components;
using DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models;
using DotNetNuke.Collections;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using Hotcakes.Commerce;
using Hotcakes.Commerce.Catalog;
using Hotcakes.Commerce.Extensions;
using Hotcakes.Commerce.Orders;
using Hotcakes.Commerce.Urls;
using Hotcakes.Modules;
using Hotcakes.Web;
using System.Reflection;


namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Controllers
{

    [DnnHandleError]
    public class HotcakesController : DnnController
    {


        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }


        [HttpGet]
        public ActionResult WokPicker()
        {

            var settings = this.ActiveModule.ModuleSettings;

            if (settings.Count == 0)
            {
                return View("NoSettings");
            }
            /*
            var items = HotCakesManager.Instance.ReadHotCakes();
            var bvin1 = settings.GetValue<string>("WokPicker_Bvin1").ToLower();

            ViewBag.items = FindBVIN(bvin1);
            ViewBag.ProductName = ProductTranslationsManager.Instance.TranslateNameByProductID(bvin1, "en-US");
            */
            var numberOfSections = settings.GetValueOrDefault<int>("WokPicker_NumberOfSections", 1);
            ViewBag.numberOfSections = numberOfSections;

            List<Section> sections = new List<Section>();
            //System.Diagnostics.Debugger.Launch();

            for (int i = 0; i < numberOfSections; i++)
            {
                sections.Add(MakeSection(i));
            }


            return View(sections);
        }   






        Section MakeSection(int sectionId)
        {
            var settings = this.ActiveModule.ModuleSettings;
            var setting_key = "WokPicker_Section" + sectionId + "_";
            Section section = new Section();


            section.Id = sectionId;
            section.Name = settings.GetValueOrDefault<string>(setting_key + "Name",string.Empty);
            section.Description = settings.GetValueOrDefault<string>(setting_key + "Description",string.Empty);
            section.CardCount = settings.GetValueOrDefault<int>(setting_key + "CardCount",0);
            section.MultiSelect = settings.GetValueOrDefault<bool>(setting_key + "MultiSelect",false);
            section.Hide = settings.GetValueOrDefault<bool>(setting_key + "Hide",false);
            section.PropertyName = settings.GetValueOrDefault<string>(setting_key + "PropertyName",string.Empty);

            for (int i = 0; i < section.CardCount; i++)
            {
                section.Cards.Add(MakeCard(sectionId, i));
            }
            return section;
        }

        Card MakeCard(int sectionId, int cardId)
        {
            var settings = this.ActiveModule.ModuleSettings;
            var setting_key = "WokPicker_Section" + sectionId + "_Card" + cardId + "_";
            var culture = ("en-US");
            Card card = new Card();
            card.Section = sectionId;

            try
            {
                card.Item = FindBVIN(settings.GetValue<string>(setting_key + "Bvin").ToLower());
            }
            catch 
            {
                card.Item = null;
            }
            if (card.Item == null)
            {
                card.ItemMissing = true;
                return card;
            }
            else
            {
                var product_folder = @"\Portals\0\Hotcakes\Data\products\" + card.Item.bvin + @"\";
                var override_folder = @"\Portals\0\WokPicker\img\";
                card.Bvin = card.Item.bvin;
                card.NameOverride = settings.GetValueOrDefault<bool>(setting_key + "NameOverride", false);
                card.NameOverrideText = settings.GetValueOrDefault<string>(setting_key + "NameOverrideText", string.Empty);
                card.ImageOverride = settings.GetValueOrDefault<bool>(setting_key + "ImageOverride", false);
                card.ImageOverrideFile = settings.GetValueOrDefault<string>(setting_key + "ImageOverrideFile", string.Empty);
                card.Disable = settings.GetValueOrDefault<bool>(setting_key + "Disable", false);
                card.Spicy = settings.GetValueOrDefault<bool>(setting_key + "Spicy", false);
                card.TranslatedName = ProductTranslationsManager.Instance.TranslateNameByProductID(card.Bvin, culture);
                card.Stock = ProductInventoryManager.Instance.GetProductInventory(card.Bvin);
                card.IsInStock = ProductInventoryManager.Instance.ProductIsInStock(card.Bvin);
                card.LowStockMode = ProductInventoryManager.Instance.ProductLowStock(card.Bvin);

                if (card.ImageOverride)
                {

                    card.Item.ImageFileSmall = override_folder + card.ImageOverrideFile;
                }
                else
                {
                    card.Item.ImageFileSmall = product_folder + card.Item.ImageFileSmall;
                }
                if (card.IsInStock == false)
                {
                    card.Disable = true;
                }

                return card;

            }
        }

        HotCakes FindBVIN(string bvin)
        {
                var item = HotCakesManager.Instance.GetBybvin(bvin);
                return item;

        }


        [HttpPost]
        [ValidateInput(false)]

        public ActionResult WokPicker(IEnumerable<Section> Sections)
        {


            var settings = this.ActiveModule.ModuleSettings;
            var hccApp = HotcakesApplication.Current;
            string helperSku = settings.GetValueOrDefault("WokPicker_HelperSKU", "1000");
            float finalPrice = 0;

            Order cart = hccApp.OrderServices.EnsureShoppingCart();
            
            var customProduct = hccApp.CatalogServices.Products.FindBySku(helperSku);

            if (helperSku == null || customProduct == null)
            {
                return View("NoSettings");
            }

            List<Card> selected = new List<Card>();

            foreach (var section in Sections)
            {
                if (section.Cards != null)
                {
                        foreach (var card in section.Cards)
                        {
                            if (card.Selected)
                            {
                                BundledProductAdv subProduct = new BundledProductAdv(); 
                                selected.Add(card);                                
                                Product product = hccApp.CatalogServices.Products.FindBySku(card.Item.SKU.Trim());
                                product.ProductName = card.TranslatedName;
                                subProduct.BundledProduct = product;
                                subProduct.Quantity = 1;
                                customProduct.BundledProducts.Add(subProduct);
                                finalPrice += card.Item.SitePrice;
                            }
                        }

                }
            }


            LineItem finalProduct = customProduct.ConvertToLineItem(hccApp, 1, new OptionSelections(), Convert.ToDecimal(finalPrice));



            hccApp.AddToOrderWithCalculateAndSave(cart, finalProduct);

            return View("Finish",selected);
        }






    }



}
