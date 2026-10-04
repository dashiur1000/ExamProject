
using CSharpProducer.Models;
using CSharpProducer.Services;

IDataReaderService dataReader = new DataReaderService();

IRabbitProducerService producer = new RabbitProducerService();

IElasticService elasticService = new ElasticService();

string jsonPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "data.json");
jsonPath = Path.GetFullPath(jsonPath);
if (!Directory.Exists(jsonPath))
{
    string logLevel ="Critical";
    string logMessage = $"Processed message ID: {jsonPath ?? "Unknown"}, Server: {jsonPath}, Value: {"json is not exists"}";

    await elasticService.SendLogAsync(logMessage, logLevel);
}


List<Exam> jsonMessages = dataReader.ReadJson(jsonPath);
foreach (Exam message in jsonMessages)
{
    producer.SendMessage(message);
    string logLevel = message.Value >= 90 ? "Critical" : "Warning";
    string logMessage = $"Processed message ID: {message.Id ?? "Unknown"}, Server: {message.Server}, Value: {message.Value}";

    await elasticService.SendLogAsync(logMessage, logLevel);
}
Console.WriteLine($"Finished JSON: {jsonMessages.Count} messages");

Console.WriteLine(
    "Producer finished"
);