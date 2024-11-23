using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Infra;

public static class MassTransitConfig
{
    public static void AddMassTransitConfiguration(this IServiceCollection services, string rabbitMqHost)
    {
        services.AddMassTransit(config =>
        {
            config.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqHost, h =>
                {
                    h.Username("guest");  // یوزرنیم پیش‌فرض
                    h.Password("guest");  // پسورد پیش‌فرض
                });
            });
        });
    }
}