using System.Reflection;
using Application.Common.Behaviours;
using Application.Common.Mapping;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMediatR(c =>
        {
            c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });
        
        serviceCollection.AddAutoMapper(c =>
        {
            c.AddProfile<MapperProfile>();
        });
        
        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    }
}