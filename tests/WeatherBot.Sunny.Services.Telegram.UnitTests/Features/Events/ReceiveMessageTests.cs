using FluentAssertions;
using WeatherBot.Sunny.Services.Telegram.Features.Events.ReceiveMessage;
using WeatherBot.Sunny.UnitTests.Common;

namespace WeatherBot.Sunny.Services.Telegram.UnitTests.Features.Events;

public class ReceiveMessageTests : EventHandlerTestBase<ReceiveMessageEvent, ReceiveMessageEventHandler>
{
    [Fact]
    public async Task Bot_can_handle_text_messages()
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