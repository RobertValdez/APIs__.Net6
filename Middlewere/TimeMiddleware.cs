namespace APIs_con_.NET.Middlewere
{
    public class TimeMiddleware
    {
        readonly RequestDelegate  next;

        public TimeMiddleware(RequestDelegate nextRequest)
        {
            next = nextRequest;
        }

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
        {
            if (context.Request.Query.Any(p => p.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            }
            
            if (!context.Response.HasStarted)
            {
              await next(context);
            }
        }
    }

     public static class TimeMiddlewereExtension
        {
            public static IApplicationBuilder UseTimeMiddlewere(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<TimeMiddleware>();
            }
        }
}