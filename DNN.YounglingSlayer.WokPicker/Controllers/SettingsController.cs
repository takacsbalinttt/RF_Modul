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
            var card1 = new Models.Card();
            settings.MultiSelect = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_MultiSelect", false);
            settings.Bvin1 = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_Bvin1", string.Empty);
            settings.NumberOfItems = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_NumberOfItems", 1);
            
            for (int i = 0; i < settings.NumberOfItems; i++)
            {
                var card = new Models.Card();
                card.Bvin = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("DNN.YounglingSlayer.WokPicker_Card" + (i + 1) + "_Bvin", string.Empty);
                card.CardId = i + 1;
                settings.cards.Add(card);
            }

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
            ModuleContext.Configuration.ModuleSettings["DNN.YounglingSlayer.WokPicker_Bvin1"] = settings.Bvin1.ToString();
            ModuleContext.Configuration.ModuleSettings["DNN.YounglingSlayer.WokPicker_NumberOfItems"] = settings.NumberOfItems.ToString();

            for (int i = 0; i < settings.NumberOfItems; i++)
            {
                ModuleContext.Configuration.ModuleSettings["DNN.YounglingSlayer.WokPicker_Card" + (i + 1) + "_Bvin"] = settings.cards[i].Bvin.ToString();
            }

            return RedirectToDefaultRoute();
        }
    }
}