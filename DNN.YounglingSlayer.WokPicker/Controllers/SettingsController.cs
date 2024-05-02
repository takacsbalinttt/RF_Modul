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
using DotNetNuke.Entities.Modules;


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
            settings.MultiSelect = config.GetValueOrDefault("WokPicker_MultiSelect", false);
            settings.NumberOfItems = config.GetValueOrDefault("WokPicker_NumberOfItems", 1);
            settings.NumberOfSections = config.GetValueOrDefault("WokPicker_NumberOfSections", 1);

            // TESZT VÁLTOZÓ
            ViewBag.section1 = 0;



            
            for (int i = 0; i < settings.NumberOfItems; i++)
            {
                var card = new Models.Card();
                card.Bvin = config.GetValueOrDefault("WokPicker_Card" + (i + 1) + "_Bvin", string.Empty);
                card.CardId = i + 1;
                settings.cards.Add(card);
            }

            List<string> section_names = new List<string>();    
            for (int i = 0; i <= settings.NumberOfSections; i++)
            {
                string name = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("WokPicker_Section" + (i) + "_Name", string.Empty);
                section_names.Add(name);
            }

            ViewBag.section_names = section_names;

            return View(settings);
        }

        [HttpGet]
        public ActionResult Section(int sectionId)
        {
            var config = ModuleContext.Configuration.ModuleSettings;
            var section = new Models.Section();
            section.Id = sectionId;

            section.Name = config.GetValueOrDefault("WokPicker_Section" + sectionId + "_Name", "nincs");
            section.Description = config.GetValueOrDefault("WokPicker_Section" + sectionId + "_Description", "nincs");
            section.CardCount = config.GetValueOrDefault("WokPicker_Section" + sectionId + "_CardCount", 0);
            section.MultiSelect = config.GetValueOrDefault("WokPicker_Section" + sectionId + "_MultiSelect", false);
            section.Hide = config.GetValueOrDefault("WokPicker_Section" + sectionId + "_Hide", false);




            return View(section);
        }

        [HttpGet]
        public ActionResult CardSettings(int cardId, int sectionId)
        {
            var config = ModuleContext.Configuration.ModuleSettings;
            var card = new Models.Card();
            card.Section = sectionId;

            card.Bvin = config.GetValueOrDefault("WokPicker_Section" + sectionId + "_Card" + cardId  + "_Bvin", "nincs");
            card.NameOverride = config.GetValueOrDefault("WokPicker_Section" + sectionId + "_Card" + cardId + "_NameOverride", false);
            card.NameOverrideText = config.GetValueOrDefault("WokPicker_Section" + sectionId + "_Card" + cardId + "_NameOverrideText", "nincs");
            card.ImageOverride = config.GetValueOrDefault("WokPicker_Section" + sectionId + "_Card" + cardId + "_ImageOverride", false);
            card.ImageOverrideFile = config.GetValueOrDefault("WokPicker_Section" + sectionId + "_Card" + cardId + "_ImageOverrideFile", "nincs");
            card.Disable = config.GetValueOrDefault("WokPicker_Section" + sectionId + "_Card" + cardId + "_Disable", false);
            card.Spicy = config.GetValueOrDefault("WokPicker_Section" + sectionId + "_Card" + cardId + "_Spicy", false);

            return View(card);


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
            ModuleContext.Configuration.ModuleSettings["WokPicker_MultiSelect"] = settings.MultiSelect.ToString();
            ModuleContext.Configuration.ModuleSettings["WokPicker_NumberOfItems"] = settings.NumberOfItems.ToString();
            ModuleContext.Configuration.ModuleSettings["WokPicker_NumberOfSections"] = settings.NumberOfSections.ToString();
           
            for (int i = 0; i < settings.NumberOfItems; i++)
            {
                ModuleContext.Configuration.ModuleSettings["WokPicker_Card" + (i + 1) + "_Bvin"] = settings.cards[i].Bvin.ToString();
            }


            return RedirectToDefaultRoute();
        }

        [HttpPost]
        [ValidateInput(false)]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]

        public ActionResult Section(Models.Section section)
        {


            ModuleContext.Configuration.ModuleSettings["WokPicker_Section" + section.Id + "_Name"] = section.Name.ToString();
            ModuleContext.Configuration.ModuleSettings["WokPicker_Section" + section.Id + "_Description"] = section.Description.ToString();
            ModuleContext.Configuration.ModuleSettings["WokPicker_Section" + section.Id + "_CardCount"] = section.CardCount.ToString();
            ModuleContext.Configuration.ModuleSettings["WokPicker_Section" + section.Id + "_MultiSelect"] = section.MultiSelect.ToString();
            ModuleContext.Configuration.ModuleSettings["WokPicker_Section" + section.Id + "_Hide"] = section.Hide.ToString();
            

            return RedirectToAction("Settings");   
        }

        [HttpPost]
        [ValidateInput(false)]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]

        public ActionResult CardSettings(Models.Card card)
        {
            ModuleContext.Configuration.ModuleSettings["WokPicker_Section" + card.Section + "_Card" + card.CardId + "_Bvin"] = card.Bvin.ToString();
            ModuleContext.Configuration.ModuleSettings["WokPicker_Section" + card.Section + "_Card" + card.CardId + "_NameOverride"] = card.NameOverride.ToString();
            ModuleContext.Configuration.ModuleSettings["WokPicker_Section" + card.Section + "_Card" + card.CardId + "_NameOverrideText"] = card.NameOverrideText.ToString();
            ModuleContext.Configuration.ModuleSettings["WokPicker_Section" + card.Section + "_Card" + card.CardId + "_ImageOverride"] = card.ImageOverride.ToString();
            ModuleContext.Configuration.ModuleSettings["WokPicker_Section" + card.Section + "_Card" + card.CardId + "_ImageOverrideFile"] = card.ImageOverrideFile.ToString();
            ModuleContext.Configuration.ModuleSettings["WokPicker_Section" + card.Section + "_Card" + card.CardId + "_Disable"] = card.Disable.ToString();
            ModuleContext.Configuration.ModuleSettings["WokPicker_Section" + card.Section + "_Card" + card.CardId + "_Spicy"] = card.Spicy.ToString();

            return RedirectToAction("Section");
        }   




    }
}