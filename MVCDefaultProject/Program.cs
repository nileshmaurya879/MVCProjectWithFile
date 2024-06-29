using Microsoft.EntityFrameworkCore;
using MVCDefaultProject.Interface;
using MVCDefaultProject.Mapper;
using MVCDefaultProject.Models;
using MVCDefaultProject.Repository;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EmployeeDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("testConnection")));
builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddAutoMapper(typeof(EmployeeProfile));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
