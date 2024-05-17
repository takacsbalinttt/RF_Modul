
using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Web.Caching;

namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models
{
    [TableName("hcc_ProductInventory")]
    //setup the primary key for table
    [PrimaryKey("bvin")]
    //configure caching using PetaPoco
    [Cacheable("ProductInventory", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class ProductInventory
    {
        /// <summary>
        /// ONLY PRIMARY KEY!!!!
        /// </summary>
        public string bvin { get; set; }

        
        public string VariantId { get; set; }

        public int QuantityOnHand { get; set; }
        public int QuantityAvailableForSale { get; set; }

        public int QuantityReserved { get; set; }

        public int LowStockPoint { get; set; }

        public int StoreId { get; set; }    
    }
}