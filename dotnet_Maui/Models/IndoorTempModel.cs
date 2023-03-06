using dotnet_Maui.ViewModel;
using System.Text.Json.Serialization;

namespace dotnet_Maui.Models
{
    public class IndoorTempModel : ViewModelBase
    {

        [JsonPropertyName("_id")]
        public string? _id { get; set; }

        [JsonPropertyName("wallTemp")]
        public double? wallTemp { get; set; }

        [JsonPropertyName("floorTemp")]
        public double? floorTemp { get; set; }

        [JsonPropertyName("wallTempMax")]
        public double? wallTempMax { get; set; }

        [JsonPropertyName("floorTempMax")]
        public double? floorTempMax { get; set; }

        [JsonPropertyName("wallTempMin")]
        public double? wallTempMin { get; set; }

        [JsonPropertyName("floorTempMin")]
        public double? floorTempMin { get; set; }

        [JsonPropertyName("heizungSollte")]
        public double? heizungSollte { get; set; }

        [JsonPropertyName("dayTime")]
        public string? daytime { get; set; }

        [JsonPropertyName("id")]
        public int? id { get; set; }
    }
}
