using dotnet_Maui.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Essentials.Biometrics;
using System.Threading.Tasks;

namespace dotnet_Maui.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        private readonly Command _cmdBack;
        private Command _cmdSave;
        private Configuration _setting = new Configuration();

        public LoginViewModel()
        {
            _cmdBack = new Command(ExecuteBack);
            _cmdSave = new Command(ExecuteSave);
        }

        private async void ExecuteBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void ExecuteSave()
        {
            string name = Config.UserName;
            string passwd = Config.Password;

            try
            {
                Configuration conf = ConfigManager.LoadConfig();
                if (conf != null && !string.IsNullOrEmpty(conf.Url) && !string.IsNullOrEmpty(conf.UserUrl))
                {

                    var handler = new HttpClientHandler();
                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                    var client = new HttpClient(handler);


                    var request = new HttpRequestMessage(HttpMethod.Post, $"{conf.Url}{conf.UserUrl}");
                    request.Content = new StringContent(
                        JsonConvert.SerializeObject(new
                        {
                            name = name,
                            passwort = passwd
                        }),
                            Encoding.UTF8, "application/json");
                    var response = await client.SendAsync(request);

                    var statusCode = "Status Code: " + response.StatusCode;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        string apikey = data;
                        conf.ApiKey = apikey;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", $"Error: {response.ReasonPhrase}", "OK");
                    }
                    conf.UserName = name;
                    conf.Password = passwd;
                    ConfigManager.SaveConfig(conf);
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        public async Task<bool> AuthenticateWithBiometricsAsync()
        {
            if (Biometrics.IsSupportedAsync())
            {
                var result = await Biometrics.AuthenticateAsync("Authentifizierung mit Biometrie");
                if (result.Authenticated)
                {
                    // Authentifizierung erfolgreich
                    return true;
                }
                else
                {
                    // Authentifizierung fehlgeschlagen
                    return false;
                }
            }
            else
            {
                // Biometrie-Authentifizierung wird vom Gerät nicht unterstützt
                return false;
            }
        }

        public Command CmdSave => _cmdSave;

        public Configuration Config
        {
            get => _setting;
            set => SetProperty(ref _setting, value);
        }

        public Command CmdBack => _cmdBack;
    }
}
