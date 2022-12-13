using CompanyManagementSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Repository.Configurations
{
    public class CompanyConfiguration: IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.City).IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.Adress).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.EMail).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.PhoneNumber).IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.CompanyWebUrl).IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.TaxNumber).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.TaxAdministration).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.CompanyType).IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.CompanyDescription).IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.InvoiceAddress).IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.InvoiceMailAddress).IsRequired(false).HasMaxLength(1000);
       

        }
    }
}
