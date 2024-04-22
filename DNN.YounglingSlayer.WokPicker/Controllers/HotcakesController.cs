using DNN.WokPickerDNN.YounglingSlayer.WokPicker.Components;
using DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;


namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Controllers
{



    [DnnHandleError]
    public class HotcakesController : DnnController
    {
        public string selected_bvin = "asd";
        [ModuleAction]
        public ActionResult Index()
        {
            var items = HotCakesManager.Instance.ReadHotCakes();
            return View(items);
        }
        public ActionResult FindBVIN(string bvin)
        {
            var items = HotCakesManager.Instance.GetBybvin(bvin);
            return View(items);
        }

    }
}