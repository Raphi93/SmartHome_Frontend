using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using dotnet_Maui.Models;
using Microsoft.Maui.Controls;

namespace dotnet_Maui.ViewModel
{
    public class WetterViewModel : ViewModelBase
    {
        private readonly Command _cmdBack;
        private readonly Command _cmdGetData;
        private ImageSource _wetterDatenImageSource;


        private WeatherSationModel _weatherData = new WeatherSationModel();

        public WetterViewModel()
        {
            _cmdBack = new Command(ExecuteBack, CanExecuteBack);
            _cmdGetData = new Command(ExecuteGetData, CanExecuteGetData);
            WetterDatenImageSource = ImageSource.FromFile(DefaultImageSource);
        }

        private const string DefaultImageSource = "keineahnung.jpg";


        public ImageSource WetterDatenImageSource
        {
            get => _wetterDatenImageSource;
            set
            {
                _wetterDatenImageSource = value;
                OnPropertyChanged(nameof(WetterDatenImageSource));
            }
        }

        public WeatherSationModel WeatherData
        {
            get => _weatherData;
            set => SetProperty(ref _weatherData, value);
        }

        private async void ExecuteBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private bool CanExecuteBack()
        {
            return true;
        }

        private async void ExecuteGetData()
        {
            try
            {

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                var client = new HttpClient(handler);


                string datum = WeatherData.dayTime.ToString();
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://ruphys.internet-box.ch:7081/api/WeatherStation/Datum?dayTime={datum}");
                request.Headers.Add("ApiKey", "3dbae7eb-d351-4ed1-88b8-0e06aef9fd50");

                var response = await client.SendAsync(request);

                var statusCode = "Status Code: " + response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonSerializer.Deserialize<WeatherSationModel>(data);

                    double temp = (double)(weatherData.temp);
                    weatherData.temp = Math.Round(temp, 1);
                    double temMax = (double)(weatherData.tempMax);
                    weatherData.tempMax = Math.Round(temMax, 1);
                    double temMin = (double)(weatherData.tempMin);
                    weatherData.tempMin = Math.Round(temMin, 1);

                    double wind = (double)(weatherData.wind);
                    weatherData.wind = Math.Round(wind, 1);
                    double windMax = (double)(weatherData.windMax);
                    weatherData.windMax = Math.Round(windMax, 1);
                    double windMin = (double)(weatherData.windMin);
                    weatherData.windMin = Math.Round(windMin, 1);

                    double humi = (double)(weatherData.humidity);
                    weatherData.humidity = Math.Round(humi, 1);
                    double humiMax = (double)(weatherData.humidityMax);
                    weatherData.humidityMax = Math.Round(humiMax, 1);
                    double humiMin = (double)(weatherData.humidityMin);
                    weatherData.humidityMin = Math.Round(humiMin, 1);

                    double rain = (double)(weatherData.rain);
                    weatherData.rain = Math.Round(rain, 1);
                    double sun = (double)(weatherData.sunDuration);
                    weatherData.sunDuration = Math.Round(sun, 1);

                    WeatherData = weatherData;

                    WeatherDataImages();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"Error: {response.ReasonPhrase}", "OK");
                    WetterDatenImageSource = ImageSource.FromFile(DefaultImageSource);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
                WetterDatenImageSource = ImageSource.FromFile("rip.jpg");
            }
        }

        private void WeatherDataImages()
        {
            double temp = WeatherData.temp.Value;
            double wind = WeatherData.wind.Value;
            double humi = WeatherData.humidity.Value;

            if ((temp > 30) && (humi > 60) && (wind < 10))
            {
                WetterDatenImageSource = ImageSource.FromFile("hot.jpg");
            }
            else if ((temp > 30) && (humi > 60))
            {
                WetterDatenImageSource = ImageSource.FromFile("crazy.png");
            }
            else if ((temp > 30) && (humi < 60))
            {
                WetterDatenImageSource = ImageSource.FromFile("crazy.png");
            }
            else if ((temp < 30) && (temp > 20))
            {
                WetterDatenImageSource = ImageSource.FromFile("good.jpg");
            }
            else if ((temp < 20) && (temp > 10))
            {
                WetterDatenImageSource = ImageSource.FromFile("cool.jgp");
            }
            else if ((temp < 10) && (temp > 0))
            {
                WetterDatenImageSource = ImageSource.FromFile("cold.png");
            }
            else if (temp < 0)
            {
                WetterDatenImageSource = ImageSource.FromFile("nei.png");
            }
            else
            {
                WetterDatenImageSource = ImageSource.FromFile(DefaultImageSource);
            }
        }

        private bool CanExecuteGetData()
        {
            return true;
        }

        public Command CmdBack => _cmdBack;

        public Command CmdGetData => _cmdGetData;
    }
}
