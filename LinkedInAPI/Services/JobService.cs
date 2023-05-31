using LinkedInAPI.Data;
using LinkedInAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinkedInAPI.Services
{
    public class JobService
    {
        private readonly LinkedInAPIContext _context;

        public JobService(LinkedInAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Job>> FindAllAsync()
        {
            return await _context.Job.OrderBy(x => x.PostedDate).ToListAsync();
        }

        public async Task<Job> FindByIdAsync(int id)
        {
            return await _context.Job.Include(obj => obj.Company).FirstOrDefaultAsync(obj => obj.ID == id);
        }
    }
}
