using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Blazor.ComponentsLibrary;

public static class ServiceComponentLibRegistration
{
    public static IServiceCollection ConfigComponentLibrary(this IServiceCollection services)
    {
        //Dialog-Service
        services.AddScoped<DialogService>();

        return services;
    }
}