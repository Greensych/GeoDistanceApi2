using Microsoft.AspNetCore.Mvc;
using GeoDistanceApi.Models;
using GeoDistanceApi.Services;

namespace GeoDistanceApi.Controllers;

[ApiController]
[Route("api/distance")]
public class DistanceController : ControllerBase
{
    private readonly DistanceCalculator _calculator;

    public DistanceController(DistanceCalculator calculator)
    {
        _calculator = calculator;
    }

    [HttpPost("calculate")]
    public IActionResult Calculate([FromBody] DistanceRequest request)
    {
        if (request.From == null || request.To == null)
            return BadRequest("Coordinates required");

        var distance = _calculator.CalculateDistance(request.From, request.To);

        return Ok(new DistanceResponse { DistanceKm = distance });
    }
}
