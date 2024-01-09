using Microsoft.Extensions.Logging;
using Rzucidlo.ChristmasApp.BL;
using System.Reflection;
using System.Text.Json;

namespace Rzucidlo.ChristmasApp.UI
{
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
            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream("Rzucidlo.ChristmasApp.UI.appsettings.json");
            stream!.Position = 0;
            var appSettings = JsonSerializer.Deserialize<AppSettings>(stream);

            builder.Services.AddDAOServices(appSettings!.DAOLibraryPath);

            return builder.Build();
        }
    }
}