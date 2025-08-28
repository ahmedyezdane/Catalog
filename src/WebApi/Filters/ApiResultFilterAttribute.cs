using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace WebApi.Filters;

// © Credit: https://github.com/mjebrahimi/AspNetCore-WebApi-Course

public class ApiResultFilterAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is OkObjectResult okObjectResult)
        {
            var apiResult = new ApiResult<object>(true, HttpStatusCode.OK, okObjectResult.Value);
            context.Result = new JsonResult(apiResult) { StatusCode = okObjectResult.StatusCode };
        }
        else if (context.Result is OkResult okResult)
        {
            var apiResult = new ApiResult(true, HttpStatusCode.OK);
            context.Result = new JsonResult(apiResult) { StatusCode = okResult.StatusCode };
        }
        else if (context.Result is ObjectResult badRequestObjectResult && badRequestObjectResult.StatusCode == 400)
        {
            string message = null;
            switch (badRequestObjectResult.Value)
            {
                case ValidationProblemDetails validationProblemDetails:
                    var errorMessages = validationProblemDetails.Errors.SelectMany(p => p.Value).Distinct();
                    message = string.Join(" | ", errorMessages);
                    break;
                case SerializableError errors:
                    var errorMessages2 = errors.SelectMany(p => (string[])p.Value).Distinct();
                    message = string.Join(" | ", errorMessages2);
                    break;
                case var value when value != null && !(value is ProblemDetails):
                    message = badRequestObjectResult.Value.ToString();
                    break;
            }

            var apiResult = new ApiResult(false, HttpStatusCode.BadRequest, message);
            context.Result = new JsonResult(apiResult) { StatusCode = badRequestObjectResult.StatusCode };
        }
        else if (context.Result is ObjectResult notFoundObjectResult && notFoundObjectResult.StatusCode == 404)
        {
            string message = null;
            if (notFoundObjectResult.Value != null && !(notFoundObjectResult.Value is ProblemDetails))
                message = notFoundObjectResult.Value.ToString();

            var apiResult = new ApiResult(false, HttpStatusCode.NotFound, message);
            context.Result = new JsonResult(apiResult) { StatusCode = notFoundObjectResult.StatusCode };
        }
        else if (context.Result is ContentResult contentResult)
        {
            var apiResult = new ApiResult(true, HttpStatusCode.OK, contentResult.Content);
            context.Result = new JsonResult(apiResult) { StatusCode = contentResult.StatusCode };
        }
        else if (context.Result is ObjectResult objectResult && objectResult.StatusCode == null
            && !(objectResult.Value is ApiResult))
        {
            var apiResult = new ApiResult<object>(true, HttpStatusCode.OK, objectResult.Value);
            context.Result = new JsonResult(apiResult) { StatusCode = objectResult.StatusCode };
        }

        base.OnResultExecuting(context);
    }
}
