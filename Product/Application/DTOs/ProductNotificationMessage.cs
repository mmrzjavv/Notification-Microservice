namespace ClassLibrary1.DTO;

public class ProductNotificationMessage
{
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime AddedDate { get; set; }
}