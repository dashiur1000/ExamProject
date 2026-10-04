using CSharpProducer.Models;

namespace CSharpProducer.Services
{
    public interface IRabbitProducerService
    {
        void SendMessage(Exam message);
    }
}
