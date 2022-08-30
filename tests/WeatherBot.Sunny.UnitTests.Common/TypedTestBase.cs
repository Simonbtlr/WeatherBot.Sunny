namespace WeatherBot.Sunny.UnitTests.Common;

public class TypedTestBase<T> : TestBase
{
    protected T Sut => Mock.Create<T>();
}