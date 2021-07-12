using System.Web;
using System.Web.Http;
using WebApiADTest.Models;

namespace WebApiADTest.Controllers
{
    public class AuthController : ApiController
    {
        public IHttpActionResult Post(User user)
        {
            bool Result = false;
            string token = string.Empty;
            if (user.name == "admin" && user.pwd == "admin")
            {
                token = JWTLogic.GetToken(user.name);
                HttpCookie cookie = new HttpCookie("Authorization");
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";
                cookie.Value = token;
                HttpContext.Current.Response.AppendCookie(cookie);
                Result = true;
            }

            return Json(new { Result, token });
        }
    }
}