using CSharpProducer.Models;

namespace CSharpProducer.Services
{
    public interface IDataReaderService
    {
        List<Exam> ReadJson(string path);
    }
}
