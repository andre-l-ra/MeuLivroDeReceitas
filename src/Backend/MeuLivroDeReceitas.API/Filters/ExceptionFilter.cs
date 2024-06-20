using System.Net;
using MeuLivroDeReceitas.Communication.Responses;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MeuLivroDeReceitas.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is MeuLivroDeReceitasException)
        {
            HandlerProjectException(context);
        }
        else
        {

        }
    }

    private void HandlerProjectException(ExceptionContext context)
    {
        if(context.Exception is ErrorOnValidationException)
        {
            var exception = context.Exception as ErrorOnValidationException;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorMessages));
        }
    }

    private void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson("Erro desconhecido"));
    }
}