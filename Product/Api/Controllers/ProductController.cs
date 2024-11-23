using ClassLibrary1.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductController(IMediator mediator) : ControllerBase
{
    // تزریق IMediator برای ارسال درخواست‌ها

    [HttpPost("create")]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        if (command == null)
        {
            return BadRequest("Invalid product data.");
        }

        // ارسال درخواست به هندلر
        var result = await mediator.Send(command);

        if (result)
        {
            return Ok(new { message = "Product created and notification sent." });
        }
        else
        {
            return StatusCode(500, new { message = "Failed to create product or send notification." });
        }
    }
}