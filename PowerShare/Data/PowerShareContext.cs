using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PowerShare.Models
{
    public class PowerShareContext : DbContext
    {
        public PowerShareContext (DbContextOptions<PowerShareContext> options)
            : base(options)
        {
        }
        public DbSet<PowerShare.Models.User> User { get; set; }
    }
}
