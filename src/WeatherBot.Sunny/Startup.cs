using DotNetEnv;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherBot.Sunny.Modules;

namespace WeatherBot.Sunny;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;
    
    public Startup(
        IConfiguration configuration, 
        IWebHostEnvironment env)
    {
        _configuration = configuration;
        _env = env;

        Env.Load();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddMediatorModule()
            .AddTelegramModule(_configuration);
    }

    public void Configure(IApplicationBuilder app)
    {
        if (_env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseRouting();
    }
}