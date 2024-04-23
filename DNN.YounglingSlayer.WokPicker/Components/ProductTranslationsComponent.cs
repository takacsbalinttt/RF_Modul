using DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using System.Dynamic;


namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Components
{
    
    internal interface IProductTranslationsManager
    {
        IEnumerable<ProductTranslations> ReadProductTranslations();
        IEnumerable<ProductTranslations> SearchProductID(string ProductID);

        ProductTranslations GetByProductTranslationId(int ProductTranslationId);
        
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


        protected override System.Func<IProductTranslationsManager> GetFactory()
        {
            return () => new ProductTranslationsManager();
        }

    }
}