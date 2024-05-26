using JournalMVC.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JournalMVC.Services
{
    public class InitializationService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public InitializationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var yourService = scope.ServiceProvider.GetRequiredService<IActivitiesService>();
                await yourService.InitializeCurrentMonthAndDay();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
