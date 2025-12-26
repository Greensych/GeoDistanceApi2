using GeoDistanceApi.Controllers;
using GeoDistanceApi.Models;
using GeoDistanceApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GeoDistanceApi.Tests;

public class DistanceControllerTests
{
    [Fact]
    public void Calculate_ValidRequest_ReturnsOk()
    {
        var mockCalc = new Mock<DistanceCalculator>();
        mockCalc.Setup(c => c.CalculateDistance(It.IsAny<GeoCoordinate>(), It.IsAny<GeoCoordinate>()))
                .Returns(150.5);

        var controller = new DistanceController(mockCalc.Object);
        var request = new DistanceRequest
        {
            From = new GeoCoordinate { Latitude = 55.0, Longitude = 37.0 },
            To = new GeoCoordinate { Latitude = 56.0, Longitude = 38.0 }
        };

        var result = controller.Calculate(request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<DistanceResponse>(okResult.Value);
        Assert.Equal(150.5, response.DistanceKm);
    }

    [Fact]
    public void Calculate_NullFrom_ReturnsBadRequest()
    {
        var calc = new DistanceCalculator();
        var controller = new DistanceController(calc);
        var request = new DistanceRequest { To = new GeoCoordinate { Latitude = 55, Longitude = 37 } };

        var result = controller.Calculate(request);

        Assert.IsType<BadRequestObjectResult>(result);
    }
}
