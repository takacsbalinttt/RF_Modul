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

//using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;
using System.Collections.Generic;

namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Components
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for DNN.YounglingSlayer.WokPicker
    /// 
    /// The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    /// DotNetNuke will poll this class to find out which Interfaces the class implements. 
    /// 
    /// The IPortable interface is used to import/export content from a DNN module
    /// 
    /// The ISearchable interface is used by DNN to index the content of a module
    /// 
    /// The IUpgradeable interface allows module developers to execute code during the upgrade 
    /// process for a module.
    /// 
    /// Below you will find stubbed out implementations of each, uncomment and populate with your own data
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController //: IPortable, ISearchable, IUpgradeable
    {


        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        //public string ExportModule(int ModuleID)
        //{
        //string strXML = "";

        //List<DNN.YounglingSlayer.WokPickerInfo> colDNN.YounglingSlayer.WokPickers = GetDNN.YounglingSlayer.WokPickers(ModuleID);
        //if (colDNN.YounglingSlayer.WokPickers.Count != 0)
        //{
        //    strXML += "<DNN.YounglingSlayer.WokPickers>";

        //    foreach (DNN.YounglingSlayer.WokPickerInfo objDNN.YounglingSlayer.WokPicker in colDNN.YounglingSlayer.WokPickers)
        //    {
        //        strXML += "<DNN.YounglingSlayer.WokPicker>";
        //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objDNN.YounglingSlayer.WokPicker.Content) + "</content>";
        //        strXML += "</DNN.YounglingSlayer.WokPicker>";
        //    }
        //    strXML += "</DNN.YounglingSlayer.WokPickers>";
        //}

        //return strXML;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        //public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        //{
        //XmlNode xmlDNN.YounglingSlayer.WokPickers = DotNetNuke.Common.Globals.GetContent(Content, "DNN.YounglingSlayer.WokPickers");
        //foreach (XmlNode xmlDNN.YounglingSlayer.WokPicker in xmlDNN.YounglingSlayer.WokPickers.SelectNodes("DNN.YounglingSlayer.WokPicker"))
        //{
        //    DNN.YounglingSlayer.WokPickerInfo objDNN.YounglingSlayer.WokPicker = new DNN.YounglingSlayer.WokPickerInfo();
        //    objDNN.YounglingSlayer.WokPicker.ModuleId = ModuleID;
        //    objDNN.YounglingSlayer.WokPicker.Content = xmlDNN.YounglingSlayer.WokPicker.SelectSingleNode("content").InnerText;
        //    objDNN.YounglingSlayer.WokPicker.CreatedByUser = UserID;
        //    AddDNN.YounglingSlayer.WokPicker(objDNN.YounglingSlayer.WokPicker);
        //}

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        //{
        //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

        //List<DNN.YounglingSlayer.WokPickerInfo> colDNN.YounglingSlayer.WokPickers = GetDNN.YounglingSlayer.WokPickers(ModInfo.ModuleID);

        //foreach (DNN.YounglingSlayer.WokPickerInfo objDNN.YounglingSlayer.WokPicker in colDNN.YounglingSlayer.WokPickers)
        //{
        //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objDNN.YounglingSlayer.WokPicker.Content, objDNN.YounglingSlayer.WokPicker.CreatedByUser, objDNN.YounglingSlayer.WokPicker.CreatedDate, ModInfo.ModuleID, objDNN.YounglingSlayer.WokPicker.ItemId.ToString(), objDNN.YounglingSlayer.WokPicker.Content, "ItemId=" + objDNN.YounglingSlayer.WokPicker.ItemId.ToString());
        //    SearchItemCollection.Add(SearchItem);
        //}

        //return SearchItemCollection;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        //public string UpgradeModule(string Version)
        //{
        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        #endregion

    }

}
