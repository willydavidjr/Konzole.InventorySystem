using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Providers.Interface
{
    public interface ICustomerProvider
    {
        Customer GetByCustomerId(int customerId);
        List<Customer> GetList();
        bool Save(Customer customer);
        bool RemoveById(int id);
    }
}
