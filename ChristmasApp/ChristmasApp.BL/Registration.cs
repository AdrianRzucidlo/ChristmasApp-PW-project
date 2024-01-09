using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Logging;
using Microsoft.Extensions.DependencyInjection;
using Rzucidlo.ChristmasApp.BL.Builders;
using Rzucidlo.ChristmasApp.BL.Providers;
using Rzucidlo.ChristmasApp.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rzucidlo.ChristmasApp.BL
{
    public static class Registration
    {
        public static IServiceCollection AddDAOServices(this IServiceCollection serviceCollection, string libraryPath)
        {
            var daoHandlerProvider = new DAOHandlerProvider();

            var databaseHandler = daoHandlerProvider.GetDaoProvider(libraryPath);

            serviceCollection.AddSingleton(typeof(IDatabaseProvider), databaseHandler);

            return serviceCollection;
        }
    }
}