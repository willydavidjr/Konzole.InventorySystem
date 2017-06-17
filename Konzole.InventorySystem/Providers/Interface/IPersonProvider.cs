using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Providers.Interface
{
    public interface IPersonProvider
    {
        Person GetByPersonId(int personId);
        List<Person> GetList();
        bool Add(Person person);
        bool Save(Person person);
        Person GetByUserId(Guid userId);
    }
}
