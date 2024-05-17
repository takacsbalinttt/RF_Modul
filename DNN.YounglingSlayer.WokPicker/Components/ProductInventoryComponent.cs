using DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Emit;


namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Components
{
    
    internal interface IProductInventoryManager
    {
        int GetProductInventory(string bvin);

        bool ProductIsInStock(string bvin);

        bool ProductLowStock(string bvin);

        ProductInventory GetProductInventoryDetails(string bvin);

        
        
    }

    internal class ProductInventoryManager : ServiceLocator<IProductInventoryManager, ProductInventoryManager>, IProductInventoryManager
    {


        public int GetProductInventory(string bvin)
        {
            bvin = bvin.Trim().ToLower();
            ProductInventory product;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ProductInventory>();
                product = rep.Find("WHERE ProductBvin = @0", bvin).First();
            }
            return product.QuantityAvailableForSale;
        }

        public ProductInventory GetProductInventoryDetails(string bvin)
        {
            bvin = bvin.Trim().ToLower();
            ProductInventory product;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ProductInventory>();
                product = rep.Find("WHERE ProductBvin = @0", bvin).First();
            }
            return product;
        }


        public bool ProductIsInStock(string bvin)
        {
            bvin = bvin.Trim().ToLower();
            ProductInventory product;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ProductInventory>();
                product = rep.Find("WHERE ProductBvin = @0", bvin).First();
            }
            if (product.QuantityAvailableForSale <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ProductLowStock(string bvin)
        {
            bvin = bvin.Trim().ToLower();
            ProductInventory product;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ProductInventory>();
                product = rep.Find("WHERE ProductBvin = @0", bvin).First();
            }
            if (product.QuantityAvailableForSale <= product.LowStockPoint)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        protected override System.Func<IProductInventoryManager> GetFactory()
        {
            return () => new ProductInventoryManager();
        }

    }
}