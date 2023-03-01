using Microsoft.Extensions.Configuration;

namespace dotnet_Maui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        var navigationPage = new NavigationPage(new MainPage());

        MainPage = navigationPage;
    }
}
