using Microsoft.AspNetCore.Mvc;

namespace ApiJob.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("Check")]
      public bool Check()
        {
            return true;
        }
    }
}
