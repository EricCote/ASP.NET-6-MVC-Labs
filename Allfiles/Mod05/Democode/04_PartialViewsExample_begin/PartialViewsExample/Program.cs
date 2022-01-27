﻿using PartialViewsExample.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IPersonProvider, PersonProvider>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
