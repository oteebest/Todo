using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Behaviours;

namespace Todo.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
