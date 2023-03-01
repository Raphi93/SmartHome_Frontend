using dotnet_Maui.View;
using Microsoft.Maui.Controls;

namespace dotnet_Maui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void btnWetterClicked(object sender, EventArgs e)
    {
        // Erstellen einer neuen Instanz der WetterView-Klasse
        WetterView wetterView = new WetterView();

        // Hinzufügen der WetterView-Instanz zur Navigationshierarchie
        await Navigation.PushAsync(wetterView);
    }
}

