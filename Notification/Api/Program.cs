using Api;

var builder = WebApplication.CreateBuilder(args);

// اضافه کردن سرویس‌ها به کانتینر
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// اضافه کردن پیکربندی MassTransit
builder.Services.ConfigureMassTransit(); // استفاده از متد پیکربندی MassTransit

var app = builder.Build();

// پیکربندی Swagger و استفاده از آن در محیط توسعه
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// استفاده از HTTPS
app.UseHttpsRedirection();

// تنظیمات نقاط پایانی (Endpoints)
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}