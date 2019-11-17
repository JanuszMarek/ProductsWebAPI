using Entities.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using System;

namespace ProductsWebAPI.ActionFilters
{
    public class ExistValidationFilterAttribute<TEntity, TService> : IActionFilter 
        where TService : class, IService<TEntity>
        where TEntity: class, IEntityDto
    {
        private TService _repository;
        private readonly ILogger<ExistValidationFilterAttribute<TEntity, TService>> _logger;

        public ExistValidationFilterAttribute(TService repo, ILogger<ExistValidationFilterAttribute<TEntity, TService>> logger)
        {
            _repository = repo;
            _logger = logger;
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
                string msg = "Id could not be found in parameters";
                _logger.LogError(context.ActionDescriptor.DisplayName + ": " + msg);
                context.Result = new BadRequestObjectResult(msg);
                return;
            }
            
            if(!_repository.Exists(id))
            {
                string msg = $"Data with id {id} can not be found.";
                _logger.LogError(context.ActionDescriptor.DisplayName + ": " + msg);
                context.Result = new NotFoundObjectResult(msg);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
