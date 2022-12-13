using CompanyManagementSystem.Core.Models;
using CompanyManagementSystem.Core.Repositories;
using CompanyManagementSystem.Repository.AppDbContexts.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Repository.Repositories
{
    public class CompanyDealerRepository : GenericRepository<CompanyDealer>, ICompanyDealerRepository
    {
        public CompanyDealerRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<CompanyDealer>> GetApiAllCompanyDealerAsync()
        {
            return await _context.CompanyDealers.ToListAsync();
        }

        public async Task<List<CompanyDealer>> GetWebAllCompanyDealerAsync()
        {
            return await _context.CompanyDealers.ToListAsync();
        }
    }
}
