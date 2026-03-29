using AvColSportsHire.Areas.Identity.Data;
using AvColSportsHire.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SportsHireContextConnection") ?? throw new InvalidOperationException("Connection string 'SportsHireContextConnection' not found.");;

builder.Services.AddDbContext<SportsHireContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<BookingReferenceService>();

builder.Services.AddDefaultIdentity<SportsHireUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SportsHireContext>();

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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
