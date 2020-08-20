using Microsoft.AspNetCore.Mvc;

namespace X.GateWay.ApiApp.Controllers
{
    [Route("")]
    public class TestPublishController : Controller
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Content("Hello from Test Publish Controller API!");
        }
    }




}
