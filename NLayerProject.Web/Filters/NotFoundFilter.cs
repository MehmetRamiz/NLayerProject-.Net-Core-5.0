using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.Web.Dto;
//using NLayerProject.Core.Services;
//using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLayerProject.Web.ApiService;

namespace NLayerProject.Web.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {

        private readonly CategoryApiService _categoryApiService;

        public NotFoundFilter(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _categoryApiService.GetById(id);

            if(product!= null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"id'si {id} olan ürün veritabanında bulunamadı");

                context.Result = new RedirectToActionResult("Error","Home",errorDto);
            }
        }

    }
}


