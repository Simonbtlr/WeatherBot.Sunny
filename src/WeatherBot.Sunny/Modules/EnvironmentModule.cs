using DotNetEnv;
using Microsoft.Extensions.Hosting;

namespace WeatherBot.Sunny.Modules;

public static class EnvironmentModule
{
    public static void LoadSecrets(this IHostEnvironment env)
    {
        var paths = new[]
        {
            ".env",
            env.IsProduction()
                ? ".env.production"
                : ".env.staging"
        };

        Env.LoadMulti(paths);
    }
}