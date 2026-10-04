using CsharpAPI.Models;

namespace CsharpAPI.Repositories
{
    public interface IExamRepo
    {
        Task<List<Exam>> GetAllAsync();
    }
}
