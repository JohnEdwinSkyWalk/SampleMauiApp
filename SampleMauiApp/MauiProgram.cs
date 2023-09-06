using Microsoft.AspNetCore.Components.WebView.Maui;
using SampleMauiApp.Data;
using System.Net.Http;
using SampleMauiApp.Services;
using Microsoft.Extensions.Http;



namespace SampleMauiApp;

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
			});

		//builder.Services.AddHttpClient();

		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddHttpClient<IProductsService, ProductsService>(client =>
		{
			client.BaseAddress = new Uri("https://localhost:7241/");
		});

		return builder.Build();
	}
}
