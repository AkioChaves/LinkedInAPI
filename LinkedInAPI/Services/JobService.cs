using LinkedInAPI.Data;
using LinkedInAPI.Models;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Job.ToListAsync();
        }
    }
}
