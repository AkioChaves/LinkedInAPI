using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LinkedInAPI.Models;

namespace LinkedInAPI.Data
{
    public class LinkedInAPIContext : DbContext
    {
        public LinkedInAPIContext (DbContextOptions<LinkedInAPIContext> options)
            : base(options)
        {
        }

        public DbSet<LinkedInAPI.Models.Company> Company { get; set; } = default!;
    }
}
