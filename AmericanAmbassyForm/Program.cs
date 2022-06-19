using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AmericanAmbassyForm.Data;
using AmericanAmbassyForm.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AmericanAmbassyFormContextConnection") ?? throw new InvalidOperationException("Connection string 'AmericanAmbassyFormContextConnection' not found.");

builder.Services.AddDbContext<AmericanAmbassyFormContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDbContext<AmericanAmbassyDBContex>(options => options.UseSqlServer(connectionString)); ;
builder.Services.AddScoped<AmericanAmbassyForm.Data.AmericanAmbassyDBContex, AmericanAmbassyDBContex>();
builder.Services.AddDefaultIdentity<AmericanAmbassyFormUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AmericanAmbassyFormContext>();;

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
