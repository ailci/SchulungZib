using Application.Contracts.Services;
using Application.ViewModels.Qotd;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QotdController(ILogger<QotdController> logger, IQotdService qotdService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<QuoteOfTheDayViewModel>> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");

        return Ok(await qotdService.GetQuoteOfTheDayAsync());
    }
}