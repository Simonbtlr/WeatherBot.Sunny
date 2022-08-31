using System.Threading;
using System.Threading.Tasks;

namespace WeatherBot.Sunny.Application;

public interface IReceiver
{
    Task ReceiveAsync(CancellationToken ct);
}