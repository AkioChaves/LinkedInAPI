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

        public async Task<List<Company>> FindAllAsync()
        {
            return await _context.Company.Include(x => x.Jobs).OrderBy(x => x.ID).ToListAsync();
        }

        public async Task<Company> FindByIdAsync(int id)
        {
            return await _context.Company.Include(obj => obj.Jobs).FirstOrDefaultAsync(obj => obj.ID == id);
        }
    }
}
