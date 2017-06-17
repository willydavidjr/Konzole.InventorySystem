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
    public class CustomerProvider:BaseProvider,ICustomerProvider
    {
        public CustomerProvider(ApplicationDbContext context, ILoggingProvider loggingProvider)
        {
            this._db = context;
            this._loggingProvider = loggingProvider;
        }

        public Customer GetByCustomerId(int id)
        {
            Customer customer = new Customer();
            try
            {
                customer = _db.Customers.Find(id);
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to get a customer by ID: {0}", id));
            }

            if (customer == null)
            {
                customer = new Customer();
            }
            return customer;
        }

        public List<Customer> GetList()
        {
            List<Customer> customerList = null;

            try
            {
                customerList = (from customer in _db.Customers
                              select customer).ToList();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, "Failed to get a customer list");
            }

            if (customerList == null)
            {
                customerList = new List<Customer>();
            }

            return customerList;
        }

        public bool RemoveById(int id)
        {
            int returnvalue = 0;

            Customer customer = _db.Customers.Find(id);
            try
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to remove a customer - ID: {0}", customer.Id));
            }
            return (returnvalue > 0);
        }
        
        public bool Save(Customer customer)
        {
            int returnvalue = 0;

            try
            {
                if (customer.Id == 0)
                {
                    _db.Customers.Add(customer);
                }
                else
                {
                    _db.Entry(customer).State = EntityState.Modified;
                }
                returnvalue = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to save a customer - ID: {0}", customer.Id));
            }
            return (returnvalue > 0);
        }
    }
}
