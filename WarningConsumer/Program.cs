using Microsoft.EntityFrameworkCore;
using WarningConsumer.Services;

IElasticService elasticService = new ElasticService();

using (var dbContext = new WarningConsumer.Data.AppDbContext())
{
    dbContext.Database.EnsureCreated();
}

string logLevel = "Info";
string logMessage = $"Processed message ID: {"Unknown"}, Server: {""}, Value: {"in database"}";
await elasticService.SendLogAsync(logMessage, logLevel);


IRabbitConsumerService consumer = new RabbitConsumerService();
consumer.Start();