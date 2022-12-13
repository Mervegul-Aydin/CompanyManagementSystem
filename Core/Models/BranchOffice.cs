using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Core.Models
{
    public class BranchOffice:BaseCompany
    {  
        
        public string Name { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

    }
}
