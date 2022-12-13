using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CompanyManagementSystem.Core.Models;

namespace CompanyManagementSystem.Repository.AppDbContexts.AppDbContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {   
        }
      

        public DbSet<Company> Companies{ get; set; }

        public DbSet<CompanyDealer> CompanyDealers { get; set; }

        public DbSet<BranchOffice> BranchOffices { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
