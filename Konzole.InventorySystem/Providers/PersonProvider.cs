using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konzole.InventorySystem.Providers.Interface;
using Konzole.InventorySystem.Web.Models;

namespace Konzole.InventorySystem.Providers
{
    public class PersonProvider:BaseProvider,IPersonProvider
    {
        public PersonProvider(ApplicationDbContext context, ILoggingProvider loggingProvider)
        {
            this._db = context;
            this._loggingProvider = loggingProvider;
        }

        public Person GetByPersonId(int personId)
        {
            Person person = null;

            try
            {
                person = _db.Persons.Find(personId);

            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to get a person by ID: {0}", personId));
            }

            if (person == null)
            {
                person = new Person();
            }

            return person;
        }

        public Person GetByUserId(Guid userId)
        {
            Person person = null;

            try
            {
                person = _db.Persons.FirstOrDefault(x => x.UserId == userId);

            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to get a person by userID: {0}", userId));
            }

            if (person == null)
            {
                person = new Person();
            }

            return person;
        }

        public List<Person> GetList()
        {
            List<Person> personList = null;

            try
            {
                personList = (from person in _db.Persons
                              select person).ToList();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, "Failed to get a person list");
            }

            if (personList == null)
            {
                personList = new List<Person>();
            }

            return personList;
        }

        public bool Add(Person person)
        {
            int returnvalue = 0;

            try
            {
                if (person.UserId == Guid.Empty)
                {
                    return false;
                }

                _db.Persons.Add(person);
                returnvalue = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to save a person by ID: {0}", person.UserId));
            }

            return (returnvalue > 0);
        }

        public bool Save(Person person)
        {
            int returnvalue = 0;

            try
            {
                _db.Entry(person).State = EntityState.Modified;
                returnvalue = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to save a person by ID: {0}", person.UserId));
            }

            return (returnvalue > 0);
        }
    }
}
