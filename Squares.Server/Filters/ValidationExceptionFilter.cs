using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Squares.Application.Common.Exceptions;
using Squares.Application.Models;
using Squares.Domain.Constants;

namespace Squares.Server.Filters;

public class ValidationExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is RequestValidationException validationException)
        {
            var errorResponse = new ErrorResponse
            {
                Messages = validationException.Errors.ToDictionary
               (
                   kvp => kvp.Key,
                   kvp => kvp.Value
               ),
                Type = ErrorResponseTypes.Validation
            };
            context.Result = new BadRequestObjectResult(errorResponse);
            context.ExceptionHandled = true;
        }
    }
}