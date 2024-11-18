using comapny.Data.Contexts;
using comapny.Data.Models;
using company.Repo.Interfaces;
using company.Repo.repos;
using company.Service.interfaces;
using company.Service.services;
using company.Services.interfaces;
using company.Services.services;
using Microsoft.EntityFrameworkCore;
using company.Services.profile;
using compant.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1
{
    class TestClass
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CompanyDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            /*builder.Services.AddScoped<EmployeeInterface, EmployeeRepo>();
            builder.Services.AddScoped<DepartmentInterface, DepartmentRepo>();
            builder.Services.AddScoped<GenericInterface<Department>, GenericRepo<Department>>();
            builder.Services.AddScoped<GenericInterface<Employee>, GenericRepo<Employee>>();*/
            builder.Services.AddScoped<IunitWork, unitWork>();
            builder.Services.AddScoped<IDepartmentService, DeparmentServices>();
            builder.Services.AddScoped<IEmployeeService,EmployeeServices>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new EmployeeProfile()));
            builder.Services.AddAutoMapper(x => x.AddProfile(new departmentProfile()));
            builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<CompanyDbContext>();
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
                pattern: "{controller=Account}/{action=signUp}");

            app.Run();
        }
    }
}