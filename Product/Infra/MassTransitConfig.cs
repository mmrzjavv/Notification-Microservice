using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
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
                        h.Username("guest");
                        h.Password("guest");
                    });

                    // تعریف Retry Policy
                    cfg.UseRetry(retryConfig =>
                    {
                        retryConfig.Interval(3, TimeSpan.FromSeconds(5)); // 3 تلاش با فاصله 5 ثانیه
                        retryConfig.Handle<Exception>(); // می‌توانی نوع خاصی از Exception را مشخص کنی
                    });
                });
            });
        }
    }
}