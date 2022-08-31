using MediatR;
using Telegram.Bot.Types.Enums;

namespace WeatherBot.Sunny.Services.Telegram.Features.Events.UnknownUpdate;

public sealed record UnknownUpdateEvent(
        long? ChatId,
        int? MessageId,
        UpdateType MessageType)
    : INotification;