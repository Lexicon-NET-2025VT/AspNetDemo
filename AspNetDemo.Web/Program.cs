using AspNetDemo.Web.Services;

namespace AspNetDemo.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddSingleton<CompanyService>();

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
