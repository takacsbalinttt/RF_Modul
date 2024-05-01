using DNN.WokPickerDNN.YounglingSlayer.WokPicker.Components;
using DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models;
using DotNetNuke.Collections;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Web.Mvc;


namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Controllers
{

    [DnnHandleError]
    public class HotcakesController : DnnController
    {

        [ModuleAction]
        public ActionResult Index()
        {
            var settings = this.ActiveModule.ModuleSettings;

            if(settings.Count == 0)
            {
                return View("NoSettings");
            }
            var items = HotCakesManager.Instance.ReadHotCakes();
            var bvin1 = settings.GetValue<string>("DNN.YounglingSlayer.WokPicker_Bvin1").ToLower();

            ViewBag.items = FindBVIN(bvin1);
            ViewBag.ProductName = ProductTranslationsManager.Instance.TranslateNameByProductID(bvin1, "en-US");
            return View(items);
        
        
        
        
        }



        Section MakeSection(int sectionId)
        {
            var settings = this.ActiveModule.ModuleSettings;
            var setting_key = "DNN.YounglingSlayer.WokPicker_Section" + sectionId + "_";
            Section section = new Section();


            section.Id = sectionId;
            section.Name = settings.GetValue<string>(setting_key + "Name");
            section.Description = settings.GetValue<string>(setting_key + "Description");
            section.CardCount = settings.GetValue<int>(setting_key + "CardCount");
            section.MultiSelect = settings.GetValue<bool>(setting_key + "MultiSelect");
            section.Hide = settings.GetValue<bool>(setting_key + "Hide");

            for (int i = 0; i < section.CardCount; i++)
            {
                section.Cards.Add(MakeCard(sectionId, i));
            }
            return section;
        }

        Card MakeCard(int sectionId, int cardId)
        {
            var settings = this.ActiveModule.ModuleSettings;
            var setting_key = "DNN.YounglingSlayer.WokPicker_Section" + sectionId + "_Card" + cardId + "_";
            Card card = new Card();

            card.Item = FindBVIN(settings.GetValue<string>(setting_key + "Bvin"));
            if (card.Item == null)
            {
                card.Bvin = "missing";
                return card;
            }
            else
            {
                card.CardId = cardId;
                card.Section = sectionId;
                card.Bvin = card.Item.bvin;
                card.NameOverride = settings.GetValue<bool>(setting_key + "NameOverride");
                card.NameOverrideText = settings.GetValue<string>(setting_key + "NameOverrideText");
                card.ImageOverride = settings.GetValue<bool>(setting_key + "ImageOverride");
                card.ImageOverrideFile = settings.GetValue<string>(setting_key + "ImageOverrideFile");
                card.Disable = settings.GetValue<bool>(setting_key + "Disable");
                card.Spicy = settings.GetValue<bool>(setting_key + "Spicy");
                return card;

            }
        }

        HotCakes FindBVIN(string bvin)
        {
            var item = HotCakesManager.Instance.GetBybvin(bvin);
            
            return item;
        }



    }






}
