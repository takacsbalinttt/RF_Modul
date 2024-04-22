
using DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;


namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Components
{
    internal interface IHotCakesManager
    {
        IEnumerable<HotCakes> ReadHotCakes();
        IEnumerable<HotCakes> SearchSKU(string SKU);
        
    }

    internal class HotCakesManager : ServiceLocator<IHotCakesManager, HotCakesManager>, IHotCakesManager
    {
        public IEnumerable<HotCakes> ReadHotCakes()
        {
            /// READ HOTCAKES PRODUCTS!!!!
            
            IEnumerable<HotCakes> products;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<HotCakes>();
                products = rep.Get();
            }
            
            
            return products;
        }

        public IEnumerable<HotCakes> SearchSKU(string SKU)
        {
            IEnumerable<HotCakes> products;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<HotCakes>();
                products = rep.Find("WHERE SKU = @0", SKU);
            }
            return products;
        }

        protected override System.Func<IHotCakesManager> GetFactory()
        {
            return () => new HotCakesManager();
        }

    }

}