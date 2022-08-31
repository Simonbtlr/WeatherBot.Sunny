using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace WeatherBot.Sunny.Services.Telegram.Features.Events.UnknownUpdate;

public sealed class UnknownUpdateEventHandler : INotificationHandler<UnknownUpdateEvent>
{
    private const string Message = "I can't reply to messages like this yet:";
    private readonly ILogger<UnknownUpdateEventHandler> _logger;
    private readonly ITelegramBotClient _botClient;

    public UnknownUpdateEventHandler(ILogger<UnknownUpdateEventHandler> logger, ITelegramBotClient botClient)
    {
        _logger = logger;
        _botClient = botClient;
    }

    public async Task Handle(UnknownUpdateEvent notification, CancellationToken ct)
    {
        _logger.LogInformation($"Unknown update type: {notification.MessageType}");

        if (notification.ChatId is not { })
            return;

        await _botClient.SendTextMessageAsync(
            chatId: notification.ChatId,
            text: Message,
            replyToMessageId: notification.MessageId,
            cancellationToken: ct);
    }
}