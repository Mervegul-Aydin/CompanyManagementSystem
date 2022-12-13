using CompanyManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Core.Repositories
{
    public interface ICompanyRepository:IGenericRepository<Company>
    {
        Task<Company> GetApiCompanyIdBranchOfficeAsync(int companyId);
        Task<Company> GetWebCompanyIdBranchOfficeAsync(int companyId);

        Task<Company> GetApiCompanyIdCompanyDealerAsync(int companyId);
        Task<Company> GetWebCompanyIdCompanyDealerAsync(int companyId);

        Task<List<Company>> GetApiAllCompanyAsync();
        Task<List<Company>> GetWebAllCompanyAsync();
    }
}
