using dotnet_Maui.HueRequest;
using dotnet_Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_Maui.ViewModel
{
    public class LightViewModel
    {

        public LightViewModel()
        {
            GetRaphi();
        }

        private async void GetRaphi()
        {
            GetRequest get = new GetRequest();
            string url = "https://ruphys.internet-box.ch/api/rUaGaEdYC0Woc3PeQBxC1sy2WRI0lqqAfd7j6fG2/groups/13/";
            HueLightsActionModel hue =  await get.GetMethod(url);
        }
    }
}
