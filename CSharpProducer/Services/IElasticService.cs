using CSharpProducer.Models;

namespace CSharpProducer.Services
{
    public interface IElasticService
    {
        Task SendLogAsync(string message, string level);
    }
}