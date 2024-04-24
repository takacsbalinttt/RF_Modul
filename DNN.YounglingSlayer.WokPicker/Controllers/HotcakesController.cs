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
            /*
            if(ModuleContext.Settings.ContainsKey("WokPicker_Bvin1"))
            {
                bvin = ModuleContext.Settings["Bvin1"].ToString();
            }

            */
            ViewBag.items = FindBVIN(bvin1);
            return View(items);
        }
        HotCakes FindBVIN(string bvin)
        {
            var items = HotCakesManager.Instance.GetBybvin(bvin);
            
            return items;
        }



    }
}