using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Konzole.InventorySystem.Providers.Interface;

namespace Konzole.InventorySystem.Web.Controllers.Api
{
    public class SupplierController : ApiController
    {
        ISupllierProvider _supplierprovider = null;

        public SupplierController(ISupllierProvider _supplierProvider)
        {
            this._supplierprovider = _supplierProvider;
        }

        public HttpResponseMessage GetList()
        {
            return this.BuildResponse(HttpStatusCode.OK, _supplierprovider.GetList());
        }

        public HttpResponseMessage Get(int id)
        {
            return this.BuildResponse(HttpStatusCode.OK, _supplierprovider.GetBySupplierId(id));
        }

        public HttpResponseMessage Post(Supplier supplier)
        {
            if (_supplierprovider.Save(supplier))
            {
                var locationHeaderValue = "/api/Supplier/" + supplier.Id;
                return this.BuildResponse(HttpStatusCode.Created, supplier, locationHeaderValue);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        public HttpResponseMessage Put(Supplier supplier)
        {
            if (_supplierprovider.Save(supplier))
            {
                return this.BuildResponse(HttpStatusCode.OK, supplier);
            }

            return this.BuildResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Delete(int id)
        {
            Supplier supplier = _supplierprovider.GetBySupplierId(id);
            //customer.SetIsActivate(false);

            if (_supplierprovider.Save(supplier))
            {
                return this.BuildResponse(HttpStatusCode.OK, supplier);
            }

            return this.BuildResponse(HttpStatusCode.NotFound);
        }
    }
}
