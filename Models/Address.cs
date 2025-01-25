using Newtonsoft.Json;

namespace FormatConverter.Models;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }

    [JsonProperty("zip")]
    public string ZipCode { get; set; }
}
