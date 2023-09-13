﻿using Microsoft.Extensions.DependencyInjection;
using MyTicketRemaster.Application.Common.Behaviors;
using System.Reflection;

namespace MyTicketRemaster.Application;

public static class ApplicationStartup
{
    public static void AddMyApplicationDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionLoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
    }
}
