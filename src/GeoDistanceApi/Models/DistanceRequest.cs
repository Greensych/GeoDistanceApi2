using System.ComponentModel.DataAnnotations;

namespace GeoDistanceApi.Models;

public class DistanceRequest
{
    [Required]
    public GeoCoordinate? From { get; set; }

    [Required]
    public GeoCoordinate? To { get; set; }
}
