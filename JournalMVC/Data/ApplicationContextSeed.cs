using JournalMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalMVC.Data
{
    public class ApplicationContextSeed
    {
        private readonly ModelBuilder _modelBuilder;

        public ApplicationContextSeed(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            //_modelBuilder.Entity<TimeInterval>().HasData
            //(
            //    new TimeInterval() { Id = 1, StartActivity =  }
            //);

            //var routeId = Guid.NewGuid();
            //var locationId = Guid.NewGuid();
            //var dumpLocationId = Guid.NewGuid();
            //_modelBuilder.Entity<Route>().HasData(new Route(locationId, dumpLocationId, "TestRoute", 1.0d, 1.0d, true) { Id = routeId });
            //_modelBuilder.Entity<RoutePoint>().HasData
            //(
            //    new(routeId, 1.0, 1.0, 1.0) { Id = 1 },
            //    new(routeId, 2.0, 2.0, 2.0) { Id = 2 },
            //    new(routeId, 3.0, 3.0, 3.0) { Id = 3 },
            //    new(routeId, 4.0, 4.0, 4.0) { Id = 4 }
            //);
        }

    }
}
