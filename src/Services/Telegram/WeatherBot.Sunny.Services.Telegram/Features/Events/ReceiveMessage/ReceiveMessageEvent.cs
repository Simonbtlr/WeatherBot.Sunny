using MediatR;

namespace WeatherBot.Sunny.Services.Telegram.Features.Events.ReceiveMessage;

public sealed record ReceiveMessageEvent(
        long ChatId, 
        string Text) 
    : INotification;