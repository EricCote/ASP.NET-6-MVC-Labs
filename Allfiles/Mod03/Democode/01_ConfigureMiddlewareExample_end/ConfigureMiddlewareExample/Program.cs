var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Entering middleware. Request path is: " + context.Request.Path.Value + "  \n");
    await next.Invoke();
    await context.Response.WriteAsync("Exiting middleware. \n");
});

app.Run( async (context) =>
{
    await context.Response.WriteAsync("This text was generated by the app.run middleware. \n");
});

app.Run();


