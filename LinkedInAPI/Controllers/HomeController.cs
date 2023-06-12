using LinkedInAPI.Data;
using LinkedInAPI.Models.ViewModels;
using LinkedInAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LinkedInAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LinkedInAPIContext _context;
        private readonly JobService _jobService;

        public HomeController(ILogger<HomeController> logger, LinkedInAPIContext context,JobService jobService)
        {
            _logger = logger;
            _context = context;
            _jobService = jobService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _jobService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> JobSearch(string searchString)
        {
            if (searchString == null)
            {
                var list = await _jobService.FindAllAsync();
                return View(list);
            }

            var jobs = from j in _context.Job
                       select j;

            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(s => s.Title.Contains(searchString));
            }

            return View(await jobs.Include(x => x.Company).OrderBy(x => x.Title).ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}