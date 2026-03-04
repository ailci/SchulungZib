using Infrastructure;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UI.Blazor.Components;
using UI.Blazor.Components.Account;
using UI.Blazor.Components.Pages;
using UI.Blazor.ComponentsLibrary;
using UI.Blazor.Configuration;
using UI.Blazor.Data;
using UI.Blazor.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddBlazorConfig()
    .AddAuthentificationConfig()
    .AddServicesConfig();

builder.Services
    .AddInfrastructureServices(builder.Configuration)
    .ConfigComponentLibrary();

var app = builder.Build();

// Configure the HTTP request pipeline. -------------------------------------------------------------------------
//app.Use(async (context, next) =>
//{
//    var userAgent = context.Request.Headers["User-Agent"][0];
//    await context.Response.WriteAsync($"Erste middleware {userAgent}\n");
//    await next();
//    await context.Response.WriteAsync("Erste Back middleware\n");
//});
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Zweite middleware\n");
//    await next();
//});
//app.Run(async context =>
//{
//    await context.Response.WriteAsync("End middleware\n");
//});

//app.UseBrowserAllowed(Browser.Chrome, Browser.Edge);

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
