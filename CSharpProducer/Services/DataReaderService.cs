using CSharpProducer.Models;
using System.Text.Json;

namespace CSharpProducer.Services
{
    public class DataReaderService : IDataReaderService
    {
        public List<Exam> ReadJson(string path)
        {
            string json =
                File.ReadAllText(path);


            List<Exam>? messages =
                JsonSerializer.Deserialize<List<Exam>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );


            return messages ?? new List<Exam>();
        }
    }
}
