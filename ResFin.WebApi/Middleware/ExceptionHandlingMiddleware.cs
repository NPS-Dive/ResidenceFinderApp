namespace ResFin.WebApi.Middleware;

public class ExceptionHandlingMiddleware
    {
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware (
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger )
        {
        _next = next;
        _logger = logger;
        }

    public async Task InvokeAsync ( HttpContext context )
        {
        try
            {
            await _next(context);
            }
        catch (Exception invokeException)
            {
            _logger.LogError(invokeException, "Exception Occured: {Message}", invokeException.Message);

            var exceptionDetails = GetExceptionDetails(invokeException);

            var problemDetails = new ProblemDetails
                {
                Detail = exceptionDetails.Details,
                Status = exceptionDetails.Status,
                Title = exceptionDetails.Title,
                Type = exceptionDetails.Type
                };

            if (exceptionDetails.Errors is not null)
                {
                problemDetails.Extensions["errors"] = exceptionDetails.Errors;
                }

            context.Response.StatusCode = exceptionDetails.Status;

            await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }

    private static ExceptionDetails GetExceptionDetails ( Exception exception )
        {
        return exception switch
            {
              ValidationException validationException => new ExceptionDetails(
                    "One or more validation errors occured",
                    StatusCodes.Status400BadRequest,
                    "validation error",
                      "validationFailure",
                    validationException.Errors),

                _ => new ExceptionDetails(
                    "An unexpected error occured",
                    StatusCodes.Status500InternalServerError,
                    "Server Error",
                    "serverError",
                    null)
                };
        }

    }