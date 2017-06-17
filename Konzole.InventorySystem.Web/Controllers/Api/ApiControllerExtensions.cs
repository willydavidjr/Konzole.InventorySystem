using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using Konzole.InventorySystem;
using Konzole.InventorySystem.Providers.Interface;

namespace Konzole.InventorySystem.Web.Controllers.Api
{
    public static class ApiControllerExtensions
    {
        #region Build response message helpers

        public static HttpResponseMessage BuildResponse(this ApiController controller, HttpStatusCode statusCode)
        {
            return BuildResponse(controller, statusCode, null);
        }

        public static HttpResponseMessage BuildResponse(this ApiController controller, HttpStatusCode statusCode, object model)
        {
            return BuildResponse(controller, statusCode, model, null);
        }

        public static HttpResponseMessage BuildResponse(this ApiController controller, HttpStatusCode statusCode, object model, string locationHeaderValue)
        {
            HttpResponseMessage response;

            if (model == null)
            {
                response = controller.Request.CreateResponse(statusCode);
            }
            else
            {
                response = controller.Request.CreateResponse(statusCode, model);
            }

            if (!string.IsNullOrEmpty(locationHeaderValue))
            {
                response.Headers.Location = new Uri(controller.Request.RequestUri, locationHeaderValue);
            }

            return response;
        }

        #endregion

        #region Logged in user helpers

        public static MembershipUser GetCurrentUser(this ApiController controller)
        {
            return Membership.GetUser();
        }

        public static Person GetCurrentPerson(this ApiController controller)
        {
            var providerKey = (Guid)Membership.GetUser().ProviderUserKey;
            var person = PersonProvider.GetByUserId(providerKey);

            return person;
        }

        /// <summary>
        /// This gets set in the Global.asax.cs, and in testing shoud be set in the arrange part.
        /// </summary>
        public static IPersonProvider PersonProvider { get; set; }

        #endregion

    }
}
