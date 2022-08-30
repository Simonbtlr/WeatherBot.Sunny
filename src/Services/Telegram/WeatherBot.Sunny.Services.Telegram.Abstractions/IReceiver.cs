using System.Threading;
using System.Threading.Tasks;

namespace WeatherBot.Sunny.Services.Telegram.Abstractions;

public interface IReceiver
{
    Task ReceiveAsync(CancellationToken ct);
}