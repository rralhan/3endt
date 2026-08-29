using _3endt.Configuration;
using _3endt.Configuration.Interface;
using _3endt.Helper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
    });

builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IAppConfiguration, AppConfiguration>();

// Add remaining services here...

builder.Services.AddControllersWithViews();

var app = builder.Build();

// SessionManager initialization
SessionManager._httpContextAccessor =
    app.Services.GetRequiredService<IHttpContextAccessor>();

// Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Documents")),
    RequestPath = "/Documents"
});

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
