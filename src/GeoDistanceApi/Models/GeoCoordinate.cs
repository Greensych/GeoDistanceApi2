using System.ComponentModel.DataAnnotations;

namespace GeoDistanceApi.Models;

public class GeoCoordinate
{
    [Range(-90, 90)]
    public double Latitude { get; set; }

    [Range(-180, 180)]
    public double Longitude { get; set; }
}
