using ApplicationSecurity.Application.ReusableClasses;

namespace ApplicationSecurityApi.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate _next)
        {
            this._next = _next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = new ResponseWithApiStatusCode<string>
            {
                StatusCode = context.Response.StatusCode,
                Succeeded = false,
                Message = "An Error has occured. Check Exception for details",
                ExceptionMessage = ex?.Message,
                ExceptionError = $"Exception: {ex?.ToString()}",
                InnerException = ex?.InnerException?.ToString(),
                ExceptionStackTrace = ex?.StackTrace?.ToString()
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
