using dotnet_Maui.ViewModel;
using System.Text.Json.Serialization;

namespace dotnet_Maui.Models
{
    public class WeatherSationModel : ViewModelBase
    {
        [JsonPropertyName("_id")]
        public string? _id { get; set; }

        [JsonPropertyName("temp")]
        public double? temp { get; set; }

        [JsonPropertyName("tempMin")]
        public double? tempMin { get; set; }

        [JsonPropertyName("tempMax")]      
        public double? tempMax { get; set; }

        [JsonPropertyName("wind")]    
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



        private string _dayTime = string.Empty;

        [JsonPropertyName("dayTime")]
        public string dayTime
        {
            get => _dayTime;
            set
            {
                if (_dayTime != value)
                {
                    SetProperty(ref _dayTime, value);
                }
            }
        }


    [JsonPropertyName("id")]
        public int? id { get; set; }

        [JsonPropertyName("sunDurSOP")]
        public int sunDurSOP { get; set; } = 0;

        [JsonPropertyName("rainDurSOP")]
        public int rainDurSOP { get; set; } = 0;
    }
}
