using LinkedInAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkedInAPI.Controllers
{
    public class JobsController : Controller
    {
        private readonly JobService _jobService;

        public JobsController(JobService jobService)
        {
            _jobService = jobService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _jobService.FindAllAsync();
            return View(list);
        }
    }
}
