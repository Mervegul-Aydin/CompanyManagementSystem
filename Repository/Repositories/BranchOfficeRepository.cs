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
    public class BranchOfficeRepository : GenericRepository<BranchOffice>, IBranchOfficeRepository
    {
        public BranchOfficeRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<BranchOffice>> GetApiAllBranchOfficeAsync()
        {
            return await _context.BranchOffices.ToListAsync();
        }

        public async Task<List<BranchOffice>> GetWebAllBranchOfficeAsync()
        {
            return await _context.BranchOffices.ToListAsync();
        }
    }
}
