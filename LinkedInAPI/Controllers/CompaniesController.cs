using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinkedInAPI.Data;
using LinkedInAPI.Models;
using LinkedInAPI.Services;
using LinkedInAPI.Models.ViewModels;
using System.Diagnostics;

namespace LinkedInAPI.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly CompanyService _companyService;
        private readonly LinkedInAPIContext _context;

        public CompaniesController(LinkedInAPIContext context, CompanyService companyService)
        {
            _context = context;
            _companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Company != null ? 
                          View(await _context.Company.Include(x => x.Jobs).ToListAsync()) :
                          Problem("Entity set 'LinkedInAPIContext.Company'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not provided!" });
            }

            var company = await _context.Company.Include(x => x.Jobs)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (company == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not found!" });
            }

            return View(company);
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