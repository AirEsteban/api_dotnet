
    public class TimeMiddleware
    {
        private readonly RequestDelegate _next;

        // Inject the RequestDelegate to call the next middleware
        public TimeMiddleware (RequestDelegate next)
        {
            this._next = next;
        } 

        // Needed the Invoke method to specify the actions taken by this
        // middleware
        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Request.Query.Any(param => param.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToLongDateString());
            }

        }
    }

    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }

