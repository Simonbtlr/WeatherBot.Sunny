using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using WeatherBot.Sunny.Services.Telegram.Features.Events.ReceiveMessage;
using WeatherBot.Sunny.Services.Telegram.Features.Events.ReceiveSticker;
using WeatherBot.Sunny.Services.Telegram.Features.Events.UnknownUpdate;

namespace WeatherBot.Sunny.Application.Handler;

public sealed class UpdateHandler : IUpdateHandler
{
    private readonly IMediator _mediator;
    private readonly ILogger<UpdateHandler> _logger;

    public UpdateHandler(IMediator mediator, ILogger<UpdateHandler> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public async Task HandleUpdateAsync(
        ITelegramBotClient botClient,
        Update update,
        CancellationToken ct)
    {
        object request = update switch
        {
            { Message: { Text: { } text } message } => new ReceiveMessageEvent(message.Chat.Id, text),
            { Message: { Sticker: { } } message } => new ReceiveStickerEvent(message.Chat.Id),
            _ => new UnknownUpdateEvent(
                update.Message?.Chat.Id,
                update.Message?.MessageId,
                update.Type)
        };

        if (request is INotification)
            await _mediator.Publish(request, ct);
        else
            await _mediator.Send(request, ct);
    }

    public async Task HandlePollingErrorAsync(
        ITelegramBotClient botClient,
        Exception exception,
        CancellationToken ct)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n" +
                                                       $"[{apiRequestException.ErrorCode}]\n" +
                                                       $"{apiRequestException.Message}",
            _ => exception.ToString()
        };

        _logger.LogInformation($"HandleError: {errorMessage}");

        if (exception is RequestException)
            await Task.Delay(TimeSpan.FromSeconds(2), ct);
    }
}