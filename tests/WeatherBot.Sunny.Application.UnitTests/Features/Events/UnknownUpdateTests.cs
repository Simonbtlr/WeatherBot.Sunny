using FluentAssertions;
using WeatherBot.Sunny.Services.Telegram.Features.Events.UnknownUpdate;
using WeatherBot.Sunny.UnitTests.Common;

namespace WeatherBot.Sunny.Application.UnitTests.Features.Events;

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