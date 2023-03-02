using dotnet_Maui.Models;
using dotnet_Maui.Cert;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Text.Json;
using RestSharp;
using System.Net;

namespace dotnet_Maui.ViewModel
{
    class WetterViewModel : ViewModelBase
    {
        private Command _cmdBack { get; set; }
        private Command _cmdGetData { get; set; }

        public static string BaseAddress =
        DeviceInfo.Platform == DevicePlatform.Android ? "http://85.2.82.247:7080" : "http://85.2.82.247:7080";
        public static string TodoItemsUrl = $"{BaseAddress}/api/WeatherStation";



        private WeatherSationModel _weatherData = new WeatherSationModel();


        public WetterViewModel()
        {
            _cmdBack = new Command(ExecuteBack, CanExecuteBack);
            _cmdGetData = new Command(ExecuteGetData, CanExecuteGetData);
        }

        public WeatherSationModel WeatherData
        {
            get { return _weatherData; }
            set
            {
                if (value != _weatherData)
                {
                    SetProperty<WeatherSationModel>(ref _weatherData, value);
                }
            }
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
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                // Hier kannst du die Validierung des Serverzertifikats umgehen
                return true;
            };
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            HttpClient client = new HttpClient(handler);
            var request = new HttpRequestMessage(HttpMethod.Get, $"{TodoItemsUrl}/Datum?dayTime={WeatherData.daytime}");
            request.Headers.Add("Authorization", $"ApyKey " + "3dbae7eb-d351-4ed1-88b8-0e06aef9fd50");
            var response = await client.SendAsync(request);
            var statusCode = "Status Code: " + response.StatusCode;

            WeatherData = JsonSerializer.Deserialize<WeatherSationModel>(await response.Content.ReadAsStringAsync());
        }




        private bool CanExecuteGetData()
        {
            return true;

        }

        public Command CmdBack
        {
            get { return _cmdBack; }
            set { _cmdBack = value; }
        }

        public Command CmdGetData
        {
            get { return _cmdGetData; }
            set { _cmdGetData = value; }
        }
        private static HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            return new HttpClient(handler);
        }

    }
}
