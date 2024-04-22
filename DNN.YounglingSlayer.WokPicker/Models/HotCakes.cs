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

using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Web.Caching;

namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models
{
    [TableName("hcc_Product")]
    //setup the primary key for table
    [PrimaryKey("bvin")]
    //configure caching using PetaPoco
    [Cacheable("HotCakes", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class HotCakes
    {
        ///<summary>
        /// The ID of your object with the name of the ItemName
        ///</summary>
        public string bvin { get; set; }

        
        //public string Name { get; set; }

        public string SKU { get; set; }

        /// <summary>
        /// Is it on stock?
        /// </summary>
        public bool OutOfStockMode { get; set; }
        

        public int StoreID { get; set; }
 


        /// <summary>
        /// The name of the image file
        /// </summary>
        public string ImageFileSmall { get; set; }


    }
}
