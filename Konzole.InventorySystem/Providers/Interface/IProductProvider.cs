using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Providers.Interface
{
    public interface IProductProvider
    {
        Product GetByProductId(int productId);
        List<Product> GetList(int productId);
        bool Save(Product product);
    }
}
