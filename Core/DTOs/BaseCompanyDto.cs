using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Core.DTOs
{
    public abstract class BaseCompanyDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int CompanyDealerId { get; set; }
        public int IsActive { get; set; }

        public string CompanyDescription { get; set; } //firma özellik -> List
        public string Adress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyWebUrl { get; set; }
        public string TaxNumber { get; set; }
        public string TaxAdministration { get; set; }
        public string InvoiceAddress { get; set; }
        public string InvoiceMailAddress { get; set; }
        public string CompanyType { get; set; }
    }
}
