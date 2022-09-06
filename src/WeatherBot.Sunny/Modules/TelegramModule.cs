using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Polling;
using WeatherBot.Sunny.Application;
using WeatherBot.Sunny.Application.Handler;

namespace WeatherBot.Sunny.Modules;

public static class TelegramModule
{
    public static IServiceCollection AddTelegramModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("telegram_bot_client")
            .AddTypedClient<ITelegramBotClient>((httpClient, _) =>
            {
                var token = Environment.GetEnvironmentVariable("BOT_TOKEN");

                if (token is null)
                    throw new ArgumentNullException(nameof(token));

                var options = new TelegramBotClientOptions(token);

                return new TelegramBotClient(options, httpClient);
            });

        services
            .AddScoped<IUpdateHandler, UpdateHandler>()
            .AddScoped<IReceiver, Receiver>()
            .AddHostedService<Polling>();

        return services;
    }
}