using System.Text.Json.Serialization;

namespace Karamem0.SampleApplication.Models;

public class Reservation
{

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

}
