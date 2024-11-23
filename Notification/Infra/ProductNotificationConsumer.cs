using Core.DTOs;
using MassTransit;
using Microsoft.Extensions.Logging;

public class ProductNotificationConsumer : IConsumer<ProductNotificationMessage>
{
    private readonly ILogger<ProductNotificationConsumer> _logger;

    // دریافت ILogger برای لاگ‌گذاری
    public ProductNotificationConsumer(ILogger<ProductNotificationConsumer> logger)
    {
        _logger = logger;
    }

    // پیاده‌سازی متد Consume
    public async Task Consume(ConsumeContext<ProductNotificationMessage> context)
    {
        // پیام دریافتی
        var message = context.Message;

        // لاگ‌گذاری پیامی که دریافت شده
        _logger.LogInformation("Received Product Notification: {ProductName} - {ProductPrice}",
            message.ProductName, message.Price);

        // اینجا هر کاری که با پیام باید انجام شود، انجام می‌دهیم.
        // برای مثال می‌توانید داده‌ها را پردازش کنید یا ذخیره کنید.
    }
}
