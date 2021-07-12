using System.Web.Http;

namespace WebApiADTest.Controllers
{
    public class DefaultController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Json("56");
        }

        public IHttpActionResult Post()
        {
            return Json("5566");
        }
    }
}