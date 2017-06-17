using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konzole.InventorySystem.Web.Models;

namespace Konzole.InventorySystem.Providers.Interface
{
    public class ProductProvider:BaseProvider,IProductProvider
    {
        public ProductProvider(ApplicationDbContext context, ILoggingProvider loggingProvider)
        {
            this._db = context;
            this._loggingProvider = loggingProvider;
        }

        public Product GetByProductId(int id)
        {
            Product product = new Product();
            try
            {
                product = _db.Products.Find(id);
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to get a product by ID: {0}", id));
            }

            if (product == null)
            {
                product = new Product();
            }
            return product;
        }

        public List<Product> GetList(int productId)
        {
            List<Product> productList = new List<Product>();

            try
            {
                productList = (from product in _db.Products
                                where product.Id == productId || productId == 0
                                select product).ToList();
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to get a product list by product ID: {0}", productId));
            }

            if (productList == null)
            {
                productList = new List<Product>();
            }

            return productList;
        }

        public bool Save(Product product)
        {
            int returnvalue = 0;

            try
            {
                if (product.Id == 0)
                {
                    _db.Products.Add(product);
                }
                else
                {
                    _db.Entry(product).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _loggingProvider.LogError(ex, string.Format("Failed to save a game - ID: {0}", product.Id));
            }
            return (returnvalue > 0);
        }

    }
}
