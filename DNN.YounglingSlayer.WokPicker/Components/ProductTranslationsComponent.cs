using DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Emit;


namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Components
{
    
    internal interface IProductTranslationsManager
    {
        IEnumerable<ProductTranslations> ReadProductTranslations();
        IEnumerable<ProductTranslations> SearchProductID(string ProductID);

        ProductTranslations GetByProductTranslationId(int ProductTranslationId);

        string TranslateNameByProductID(string ProductID, string Culture);
        
    }

    internal class ProductTranslationsManager : ServiceLocator<IProductTranslationsManager, ProductTranslationsManager>, IProductTranslationsManager
    {
        public IEnumerable<ProductTranslations> ReadProductTranslations()
        {
            /// READ PRODUCT TRANSLATIONS!!!!
            ///            
            IEnumerable<ProductTranslations> products;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ProductTranslations>();
                products = rep.Get();
            }
            
            return products;
        }
        
        public  IEnumerable<ProductTranslations> SearchProductID(string ProductID)
        {
            ProductID = ProductID.Trim().ToLower();
            IEnumerable<ProductTranslations> product;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ProductTranslations>();
                product = rep.Find("WHERE ProductID = @0", ProductID);
            }
            return product;
        }

        public ProductTranslations GetByProductTranslationId(int ProductTranslationId)
        {
            ProductTranslations product;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ProductTranslations>();
                product = rep.GetById(ProductTranslationId);
            }
            return product;
        }

        public string TranslateNameByProductID(string ProductID, string Culture)
        {
            ProductID = ProductID.Trim().ToLower();
            Culture = Culture.Trim().ToLower();
            string productName = "";
            IEnumerable<ProductTranslations> product;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ProductTranslations>();
                product = rep.Find("WHERE ProductID = @0 AND Culture = @1", ProductID, Culture);
            }
            foreach (var p in product)
            {
                productName = p.ProductName;
            }
            return productName;
        }




        protected override System.Func<IProductTranslationsManager> GetFactory()
        {
            return () => new ProductTranslationsManager();
        }

    }
}