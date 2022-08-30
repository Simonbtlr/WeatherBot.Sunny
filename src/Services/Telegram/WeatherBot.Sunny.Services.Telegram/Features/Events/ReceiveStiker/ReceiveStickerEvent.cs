using MediatR;

namespace WeatherBot.Sunny.Services.Telegram.Features.Events.ReceiveStiker;

public sealed record ReceiveStickerEvent(long ChatId) : INotification;