using dotnet_Maui.View;
using dotnet_Maui.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Controls;

namespace dotnet_Maui;

public partial class MainPage : ContentPage
{

    private MainViewModel viewModel;

    public MainPage()
    {
        InitializeComponent();
        viewModel = new MainViewModel();
        BindingContext = viewModel;
        NavigationPage.SetHasNavigationBar(this, false);

        // Set a string value:
        Preferences.Default.Set("ApiKey", "test");

        // Set an numerical value:
        Preferences.Default.Set("Url", "Htpps://");

        // Set a boolean value:
        Preferences.Default.Set("LinkWeather", "/WeatherStation");
    }

}

