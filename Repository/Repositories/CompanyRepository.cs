using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagementSystem.Core;
using CompanyManagementSystem.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using CompanyManagementSystem.Repository.AppDbContexts.AppDbContext;
using CompanyManagementSystem.Core.Models;
using CompanyManagementSystem.Core.Services;

namespace CompanyManagementSystem.Repository.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Company>> GetAllCompanyAsync()
        {
            return await _context.Companies.Include(x => x.Id).ToListAsync();
        }



        public async Task<List<Company>> GetApiAllCompanyAsync()
        {
            return await _context.Companies.Include(x => x.Id).ToListAsync();

        }

        public async Task<List<Company>> GetWebAllCompanyAsync()
        {
            return await _context.Companies.ToListAsync();

        }

        public async Task<Company> GetApiCompanyIdBranchOfficeAsync(int companyId)
        {
            return await _context.Companies.Include(x => x.BranchOffice).Where(x => x.Id == companyId).SingleOrDefaultAsync();
        }


        public async Task<Company> GetWebCompanyIdBranchOfficeAsync(int companyId)
        {
            return await _context.Companies.Include(x => x.BranchOffice).Where(x => x.Id == companyId).SingleOrDefaultAsync();
        }


        public async Task<Company> GetApiCompanyIdCompanyDealerAsync(int companyId)
        {
            return await _context.Companies.Include(x => x.CompanyDealer).Where(x => x.Id == companyId).SingleOrDefaultAsync();
        }


        public async Task<Company> GetWebCompanyIdCompanyDealerAsync(int companyId)
        {
            return await _context.Companies.Include(x => x.CompanyDealer).Where(x => x.Id == companyId).SingleOrDefaultAsync();
        }
    }
}
