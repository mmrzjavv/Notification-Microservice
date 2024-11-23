using MassTransit;

namespace Api;

public static class MassTransitConfig
{
    public static void ConfigureMassTransit(this IServiceCollection services)
    {
        // پیکربندی MassTransit
        services.AddMassTransit(x =>
        {
            // اضافه کردن مصرف‌کننده‌ها
            x.AddConsumer<ProductNotificationConsumer>();

            // پیکربندی RabbitMQ
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq://localhost"); // آدرس RabbitMQ

                // تنظیمات صف
                cfg.ReceiveEndpoint("product-notifications", e =>
                {
                    e.ConfigureConsumer<ProductNotificationConsumer>(context);
                });
            });
        });

        // شروع MassTransit
        services.AddMassTransitHostedService(); // برای اجرای MassTransit در پس‌زمینه
    }
}
