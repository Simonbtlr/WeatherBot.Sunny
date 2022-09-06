using System;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WeatherBot.Sunny;

var host = Host.CreateDefaultBuilder()
    .ConfigureWebHostDefaults(builder =>
    {
        builder.UseStartup<Startup>()
            .ConfigureKestrel(serverOptions =>
                serverOptions.Listen(
                    address: IPAddress.Any, 
                    port: int.Parse(Environment.GetEnvironmentVariable("PORT") ?? string.Empty)));
    })
    .Build();

await host.RunAsync();