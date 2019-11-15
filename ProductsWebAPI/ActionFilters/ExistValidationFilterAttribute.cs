using Entities.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Interfaces;
using System;

namespace ProductsWebAPI.ActionFilters
{
    public class ExistValidationFilterAttribute<TEntity, TService> : IActionFilter 
        where TService : class, IService<TEntity>
        where TEntity: class, IEntityDto
    {
        private TService _repository;

        public ExistValidationFilterAttribute(TService repo)
        {
            _repository = repo;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Guid id = Guid.Empty;

            if(context.ActionArguments.ContainsKey("id"))
            {
                id = (Guid)context.ActionArguments["id"];
            }
            else
            {
                context.Result = new BadRequestObjectResult("Not found id parameter");
                return;
            }
            
            if(!_repository.Exists(id))
            {
                context.Result = new NotFoundObjectResult($"Data with id {id} can not be found.");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
