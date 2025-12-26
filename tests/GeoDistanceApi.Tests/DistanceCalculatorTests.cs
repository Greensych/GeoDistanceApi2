using GeoDistanceApi.Models;
using GeoDistanceApi.Services;

namespace GeoDistanceApi.Tests;

public class DistanceCalculatorTests
{
    private readonly DistanceCalculator _calc;

    public DistanceCalculatorTests()
    {
        _calc = new DistanceCalculator();
    }

    [Fact]
    public void SamePoint_ReturnsZero()
    {
        var moscow = new GeoCoordinate { Latitude = 55.7558, Longitude = 37.6173 };

        var result = _calc.CalculateDistance(moscow, moscow);

        Assert.Equal(0, result, 2);
    }

    [Fact]
    public void MoscowToSpb_ReturnsCorrectDistance()
    {
        // проверяем реальное расстояние
        var moscow = new GeoCoordinate { Latitude = 55.7558, Longitude = 37.6173 };
        var spb = new GeoCoordinate { Latitude = 59.9311, Longitude = 30.3609 };

        var dist = _calc.CalculateDistance(moscow, spb);

        // примерно 633 км
        Assert.True(dist > 630 && dist < 640);
    }

    [Fact]
    public void DistanceIsSymmetric()
    {
        var pointA = new GeoCoordinate { Latitude = 40.7128, Longitude = -74.0060 };
        var pointB = new GeoCoordinate { Latitude = 51.5074, Longitude = -0.1278 };

        var distAB = _calc.CalculateDistance(pointA, pointB);
        var distBA = _calc.CalculateDistance(pointB, pointA);

        Assert.Equal(distAB, distBA);
    }
}
