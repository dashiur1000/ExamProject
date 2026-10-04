using CriticalConsumer.Services;

using (var dbContext = new CriticalConsumer.Data.AppDbContext())
{
    dbContext.Database.EnsureCreated();
}

IRabbitConsumerService consumer = new RabbitConsumerService();
consumer.Start();