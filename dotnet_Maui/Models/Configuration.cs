using System.Text.Json;
using dotnet_Maui.ViewModel;

namespace dotnet_Maui.Models
{
    public class Configuration : ViewModelBase
    {
        private string _apiKey = string.Empty;
        public string ApiKey
        {
            get => _apiKey;
            set
            {
                if (_apiKey != value)
                {
                    SetProperty(ref _apiKey, value);
                }
            }
        }

        private string _url = string.Empty;
        public string Url
        {
            get => _url;
            set
            {
                if (_url != value)
                {
                    SetProperty(ref _url, value);
                }
            }
        }

        private string _weatherUrl = string.Empty;
        public string WeatherUrl
        {
            get => _weatherUrl;
            set
            {
                if (_weatherUrl != value)
                {
                    SetProperty(ref _weatherUrl, value);
                }
            }
        }

        private string _heizungUrl = string.Empty;
        public string HeizungUrl
        {
            get => _heizungUrl;
            set
            {
                if (_heizungUrl != value)
                {
                    SetProperty(ref _heizungUrl, value);
                }
            }
        }

        private string _userUrl = string.Empty;
        public string UserUrl
        {
            get => _userUrl;
            set
            {
                if (_userUrl != value)
                {
                    SetProperty(ref _userUrl, value);
                }
            }
        }

        private string _userName = string.Empty;
        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    SetProperty(ref _userName, value);
                }
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    SetProperty(ref _password, value);
                }
            }
        }
    }

    public static class ConfigManager
    {
        private static string configPath = Path.Combine(FileSystem.AppDataDirectory, "config.json");

        public static Configuration LoadConfig()
        {
            if (File.Exists(configPath))
            {
                string jsonString = File.ReadAllText(configPath);
                return JsonSerializer.Deserialize<Configuration>(jsonString);
            }
            else
            {
                return new Configuration();
            }
        }

        public static void SaveConfig(Configuration config)
        {
            string jsonString = JsonSerializer.Serialize(config);
            File.WriteAllText(configPath, jsonString);
        }
    }
}
