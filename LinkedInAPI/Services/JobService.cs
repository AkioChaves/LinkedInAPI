using LinkedInAPI.Data;
using LinkedInAPI.Models;
using LinkedInAPI.Services.Exceptions;
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
            return await _context.Job.Include(x => x.Company).OrderBy(x => x.PostedDate).ToListAsync();
        }

        public async Task<Job?> FindByIdAsync(int id)
        {
            return await _context.Job.Include(obj => obj.Company).FirstOrDefaultAsync(obj => obj.ID == id);
        }

        public async Task UpdateAsync(Job obj)
        {
            bool hasNy = await _context.Job.AnyAsync(x => x.ID == obj.ID);
            if (!hasNy)
            {
                throw new NotFoundException("ID not found!");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}