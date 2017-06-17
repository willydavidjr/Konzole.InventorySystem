using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Konzole.InventorySystem.Providers.Interface;

namespace Konzole.InventorySystem.Web.Controllers.Api
{
    public class CustomerController : ApiController
    {
        ICustomerProvider _customerprovider = null;
        public CustomerController(ICustomerProvider customerProvider)
        {
            this._customerprovider = customerProvider;
        }

        public HttpResponseMessage GetList()
        {
            return this.BuildResponse(HttpStatusCode.OK, _customerprovider.GetList());
        }

        public HttpResponseMessage Get(int id)
        {
            return this.BuildResponse(HttpStatusCode.OK, _customerprovider.GetByCustomerId(id));
        }

        public HttpResponseMessage Post(Customer customer)
        {
            if (_customerprovider.Save(customer))
            {
                var locationHeaderValue = "/api/Customer/" + customer.Id;
                return this.BuildResponse(HttpStatusCode.Created, customer, locationHeaderValue);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        public HttpResponseMessage Put(Customer customer)
        {
            if (_customerprovider.Save(customer))
            {
                return this.BuildResponse(HttpStatusCode.OK, customer);
            }

            return this.BuildResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Delete(int id)
        {
            Customer customer = _customerprovider.GetByCustomerId(id);
            //customer.SetIsActivate(false);

            if (_customerprovider.Save(customer))
            {
                return this.BuildResponse(HttpStatusCode.OK, customer);
            }

            return this.BuildResponse(HttpStatusCode.NotFound);
        }
    }
}
