using FluentValidation;
using CompanyManagementSystem.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Service.Validations
{
    public class CompanyDealerDtoValidator: AbstractValidator<CompanyDealerDto>
    {
        public CompanyDealerDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Explanation).NotEmpty().WithMessage("{PropertyShortCode} is required").NotEmpty().WithMessage("{PropertyShortCode} is required");

        }
    }
}
