using CsharpAPI.Repositories;
using Elastic.Clients.Elasticsearch;
using Microsoft.AspNetCore.Mvc;

namespace CsharpAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class exapController : ControllerBase
    {
        private readonly IExamRepo _examRepo;
        public exapController(IExamRepo examRepo)
        {
            _examRepo = examRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _examRepo.GetAllAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
