using GeoDistanceApi.Models;

namespace GeoDistanceApi.Services;

public class DistanceCalculator
{
    // радиус земли в км
    private const double R = 6371.0;

    public double CalculateDistance(GeoCoordinate from, GeoCoordinate to)
    {
        // переводим в радианы
        var lat1 = DegreesToRadians(from.Latitude);
        var lat2 = DegreesToRadians(to.Latitude);
        var dlat = DegreesToRadians(to.Latitude - from.Latitude);
        var dlon = DegreesToRadians(to.Longitude - from.Longitude);

        // формула гаверсинуса
        var a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                Math.Cos(lat1) * Math.Cos(lat2) *
                Math.Sin(dlon / 2) * Math.Sin(dlon / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return R * c;
    }

    private double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180;
    }
}
