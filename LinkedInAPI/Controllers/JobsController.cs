using LinkedInAPI.Models;
using LinkedInAPI.Models.ViewModels;
using LinkedInAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LinkedInAPI.Controllers
{
    public class JobsController : Controller
    {
        private readonly JobService _jobService;
        private readonly CompanyService _companyService;

        public JobsController(JobService jobService, CompanyService companyService)
        {
            _jobService = jobService;
            _companyService = companyService;
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
                return RedirectToAction(nameof(Error), new { message = "ID not provided!" });
            }

            var obj = await _jobService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not found!" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Apply(int? id, Job job)
        {
            if (!ModelState.IsValid)
            {
                var obj = await _jobService.FindByIdAsync(id.Value);
                return View(obj);
            }
            if (id != job.ID)
            {
                return RedirectToAction(nameof(Error), new { message = "ID mismatch!" });
            }
            try
            {
                job.Status = (Models.Enums.ApplicationStatus)1;
                await _jobService.UpdateAsync(job);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}