using Microsoft.Extensions.Logging;
using Rzucidlo.ChristmasApp.BL;
using Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;
using Rzucidlo.ChristmasApp.UI.MVVM.Views;
using System.Reflection;
using System.Text.Json;
using CommunityToolkit.Maui;
using Syncfusion.Maui.Core.Hosting;
using Rzucidlo.ChristmasApp.Core.Interfaces;
using Rzucidlo.ChristmasApp.BL.Repository;

namespace Rzucidlo.ChristmasApp.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionCore()
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
        builder.Services.AddScoped<IDataRepository, DataRepository>();

        AddViewsAndViewModels(builder);

        return builder.Build();
    }

    private static void AddViewsAndViewModels(MauiAppBuilder builder)
    {
        builder.Services.AddTransient<ListChildrenViewModel>();
        builder.Services.AddTransient<ListChildrenView>();
        builder.Services.AddTransient<CreateChildrenView>();
        builder.Services.AddTransient<CreateChildrenViewModel>();
        builder.Services.AddTransient<UpdateChildrenView>();
        builder.Services.AddTransient<UpdateChildrenViewModel>();
        builder.Services.AddTransient<ChildrenDetailsView>();
        builder.Services.AddTransient<ChildrenDetailsViewModel>();
        builder.Services.AddTransient<CreatePresentView>();
        builder.Services.AddTransient<CreatePresentViewModel>();
        builder.Services.AddTransient<UpdatePresentView>();
        builder.Services.AddTransient<UpdatePresentViewModel>();
    }
}