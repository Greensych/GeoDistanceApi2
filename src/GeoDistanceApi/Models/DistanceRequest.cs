namespace GeoDistanceApi.Models;

public class DistanceRequest
{
    public GeoCoordinate? From { get; set; }
    public GeoCoordinate? To { get; set; }
}
