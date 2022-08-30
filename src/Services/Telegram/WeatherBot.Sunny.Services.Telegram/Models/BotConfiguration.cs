namespace WeatherBot.Sunny.Services.Telegram.Models;

public class BotConfiguration
{
    public static readonly string Configuration = "BotConfiguration";

    public string BotToken { get; set; } = string.Empty;
}