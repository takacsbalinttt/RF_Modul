/*
' Copyright (c) 2024 YounglingSlayer
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Collections;
using DotNetNuke.Security;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System.Web.Mvc;

namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Controllers
{
    [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Edit)]
    [DnnHandleError]
    public class SettingsController : DnnController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Settings()
        {
            var settings = new Models.Settings();
            settings.MultiSelect = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_MultiSelect", true);
            settings.Setting2 = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_Setting2", System.DateTime.Now);
            settings.ItemID1 = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_ItemID1", "teszt");
            settings.ItemName1 = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_ItemName1", "Név1");
            settings.ItemImagePath1 = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_ItemImagePath1", "Kép útvonala");

            return View(settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supportsTokens"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Settings(Models.Settings settings)
        {
            ModuleContext.Configuration.ModuleSettings["DNN.YounglingSlayer.WokPicker_MultiSelect"] = settings.MultiSelect.ToString();
            ModuleContext.Configuration.ModuleSettings["DNN.YounglingSlayer.WokPicker_Setting2"] = settings.Setting2.ToUniversalTime().ToString("u");
            ModuleContext.Configuration.ModuleSettings["DNN.YounglingSlayer.WokPicker_ItemID1"] = settings.ItemID1.ToString();
            ModuleContext.Configuration.ModuleSettings["DNN.YounglingSlayer.WokPicker_ItemName1"] = settings.ItemName1.ToString();
            ModuleContext.Configuration.ModuleSettings["DNN.YounglingSlayer.WokPicker_ItemImagePath1"] = settings.ItemImagePath1.ToString();

            return RedirectToDefaultRoute();
        }
    }
}