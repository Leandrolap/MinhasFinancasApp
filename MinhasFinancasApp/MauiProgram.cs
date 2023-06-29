using LiteDB;
using Microsoft.Extensions.Logging;

namespace MinhasFinancasApp;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static MauiAppBuilder RegisterDatabaseRepositories(this MauiAppBuilder mauiAppBuilder)
	{
		MauiAppBuilder.Services.AddSingleton<LiteDatabase>(
			);
			retturn mauiAppBuider;
	}
}
