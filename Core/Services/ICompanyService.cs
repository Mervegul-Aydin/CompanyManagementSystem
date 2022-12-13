using CompanyManagementSystem.Core.DTOs;
using CompanyManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Core.Services
{
    public interface ICompanyService : IGenericService<Company>
    {

        public Task<CustomResponseDto<CompanyDto>> GetApiCompanyIdAsync(int companyId);
        public Task<CustomResponseDto<CompanyDto>> GetApiAllCompanyAsync();
        public Task<List<CompanyDto>> GetWebCompanyIdCompanyDealerAsync(int companyId);
        public Task<List<CompanyDto>> GetWebCompanyIdBranchOfficeAsync(int companyId);

        
        public Task<List<CompanyDto>> GetWebCompanyCompanyDealerAsync();
        public Task<List<CompanyDto>> GetWebCompanyBranchOfficeAsync();
        public Task<List<CompanyDto>> GetWebAllCompanyAsync();


    }
}
