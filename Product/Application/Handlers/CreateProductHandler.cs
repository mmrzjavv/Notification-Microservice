using ClassLibrary1.Commands;
using ClassLibrary1.DTO;
using MassTransit;
using MediatR;

namespace ClassLibrary1.Handlers;

public class CreateProductHandler(IBus bus) : IRequestHandler<CreateProductCommand, bool>
{

    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // شبیه‌سازی ذخیره در دیتابیس
        Console.WriteLine($"Product '{request.Name}' with price {request.Price} added to the database.");

        // ایجاد پیام نوتیفیکیشن
        var message = new ProductNotificationMessage
        {
            ProductName = request.Name,
            Price = request.Price,
            AddedDate = DateTime.UtcNow
        };

        try
        {
            // ارسال پیام به RabbitMQ
            await bus.Publish(message, cancellationToken);
            Console.WriteLine("Notification published.");
            return true; // عملیات موفقیت‌آمیز بود
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to publish notification: {ex.Message}");
            return false; // عملیات با شکست مواجه شد
        }
    }
}