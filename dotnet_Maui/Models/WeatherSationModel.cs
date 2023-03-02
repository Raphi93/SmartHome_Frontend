using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dotnet_Maui.Models
{
    public class WeatherSationModel
    {
        [JsonPropertyName("_id")]
        public string? _id { get; set; }

        [JsonPropertyName("temp")]
        public double? temp { get; set; }

        [JsonPropertyName("tempMin")]
        public double? tempMin { get; set; }

        [JsonPropertyName("TempMax")]      
        public double? tempMax { get; set; }

        [JsonPropertyName("Wind")]    
        public double? wind { get; set; }

        [JsonPropertyName("windMin")]
        public double? windMin { get; set; }

        [JsonPropertyName("windMax")]
        public double? windMax { get; set; }

        [JsonPropertyName("humidityMax")]
        public double? humidityMax { get; set; }


        [JsonPropertyName("humidityMin")]
        public double? humidityMin { get; set; }


        [JsonPropertyName("humidity")]
        public double? humidity { get; set; }

        [JsonPropertyName("rain")]
        public double? rain { get; set; }

        [JsonPropertyName("raining")]
        public bool? raining { get; set; }

        [JsonPropertyName("sunDuration")]
        public double? sunDuration { get; set; }

        [JsonPropertyName("dayTime")]
        public string? daytime { get; set; }

        [JsonPropertyName("id")]
        public int? id { get; set; }

        [JsonPropertyName("sunDurSOP")]
        public int sunDurSOP { get; set; } = 0;

        [JsonPropertyName("rainDurSOP")]
        public int rainDurSOP { get; set; } = 0;
    }
}
