using dotnet_Maui.ViewModel;

namespace dotnet_Maui.View;

public partial class IndoorTempView : ContentPage
{
	private IndoorTempViewModel viewModel;
	public IndoorTempView()
	{
		viewModel= new IndoorTempViewModel();
        BindingContext = viewModel;
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
}