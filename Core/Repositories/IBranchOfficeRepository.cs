using CompanyManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Core.Repositories
{
    public interface IBranchOfficeRepository:IGenericRepository<BranchOffice>
    {
        Task<List<BranchOffice>> GetApiAllBranchOfficeAsync();
        Task<List<BranchOffice>> GetWebAllBranchOfficeAsync();

    }
}
