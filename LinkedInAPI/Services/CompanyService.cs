using LinkedInAPI.Data;
using LinkedInAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinkedInAPI.Services
{
    public class CompanyService
    {
        private readonly LinkedInAPIContext _context;

        public CompanyService(LinkedInAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> FindAllSync()
        {
            return await _context.Company.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
