using Infra; 
using MediatR; 
using Microsoft.OpenApi.Models;
using ClassLibrary1.Handlers;

var builder = WebApplication.CreateBuilder(args);

// اضافه کردن خدمات MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductHandler).Assembly));

// تنظیم MassTransit
builder.Services.AddMassTransitConfiguration("rabbitmq://localhost");

// اضافه کردن کنترلرها و سرویس‌ها
builder.Services.AddControllers();

// تنظیمات Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product API", Version = "v1" });
});

var app = builder.Build();

// فعال کردن Swagger در محیط توسعه
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
    });
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();