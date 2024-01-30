using Microsoft.Extensions.DependencyInjection;
using Rzucidlo.ChristmasApp.BL.Providers;
using Rzucidlo.ChristmasApp.Core.Interfaces;

namespace Rzucidlo.ChristmasApp.BL;

public static class Registration
{
    public static IServiceCollection AddDAOServices(this IServiceCollection serviceCollection, string libraryPath)
    {
        var daoHandlerProvider = new DAOHandlerProvider();

        var databaseHandler = daoHandlerProvider.GetDaoProvider(libraryPath);

        serviceCollection.AddSingleton(typeof(IDatabaseHandler), databaseHandler);

        return serviceCollection;
    }
}