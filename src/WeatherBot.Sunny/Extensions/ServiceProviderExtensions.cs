using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace WeatherBot.Sunny.Extensions;

public static class ServiceProviderExtensions
{
    public static T GetConfiguration<T>(this IServiceProvider serviceProvider)
        where T : class
    {
        var options = serviceProvider.GetService<IOptions<T>>();
        
        if (options is null)
            throw new ArgumentNullException(nameof(T));

        return options.Value;
    }
}