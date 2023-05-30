using Microsoft.AspNetCore.Mvc;

namespace LinkedInAPI.Controllers
{
    public class JobsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
