using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Core.Models
{
    public abstract class BaseCompany
    {
        public int Id { get; set; }
        public string CompanyDescription { get; set; } //firma özellik -> List
        public string Adress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public string Explanation { get; set; }
        public string CompanyWebUrl { get; set; }
        public string TaxNumber { get; set; }
        public string TaxAdministration { get; set; }
        public string InvoiceAddress { get; set; }
        public string InvoiceMailAddress { get; set; }
        public string CompanyType { get; set; } // Firma Türü -> List
        public string LogoBase64Content { get; set; }

    }
}
