using Microsoft.EntityFrameworkCore;
using Todo.Application.Contracts.Db;
using Todo.EntityFramework.Context;

namespace Todo.Api.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void MigrateDBSeedData(this ServiceProvider serviceProvider, IConfiguration configuration)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            db.Database.Migrate();

            var dbSeeder = serviceProvider.GetService<IDatabaseSeeder>();
            dbSeeder.Initialise(Convert.ToBoolean(configuration.GetSection("ShouldSeed").Value));         
        }
    }
}
