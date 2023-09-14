using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Data
{
    public class StaffDbContext : DbContext
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options) : base(options) { }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Product> Product{get; set;}
        public DbSet<comments> Comments { get; set; }

    }
}
