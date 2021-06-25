using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace Dorm.Api.Tools
{
    public class MyAuthAttribute : IAuthorizationFilter
    {
        public bool AllowMultiple { get; set; }

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0)
            {
                return await continuation();
            }
            if (actionContext.Request.Headers.TryGetValues("token", out var values))
            {
               
               
               
                return await continuation();
            }

            return actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, new HttpError("Token 不正确"));
        }
    }
}