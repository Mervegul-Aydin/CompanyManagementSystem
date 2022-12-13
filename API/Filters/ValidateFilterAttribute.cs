using CompanyManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using CompanyManagementSystem.Core;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using CompanyManagementSystem.Core.Services;
using System.Threading.Tasks;
using CompanyManagementSystem.Core.DTOs;

namespace CompanyManagementSystem.API.Filters
{
    public class ValidateFilterAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors =  context.ModelState.Values.SelectMany(x=> x.Errors).Select(x=> x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors));
            }
        }
    }
}
