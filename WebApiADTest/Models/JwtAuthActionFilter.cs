using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiADTest.Models
{
    public class JwtAuthActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string secret = "maxpower";

            if (actionContext.Request.Headers.Authorization == null || actionContext.Request.Headers.Authorization.Scheme != "Bearer")
            {
                SetErrorResponse(actionContext, "驗證錯誤");
            }
            string token = actionContext.Request.Headers.Authorization.Parameter;
            try
            {
                var dict = JWTLogic.DeToken(token);
            }
            catch (Exception ex)
            {
                SetErrorResponse(actionContext, ex.Message);
            }
            base.OnActionExecuting(actionContext);
        }

        private static void SetErrorResponse(HttpActionContext actionContext, string message)
        {
            var response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, message);
            actionContext.Response = response;
        }
    }
}