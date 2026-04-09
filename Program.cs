using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using USCJCI.Data;
using USCJCI.Models;
using USCJCI.Repositories;
using USCJCI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<Service1>();

builder.Services.AddScoped<IRepository<Teacher>, TeacherRepository>();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; 
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    ; 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    RoleSeeder.SeedRoles(service).Wait();
    UserSeeder.SeedUsers(service).Wait();
}


app.Run();
