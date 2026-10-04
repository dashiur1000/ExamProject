using CsharpAPI.Data;
using CsharpAPI.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;

namespace CsharpAPI.Repositories
{
    public class ExamRepo : IExamRepo
    {
        private readonly examDb _db;
        private readonly IDatabase _redisCache;
        public ExamRepo(examDb db)
        {
            _db = db;
            string redisHost = Environment.GetEnvironmentVariable("REDIS_HOST") ?? "localhost:6379";
            var redisConn = ConnectionMultiplexer.Connect(redisHost);
            _redisCache = redisConn.GetDatabase();
        }
        public async Task<List<Exam>> GetAllAsync()
        {
            string cacheKey = "all_criticals_exams";
            string? cachedData = await _redisCache.StringGetAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedData))
                return JsonSerializer.Deserialize<List<Exam>>(cachedData) ?? new List<Exam>();
            var examsFromDb = await _db.Criticals.ToListAsync();
            string serializedData = JsonSerializer.Serialize(examsFromDb);
            await _redisCache.StringSetAsync(cacheKey, serializedData, TimeSpan.FromMinutes(5));
            return examsFromDb;
        }
    }
}
