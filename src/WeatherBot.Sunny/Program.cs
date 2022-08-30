using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WeatherBot.Sunny;

var host = Host.CreateDefaultBuilder()
    .ConfigureWebHostDefaults(builder =>
        builder.UseStartup<Startup>())
    .Build();

await host.RunAsync();