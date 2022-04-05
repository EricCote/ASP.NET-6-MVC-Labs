var app = WebApplication.Create(args);

app.UseStaticFiles();

app.Run(async (context) =>
{
    await context.Response.WriteAsync("This text was generated by middleware.");
});

app.Run();