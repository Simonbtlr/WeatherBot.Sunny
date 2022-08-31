using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace WeatherBot.Sunny.Application.Handler;

public sealed class Receiver : IReceiver
{
    private readonly ITelegramBotClient _botClient;
    private readonly IUpdateHandler _updateHandler;
    private readonly ILogger<IReceiver> _logger;

    public Receiver(
        ITelegramBotClient botClient,
        IUpdateHandler updateHandler,
        ILogger<IReceiver> logger)
    {
        _botClient = botClient;
        _updateHandler = updateHandler;
        _logger = logger;
    }

    public async Task ReceiveAsync(CancellationToken ct)
    {
        var options = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>(),
            ThrowPendingUpdates = true
        };

        var me = await _botClient.GetMeAsync(ct);
        _logger.LogInformation($"Start receiving updates from {me.Username}.");

        await _botClient.ReceiveAsync(
            updateHandler: _updateHandler,
            receiverOptions: options,
            cancellationToken: ct);
    }
}