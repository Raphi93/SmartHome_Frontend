using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_Maui.Models
{
    public class HueLightsModel
    {
        public HueLightsActionModel Action { get; set; }
    }

    public class HueLightsActionModel
    {
        public bool On { get; set; }
        public int Bri { get; set; }
        public int Hue { get; set; }
        public int Sat { get; set; }
        public string Effect { get; set; } = "none";
        public double[] Xy { get; set; }
        public int Ct { get; set; }
        public string Alert { get; set; } = "select";
        public string Colormode { get; set; }
    }
}
