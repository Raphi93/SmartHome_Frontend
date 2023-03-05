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
        private Command _cmdSetting { get; set; }
        private Command _cmdLogin { get; set; }
        private string _loginLogout { get; set; }

        public MainViewModel()
        {
            _cmdWeather = new Command(ExecuteWetter, CanExecuteWetter);
            _cmdLogin = new Command(ExecuteLogin);
            _cmdSetting = new Command(ExecuteSetting);
            LoginLogoutControll();
        }

        private async void ExecuteWetter()
        {
            // Erstellen einer neuen Instanz der WetterView-Klasse
            WetterView wetterView = new WetterView();

            // Navigieren zur WetterView
            await Application.Current.MainPage.Navigation.PushAsync(wetterView);
        }

        public void LoginLogoutControll()
        {
            Configuration config = ConfigManager.LoadConfig();
            string apiKey = config.ApiKey;

            if (!string.IsNullOrEmpty(apiKey))
            {
                LoginLogout = "Logout";
            }
            else
            {
                LoginLogout = "Login";
            }
        }

        private async void ExecuteLogin()
        {
            Configuration config = ConfigManager.LoadConfig();
            string apiKey = config.ApiKey;
            if (apiKey == "")
            {
                LoginView login = new LoginView();
                await Application.Current.MainPage.Navigation.PushAsync(login);
            }
            else
            {
                config.ApiKey = "";
                ConfigManager.SaveConfig(config);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        private bool CanExecuteWetter()
        {
            Configuration config = ConfigManager.LoadConfig();
            string apiKey = config.ApiKey;

            if (apiKey != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void ExecuteSetting()
        {
            SettingView setting = new SettingView();
            await Application.Current.MainPage.Navigation.PushAsync(setting);
        }

        public Command CmdWeather
        {
            get { return _cmdWeather; }
            set { _cmdWeather = value; }
        }

        public Command CmdSetting
        {
            get { return _cmdSetting; }
            set { _cmdSetting = value; }
        }

        public Command CmdLogin
        {
            get { return _cmdLogin; }
            set { _cmdLogin = value; }
        }

        public string LoginLogout
        {
            get { return _loginLogout; }
            set { _loginLogout = value; }
        }
    }
}
