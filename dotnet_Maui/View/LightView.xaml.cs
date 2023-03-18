namespace dotnet_Maui.ViewModel;

public partial class LightView : ContentPage
{
	LightView light;
	public LightView()
	{
		light = new LightView();
		BindingContext = light;
		InitializeComponent();
	}
}