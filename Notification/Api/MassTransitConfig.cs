using MassTransit;

namespace Api
{
    public static class MassTransitConfig
    {
        public static void ConfigureMassTransit(this IServiceCollection services)
        {
       
            services.AddMassTransit(x =>
            {
               
                x.AddConsumer<ProductNotificationConsumer>();

             
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://localhost", h =>
                    {
                        h.Username("guest"); 
                        h.Password("guest"); 
                    });

                 
                    cfg.ReceiveEndpoint("product-notifications", e =>
                    {
                        e.ConfigureConsumer<ProductNotificationConsumer>(context);
                    });
                });
            });

         
            services.AddMassTransitHostedService();
        }
    }
}