using AutoFixture.Dsl;

namespace WeatherBot.Sunny.UnitTests.Common;

public class EventHandlerTestBase<TEvent, TEventHandler> : TypedTestBase<TEventHandler>
    where TEvent : INotification
{
    protected ICustomizationComposer<TEvent> Event => Fixture.Build<TEvent>();
}