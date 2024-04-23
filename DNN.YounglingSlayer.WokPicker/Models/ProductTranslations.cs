
using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Web.Caching;

namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models
{
    [TableName("hcc_ProductTranslations")]
    //setup the primary key for table
    [PrimaryKey("ProductTranslationId")]
    //configure caching using PetaPoco
    [Cacheable("ProductTranslations", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class ProductTranslations
    {
        public int ProductTranslationId { get; set; }
        
        /// <summary>
        /// BVIN
        /// </summary>
        public string ProductID { get; set; }

        public string Culture { get; set; }
        public string ProductName { get; set; }

        public string MetaTitle { get; set; }
    }
}