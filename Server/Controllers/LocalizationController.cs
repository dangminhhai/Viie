using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationController : ControllerBase
    {
        private readonly ILocaleStringResourceRepository _repository;

        public LocalizationController(ILocaleStringResourceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{key}/{languageId}")]
        public async Task<IActionResult> GetString(string key, int languageId)
        {
            var value = await _repository.GetStringAsync(key, languageId);
            return Ok(value);
        }
    }
}
