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
using System.Collections.Generic;


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
            var config = ModuleContext.Configuration.ModuleSettings;

            var settings = new Models.Settings();
            var card1 = new Models.Card();
            settings.MultiSelect = config.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_MultiSelect", false);
            settings.Bvin1 = config.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_Bvin1", string.Empty);
            settings.NumberOfItems = config.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_NumberOfItems", 1);


            ViewBag.section1 = 1;








            
            for (int i = 0; i < settings.NumberOfItems; i++)
            {
                var card = new Models.Card();
                card.Bvin = config.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_Card" + (i + 1) + "_Bvin", string.Empty);
                card.CardId = i + 1;
                settings.cards.Add(card);
            }

            return View(settings);
        }

        public ActionResult Section(int sectionId)
        {
            var config = ModuleContext.Configuration.ModuleSettings;
            var section = new Models.Section();

            section.Name = config.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_Section" + sectionId + "_Name", string.Empty);
            section.Description = config.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_Section" + sectionId + "_Description", string.Empty);
            section.CardCount = config.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_Section" + sectionId + "_CardCount", 1);
            section.MultiSelect = config.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_Section" + sectionId + "_MultiSelect", false);
            section.Hide = config.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_Section" + sectionId + "_Hide", false);






            return View(section);
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
            var config = ModuleContext.Configuration.ModuleSettings;

            config["DNN.YounglingSlayer.WokPicker_MultiSelect"] = settings.MultiSelect.ToString();
            config["DNN.YounglingSlayer.WokPicker_Bvin1"] = settings.Bvin1.ToString();
            config["DNN.YounglingSlayer.WokPicker_NumberOfItems"] = settings.NumberOfItems.ToString();

            for (int i = 0; i < settings.NumberOfItems; i++)
            {
                config["DNN.YounglingSlayer.WokPicker_Card" + (i + 1) + "_Bvin"] = settings.cards[i].Bvin.ToString();
            }

            return RedirectToDefaultRoute();
        }

        [HttpPost]
        [ValidateInput(false)]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]

        public ActionResult Section(Models.Section section)
        {
            var config = ModuleContext.Configuration.ModuleSettings;

            config["DNN.YounglingSlayer.WokPicker_Section" + section.Id + "_Name"] = section.Name.ToString();
            config["DNN.YounglingSlayer.WokPicker_Section" + section.Id + "_Description"] = section.Description.ToString();
            config["DNN.YounglingSlayer.WokPicker_Section" + section.Id + "_CardCount"] = section.CardCount.ToString();
            config["DNN.YounglingSlayer.WokPicker_Section" + section.Id + "_MultiSelect"] = section.MultiSelect.ToString();
            config["DNN.YounglingSlayer.WokPicker_Section" + section.Id + "_Hide"] = section.Hide.ToString();

            return RedirectToDefaultRoute();
        }





    }
}