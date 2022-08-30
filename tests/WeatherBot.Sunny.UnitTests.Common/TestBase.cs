using Autofac.Extras.Moq;
using AutoFixture;
using Moq;

namespace WeatherBot.Sunny.UnitTests.Common;

public abstract class TestBase : IDisposable
{
    protected readonly Fixture Fixture;
    protected readonly AutoMock Mock;
    protected readonly CancellationToken Ct;

    protected TestBase()
    {
        Fixture = new Fixture();
        Mock = AutoMock.GetLoose();
        Ct = It.IsAny<CancellationToken>();
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            Mock.Dispose();
    }
}