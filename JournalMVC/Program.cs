using JournalMVC.Database;
using JournalMVC.Repositories;
using JournalMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JournalMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            IServiceCollection services = builder.Services;
            AddDatabase(builder);
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(AppMappingProfile));
            
            AddRepositories(services);

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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
        }

        private static void AddDatabase(WebApplicationBuilder builder)
        {
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
        }

        public static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
            services.AddScoped<ITimeIntervalsRepository, TimeIntervalsRepository>();
            services.AddScoped<ITypeActivitiesRepository, TypeActivitiesRepository>();
        }
    }
}
