
using MassTransit;
using Microsoft.Extensions.Logging;

public class ProductNotificationConsumer : IConsumer<ProductNotificationMessage.ProductNotificationMessage>
{
    private readonly ILogger<ProductNotificationConsumer> _logger;

    public ProductNotificationConsumer(ILogger<ProductNotificationConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<ProductNotificationMessage.ProductNotificationMessage> context)
    {
        var message = context.Message;

        _logger.LogInformation("Received Product Notification: {ProductName} - {ProductPrice}",
            message.ProductName, message.Price);

     
    }
}
