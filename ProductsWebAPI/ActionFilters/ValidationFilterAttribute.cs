using Entities.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ProductsWebAPI.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        private readonly ILogger<ValidationFilterAttribute> _logger;

        public ValidationFilterAttribute(ILogger<ValidationFilterAttribute> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            KeyValuePair<string, object> param = context.ActionArguments.SingleOrDefault(p => p.Value is IEntityInputModel);
            if (param.Value == null)
            {
                string msg = "Input data is null";
                context.Result = new BadRequestObjectResult(msg);
                _logger.LogError(context.ActionDescriptor.DisplayName + ": " + msg);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);

                //get all errors from model state
                string msg = string.Empty;
                context.ModelState.Values.SelectMany(v => v.Errors).ToList().ForEach(e => msg += e.ErrorMessage + " ");
                _logger.LogError(context.ActionDescriptor.DisplayName + ": " + msg);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
