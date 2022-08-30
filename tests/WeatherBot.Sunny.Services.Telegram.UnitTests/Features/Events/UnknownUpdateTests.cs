using FluentAssertions;
using WeatherBot.Sunny.Services.Telegram.Features.Events.ReceiveMessage;
using WeatherBot.Sunny.Services.Telegram.Features.Events.ReceiveStiker;
using WeatherBot.Sunny.Services.Telegram.Features.Events.UnknownUpdate;
using WeatherBot.Sunny.UnitTests.Common;

namespace WeatherBot.Sunny.Services.Telegram.UnitTests.Features.Events;

public class UnknownUpdateTests : EventHandlerTestBase<UnknownUpdateEvent, UnknownUpdateEventHandler>
{
    [Fact]
    public async Task Bot_can_handle_unknown_messages()
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