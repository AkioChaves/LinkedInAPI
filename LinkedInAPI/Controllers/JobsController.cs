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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _jobService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}
