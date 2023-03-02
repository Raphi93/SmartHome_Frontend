using Microsoft.Extensions.Configuration;
using System.Net;

namespace dotnet_Maui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        var navigationPage = new NavigationPage(new MainPage());

        // Deaktiviere Zertifikatsvalidierung
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

        MainPage = navigationPage;
    }
}
