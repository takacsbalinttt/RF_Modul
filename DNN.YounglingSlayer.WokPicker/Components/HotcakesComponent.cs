
using DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;


namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Components
{
    internal interface IHotCakesManager
    {
        IEnumerable<Item> ReadHotCakes(string HCID);
        
    }

    internal class HotCakesManager : ServiceLocator<IHotCakesManager, HotCakesManager>, IHotCakesManager
    {
        public IEnumerable<Item> ReadHotCakes(string HCID)
        {
            /// READ HOTCAKES PRODUCTS!!!!
            
            IEnumerable<Item> product;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                product = rep.Get(HCID);
            }
            
            
            return null;
        }

        protected override System.Func<IHotCakesManager> GetFactory()
        {
            return () => new HotCakesManager();
        }

    }

}