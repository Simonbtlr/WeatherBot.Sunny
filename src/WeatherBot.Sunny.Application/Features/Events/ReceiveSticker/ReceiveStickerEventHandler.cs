using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Telegram.Bot;

namespace WeatherBot.Sunny.Services.Telegram.Features.Events.ReceiveSticker;

public sealed class ReceiveStickerEventHandler : INotificationHandler<ReceiveStickerEvent>
{
    private const string Message = "Haha, nice sticker!";
    private readonly ITelegramBotClient _botClient;

    public ReceiveStickerEventHandler(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task Handle(ReceiveStickerEvent notification, CancellationToken ct)
    {
        await _botClient.SendTextMessageAsync(
            chatId: notification.ChatId,
            text: Message,
            cancellationToken: ct);
    }
}