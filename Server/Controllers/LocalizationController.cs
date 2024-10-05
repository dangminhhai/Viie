using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

[ApiController]
[Route("api/[controller]")]
public class LocalizationController : ControllerBase
{
    private readonly ILocaleStringResourceRepository _repository;

    public LocalizationController(ILocaleStringResourceRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{key}/{languageId:int}")]
    public ActionResult<string> GetString(string key, int languageId)
    {
        var resource = _repository.GetResource(key, languageId);
        return Ok(resource?.ResourceValue ?? key);
    }
}
