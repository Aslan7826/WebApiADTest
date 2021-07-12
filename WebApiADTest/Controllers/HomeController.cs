using System.Web.Http;
using WebApiADTest.Models;

namespace WebApiADTest.Controllers
{
    [JwtAuthActionFilter]
    public class HomeController : ApiController
    {
        public IHttpActionResult Get(string name)
        {
            return Json(name);
        }
    }
}