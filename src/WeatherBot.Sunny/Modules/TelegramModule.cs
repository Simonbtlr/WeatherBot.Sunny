using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Polling;
using WeatherBot.Sunny.Services.Telegram;
using WeatherBot.Sunny.Services.Telegram.Abstractions;

namespace WeatherBot.Sunny.Modules;

public static class TelegramModule
{
    public static IServiceCollection AddTelegramModule(this IServiceCollection services, IConfiguration configuration)
    {
        var botOptions = configuration.GetSection("BotConfiguration");
        botOptions["BotToken"] = Environment.GetEnvironmentVariable("BOT_TOKEN");

        services.AddHttpClient("telegram_bot_client")
            .AddTypedClient<ITelegramBotClient>((httpClient, _) =>
            {
                var options = new TelegramBotClientOptions(botOptions["BotToken"]);

                return new TelegramBotClient(options, httpClient);
            });

        services
            .AddScoped<IUpdateHandler, UpdateHandler>()
            .AddScoped<IReceiver, Receiver>()
            .AddHostedService<Polling>();

        return services;
    }
}