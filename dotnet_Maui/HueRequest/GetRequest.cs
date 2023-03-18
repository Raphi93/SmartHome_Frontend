using dotnet_Maui.Models;
using System.Text.Json;

namespace dotnet_Maui.HueRequest
{
    public class GetRequest
    {
        public async Task<HueLightsActionModel> GetMethod(string url)
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                var client = new HttpClient(handler);

                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}");

                var response = await client.SendAsync(request);

                var statusCode = "Status Code: " + response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    var datas = await response.Content.ReadAsStringAsync();
                    var tempData = JsonSerializer.Deserialize<HueLightsModel>(datas);
                    return tempData.Action;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"Error: {response.ReasonPhrase}", "OK");
                }

                return null;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error: {ex.Message}", "OK");
                return null;
            }
        }
    }
}
