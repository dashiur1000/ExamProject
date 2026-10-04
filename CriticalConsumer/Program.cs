using CriticalConsumer.Services;
using Microsoft.EntityFrameworkCore;

using (var dbContext = new CriticalConsumer.Data.AppDbContext())
{
    dbContext.Database.ExecuteSqlRaw(@"
        CREATE TABLE IF NOT EXISTS Criticals (
            Id VARCHAR(255) NOT NULL PRIMARY KEY,
            Server VARCHAR(255) NULL,
            Type VARCHAR(255) NULL,
            Value INT NOT NULL,
            Status VARCHAR(255) NULL
        );");

    Console.WriteLine("Database and 'Criticals' table verified/created successfully.");
}

IRabbitConsumerService consumer = new RabbitConsumerService();
consumer.Start();