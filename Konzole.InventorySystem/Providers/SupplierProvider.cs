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
   
    public class SupplierProvider : BaseProvider, ISupllierProvider
    {
        public SupplierProvider(ApplicationDbContext context, ILoggingProvider loggingProvider)
        {
            this._db = context;
            this._loggingProvider = loggingProvider;
        }

        public Supplier GetBySupplierId(int id)
        {
            Supplier customer = new Supplier();
            try
            {
                customer = _db.Suppliers.Find(id);
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to get a supplier by ID: {0}", id));
            }

            if (customer == null)
            {
                customer = new Supplier();
            }
            return customer;
        }

        public List<Supplier> GetList()
        {
            List<Supplier> supplierList = null;

            try
            {
                supplierList = (from supplier in _db.Suppliers
                                select supplier).ToList();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, "Failed to get a customer list");
            }

            if (supplierList == null)
            {
                supplierList = new List<Supplier>();
            }

            return supplierList;
        }

        public bool RemoveById(int id)
        {
            int returnvalue = 0;

            Supplier supplier = _db.Suppliers.Find(id);
            try
            {
                _db.Suppliers.Remove(supplier);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to remove a customer - ID: {0}", supplier.Id));
            }
            return (returnvalue > 0);
        }

        public bool Save(Supplier supplier)
        {
            int returnvalue = 0;

            try
            {
                if (supplier.Id == 0)
                {
                    _db.Suppliers.Add(supplier);
                }
                else
                {
                    _db.Entry(supplier).State = EntityState.Modified;
                }
                returnvalue = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to save a customer - ID: {0}", supplier.Id));
            }
            return (returnvalue > 0);
        }
    }
}
