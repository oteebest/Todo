using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Todo.Application.Behaviours;
using Todo.Application.Contracts.Db;
using Todo.Application.Contracts.Services.Users;
using Todo.Application.Contracts.WorkItems;
using Todo.Application.Db;
using Todo.Application.Services.User;
using Todo.Application.Services.WorkItem;
using Todo.Domain.Users;
using Todo.EntityFramework.Context;

namespace Todo.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TodoDatabase");
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Todo.EntityFramework")))
                 .AddTransient<IDatabaseSeeder, DatabaseSeeder>(); ;

            serviceCollection.AddScoped<IDatabaseService, ApplicationDbContext>();

            return serviceCollection;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<TodoUser, TodoIdentityRole>(options =>
                {
                    options.Password.RequiredLength = 4;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IWorkItemService, WorkItemService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            
        }
    }
}
