using MediatR;

namespace WeatherBot.Sunny.Services.Telegram.Features.Events.ReceiveSticker;

public sealed record ReceiveStickerEvent(long ChatId) : INotification;