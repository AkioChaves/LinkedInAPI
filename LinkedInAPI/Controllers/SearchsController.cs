using LinkedInAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using LinkedInAPI.Data;

namespace LinkedInAPI.Controllers
{
    public class SearchsController : Controller
    {
        private readonly JobService _jobservice;
        private readonly CompanyService _companyservice;
        private readonly LinkedInAPIContext _context;

        public SearchsController(LinkedInAPIContext context, JobService jobservice, CompanyService companyservice)
        {
            _context = context;
            _jobservice = jobservice;
            _companyservice = companyservice;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> JobSearch(string searchString)
        {
            if (searchString == null)
            {
                var list = _jobservice.FindAllAsync();
                return View(list);
            }

            var jobs = from j in _context.Job
                       select j;

            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(s => s.Title.Contains(searchString));
            }

            return View(jobs);
        }
    }
}
