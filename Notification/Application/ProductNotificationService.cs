using ClassLibrary1.DTO;

namespace Application;

public class ProductNotificationService
{
    public async Task ProcessNotification(ProductNotificationMessage message)
    {
        // پیاده‌سازی پردازش‌های مختلف (مثل ذخیره در پایگاه داده یا ارسال ایمیل و ...)
        Console.WriteLine($"Processing notification for product: {message.ProductName} with price: {message.Price}");
        await Task.CompletedTask;
    }
}