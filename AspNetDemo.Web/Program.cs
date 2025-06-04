
using AspNetDemo.Application;
using AspNetDemo.Application.Companies;
using AspNetDemo.Infrastructure.Persistance;
using AspNetDemo.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AspNetDemo.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<ICompanyService, CompanyService>();
        builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        var connString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(connString));

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/error/exception");
            app.UseStatusCodePagesWithRedirects("/error/http/{0}");
        }

        app.MapControllers();

        app.Run();
    }
}
