using Application;
using Framework;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity;
using TetronJob.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.InfrastructureConfiguration(builder.Configuration);
builder.Services.ApplicationConfiguration(builder.Configuration);
builder.Services.FrameworkConfiguration(builder.Configuration);




//Identity
builder.Services.Configure<IdentityOptions>(option =>
{
    option.User.RequireUniqueEmail = true;
    option.Password.RequireNonAlphanumeric = true;
    option.Password.RequiredLength = 6;
    option.SignIn.RequireConfirmedEmail = true;
    option.SignIn.RequireConfirmedAccount = false;
    option.SignIn.RequireConfirmedPhoneNumber = false;
    option.Lockout.MaxFailedAccessAttempts = 4;
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    option.User.RequireUniqueEmail = true;
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequiredUniqueChars = 1;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;
});
builder.Services.ConfigureApplicationCookie(cooke =>
{
    cooke.ExpireTimeSpan = TimeSpan.FromDays(30);
    cooke.LoginPath = "/Identity/SignIn";
    cooke.AccessDeniedPath = "/";
    cooke.SlidingExpiration = true;
});
//Identity


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization(); 
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
