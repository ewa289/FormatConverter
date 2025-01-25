using Newtonsoft.Json;

namespace FormatConverter.Models;

public class FamilyMember
{
    public string Name { get; set; }

    [JsonProperty("born")]
    public string BirthYear { get; set; }
    public Address Address { get; set; }
    public Phone Phone { get; set; }
}
