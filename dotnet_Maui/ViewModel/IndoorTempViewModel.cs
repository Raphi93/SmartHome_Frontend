using dotnet_Maui.Models;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace dotnet_Maui.ViewModel
{
    public class IndoorTempViewModel : ViewModelBase
    {
        private IndoorTempModel _model = new IndoorTempModel();
        private Command _cmdSave;
        private Command _cmdBack;

        public IndoorTempViewModel()
        {
            _cmdBack = new Command(ExecuteBack);
            _cmdSave = new Command(ExecuteSave);
            ExecuteGet();
        }

        private async void ExecuteGet()
        {
            DateTime now = DateTime.Now;
            string dayTime = now.ToString("d.M.yyyy");
            try
            {
                Configuration conf = ConfigManager.LoadConfig();
                if (conf != null && !string.IsNullOrEmpty(conf.Url) && !string.IsNullOrEmpty(conf.UserUrl))
                {
                    var handler = new HttpClientHandler();
                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                    var client = new HttpClient(handler);

                    var request = new HttpRequestMessage(HttpMethod.Get, $"{conf.Url}{conf.HeizungUrl}{dayTime}");
                    request.Headers.Add("ApiKey", conf.ApiKey);

                    var response = await client.SendAsync(request);

                    var statusCode = "Status Code: " + response.StatusCode;

                    if (response.IsSuccessStatusCode)
                    {
                        var datas = await response.Content.ReadAsStringAsync();
                        var tempData = JsonSerializer.Deserialize<IndoorTempModel>(datas);
                        double fTMa = (double)tempData.floorTempMax;
                        tempData.floorTempMax = Math.Round(fTMa, 1); 
                        double fTMi = (double)tempData.floorTempMin;
                        tempData.floorTempMin = Math.Round(fTMi, 1);
                        double wTMa = (double)tempData.wallTempMax;
                        tempData.wallTempMax = Math.Round(wTMa, 1);
                        double wTMi = (double)tempData.wallTempMin;
                        tempData.wallTempMin = Math.Round(wTMi, 1);
                        IndoorData = tempData;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", $"Error: {response.ReasonPhrase}", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }


        private async void ExecuteSave()
        {
            DateTime now = DateTime.Now;
            string dayTime = now.ToString("d.M.yyyy");

            try
            {
                Configuration conf = ConfigManager.LoadConfig();
                if (conf != null && !string.IsNullOrEmpty(conf.Url) && !string.IsNullOrEmpty(conf.UserUrl))
                {

                    var handler = new HttpClientHandler();
                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                    var client = new HttpClient(handler);


                    var json = JsonSerializer.Serialize(IndoorData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var request = new HttpRequestMessage(HttpMethod.Put, $"{conf.Url}{conf.HeizungUrl}{dayTime}");
                    request.Headers.Add("ApiKey", conf.ApiKey);
                    request.Content = content;

                    var response = await client.SendAsync(request);

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }



        private async void ExecuteBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public IndoorTempModel IndoorData
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }
        public Command CmdBack => _cmdBack;
        public Command CmdSave => _cmdSave;
    }
}
