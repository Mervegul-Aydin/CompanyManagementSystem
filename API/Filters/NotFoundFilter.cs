using CompanyManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using CompanyManagementSystem.Core;
using Microsoft.AspNetCore.Mvc;
using CompanyManagementSystem.Core.Services;
using System.Threading.Tasks;
using CompanyManagementSystem.Core.DTOs;


namespace CompanyManagementSystem.API.Filters
{
    public class NotFoundFilter<T> :  IAsyncActionFilter where T: BaseCompany
    {
        private readonly IGenericService<T> _service;
        public NotFoundFilter(IGenericService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }


            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) bulunamadı"));


        }

    }
}
