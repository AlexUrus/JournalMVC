using JournalMVC.Database;
using JournalMVC.Repositories.ADO;
using JournalMVC.Repositories.EF;
using JournalMVC.Repositories.Interfaces;
using JournalMVC.Services;
using JournalMVC.Services.Interfaces;
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
            
            AddRepositoriesEF(services);
            //AddRepositoriesADO(services);
            AddServices(services);

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
                name: "Activities",
                pattern: "{controller=Activities}/{action=Index}/{id?}");

            app.Run();
        }

        private static void AddDatabase(WebApplicationBuilder builder)
        {
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
        }

        public static void AddRepositoriesEF(IServiceCollection services)
        {
            services.AddScoped<IActivitiesRepository, ActivitiesRepositoryEF>();
            services.AddScoped<ITimeIntervalsRepository, TimeIntervalsRepositoryEF>();
            services.AddScoped<ITypeActivitiesRepository, TypeActivitiesRepositoryEF>();
        }
        public static void AddRepositoriesADO(IServiceCollection services)
        {
            services.AddScoped<IActivitiesRepository, ActivitiesRepositoryADO>();
            services.AddScoped<ITimeIntervalsRepository, TimeIntervalsRepositoryADO>();
            services.AddScoped<ITypeActivitiesRepository, TypeActivitiesRepositoryADO>();
        }

        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IActivitiesService, ActivitiesService>();
            services.AddScoped<ITimeIntervalsService, TimeIntervalsService>();
            services.AddScoped<ITypeActivitiesService, TypeActivitiesService>();
            services.AddScoped<IStatisticService, StatisticService>();
        }
    }
}
