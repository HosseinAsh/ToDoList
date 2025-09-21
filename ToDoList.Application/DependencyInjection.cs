using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Abstractions.Behaviors;
using ToDoList.Application.ToDoList.AddToDoList;

namespace ToDoList.Application
{
    public static class DependencyInjection
    {
        //we configuring dependency injection in .net
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            return services;
        }
    }
}
