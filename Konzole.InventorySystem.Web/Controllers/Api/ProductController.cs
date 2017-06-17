using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Konzole.InventorySystem.Providers.Interface;

namespace Konzole.InventorySystem.Web.Controllers.Api
{
    public class ProductController : ApiController
    {
        IProductProvider _productprovider = null;
        public ProductController(IProductProvider productProvider)
        {
            this._productprovider = productProvider;
        }

        public HttpResponseMessage GetList(int productId = 0)
        {
            return this.BuildResponse(HttpStatusCode.OK, _productprovider.GetList(productId));
        }

        public HttpResponseMessage Get(int id)
        {
            return this.BuildResponse(HttpStatusCode.OK, _productprovider.GetByProductId(id));
        }

        public HttpResponseMessage Post(Product product)
        {
            if (_productprovider.Save(product))
            {
                var locationHeaderValue = "/api/Product/" + product.Id;
                return this.BuildResponse(HttpStatusCode.Created, product, locationHeaderValue);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        public HttpResponseMessage Put(Product product)
        {
            if (_productprovider.Save(product))
            {
                return this.BuildResponse(HttpStatusCode.OK, product);
            }

            return this.BuildResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Delete(int id)
        {
            Product product = _productprovider.GetByProductId(id);
            //customer.SetIsActivate(false);

            if (_productprovider.Save(product))
            {
                return this.BuildResponse(HttpStatusCode.OK, product);
            }

            return this.BuildResponse(HttpStatusCode.NotFound);
        }
    }
}
