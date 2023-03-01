namespace dotnet_Maui.View;

public partial class WetterView : ContentPage
{
	public WetterView()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void BtnBackClick(object sender, EventArgs e)
    {
        // Erstellen einer neuen Instanz der WetterView-Klasse
        MainPage main = new MainPage();

        // Hinzufügen der WetterView-Instanz zur Navigationshierarchie
        await Navigation.PushAsync(main);
    }
}