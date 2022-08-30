using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WeatherBot.Sunny.Services.Telegram.Features.Events.ReceiveMessage;

namespace WeatherBot.Sunny.Modules;

public static class MediatorModule
{
    public static IServiceCollection AddMediatorModule(this IServiceCollection services) =>
        services
            .AddMediatR(typeof(ReceiveMessageEvent).Assembly);
}