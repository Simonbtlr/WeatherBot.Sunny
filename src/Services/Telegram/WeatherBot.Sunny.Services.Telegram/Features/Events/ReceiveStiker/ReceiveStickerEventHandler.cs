using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Telegram.Bot;

namespace WeatherBot.Sunny.Services.Telegram.Features.Events.ReceiveStiker;

public sealed class ReceiveStickerEventHandler : INotificationHandler<ReceiveStickerEvent>
{
    private const string Message = "Haha, nice sticker!";
    private readonly ITelegramBotClient _botClient;

    public ReceiveStickerEventHandler(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task Handle(ReceiveStickerEvent @event, CancellationToken ct)
    {
        await _botClient.SendTextMessageAsync(
            chatId: @event.ChatId,
            text: Message,
            cancellationToken: ct);
    }
}