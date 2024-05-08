using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.DAL;

namespace ProniaWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            

            var app = builder.Build();

           
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");


            app.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
          


            app.Run();
        }
    }
}
