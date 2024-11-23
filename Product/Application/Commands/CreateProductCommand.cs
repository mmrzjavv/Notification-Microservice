using MediatR;

namespace ClassLibrary1.Commands;

public class CreateProductCommand(string name, decimal price) : IRequest<bool>
{
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
}