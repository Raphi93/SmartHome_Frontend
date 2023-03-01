using dotnet_Maui.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace dotnet_Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//var a = Assembly.GetExecutingAssembly();
		//using var stream = a.GetManifestResourceStream("C:\\Users\\raphi\\Desktop\\appsettings.json");

		//var config = new ConfigurationBuilder()
		//			.AddJsonStream(stream)
		//			.Build();


		//builder.Configuration.AddConfiguration(config);
		//builder.Services.AddTransient<MainViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
