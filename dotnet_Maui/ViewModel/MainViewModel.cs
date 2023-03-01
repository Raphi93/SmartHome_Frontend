using dotnet_Maui.View;
using dotnet_Maui.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_Maui.ViewModel
{
    public class MainViewModel
    {
        private Command _cmdWeather { get; set; }
        private Command _cmdGetDate { get; set; }
        IConfiguration configuration;

        public MainViewModel()
        {
            _cmdWeather = new Command(ExecuteWetter, CanExecuteWetter);
            _cmdGetDate = new Command(ExecuteGetDate, CanExecuteGetDate);
        }

        public MainViewModel(IConfiguration config)
            :base()
        {
            configuration = config;
        }

        private async void ExecuteWetter()
        {
            // Erstellen einer neuen Instanz der WetterView-Klasse
            WetterView wetterView = new WetterView();

            // Navigieren zur WetterView
            await Application.Current.MainPage.Navigation.PushAsync(wetterView);
        }

        private bool CanExecuteWetter()
        {
            //var settings = new Settings();
            //var section = configuration.GetSection("Settings");
            //if (section != null)
            //{
            //    settings.ApiKey = section["ApiKey"];
            //}



            //var apiKey = settings.ApiKey;

            //if (apiKey != "")
            //{
                return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        private void ExecuteGetDate(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteGetDate(object arg)
        {
            return true;
        }

        public Command CmdWeather
        {
            get { return _cmdWeather; }
            set { _cmdWeather = value; }
        }
    }
}
