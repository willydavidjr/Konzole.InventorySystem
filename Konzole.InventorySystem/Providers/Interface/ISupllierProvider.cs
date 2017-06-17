using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Providers.Interface
{


    public interface ISupllierProvider
    {
        Supplier GetBySupplierId(int supplierId);
        List<Supplier> GetList();
        bool Save(Supplier supplier);
        bool RemoveById(int id);
    }
}
