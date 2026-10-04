
using CSharpProducer.Models;
using CSharpProducer.Services;

IDataReaderService dataReader =
    new DataReaderService();


IRabbitProducerService producer =
    new RabbitProducerService();

string jsonPath = Path.Combine(
    AppContext.BaseDirectory, "..", "..", "Data", "data.json");
jsonPath = Path.GetFullPath(jsonPath);

List<Exam> jsonMessages = dataReader.ReadJson(jsonPath);
foreach (Exam message in jsonMessages)
{
    producer.SendMessage(message);
}
Console.WriteLine($"Finished JSON: {jsonMessages.Count} messages");

Console.WriteLine(
    "Producer finished"
);