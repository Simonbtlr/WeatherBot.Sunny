using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Telegram.Bot;

namespace WeatherBot.Sunny.Services.Telegram.Features.Events.ReceiveMessage;

public sealed class ReceiveMessageEventHandler : INotificationHandler<ReceiveMessageEvent>
{
    private readonly ITelegramBotClient _botClient;

    public ReceiveMessageEventHandler(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task Handle(
        ReceiveMessageEvent notification,
        CancellationToken ct)
    {
        await _botClient.SendTextMessageAsync(
            chatId: notification.ChatId,
            text: notification.Text,
            cancellationToken: ct);
    }
}