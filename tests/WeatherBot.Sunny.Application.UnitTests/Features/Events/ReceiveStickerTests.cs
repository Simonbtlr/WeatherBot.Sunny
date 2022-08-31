using FluentAssertions;
using WeatherBot.Sunny.Services.Telegram.Features.Events.ReceiveSticker;
using WeatherBot.Sunny.UnitTests.Common;

namespace WeatherBot.Sunny.Application.UnitTests.Features.Events;

public class ReceiveStickerTests : EventHandlerTestBase<ReceiveStickerEvent, ReceiveStickerEventHandler>
{
    [Fact]
    public async Task Bot_can_handle_sticker_messages()
    {
        // Arrange
        var notification = Event.Create();

        // Act
        var result = () => Sut.Handle(notification, Ct);

        // Assert
        await result
            .Should()
            .NotThrowAsync();
    }
}