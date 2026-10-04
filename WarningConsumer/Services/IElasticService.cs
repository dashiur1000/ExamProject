namespace WarningConsumer.Services
{
    public interface IElasticService
    {
        Task SendLogAsync(string message, string level);
    }
}
