using Rzucidlo.ChristmasApp.BL.Builders;
using Rzucidlo.ChristmasApp.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rzucidlo.ChristmasApp.BL.Providers
{
    public sealed class DAOHandlerProvider
    {
        public Type GetDaoProvider(string libraryPath)
        {
            var dllPath = ProjectBuilder.GetProjectDLL(libraryPath);

            var assembly = Assembly.UnsafeLoadFrom(dllPath);

            var type = typeof(IDatabaseProvider);

            var types = assembly.GetTypes();

            return assembly.GetTypes().FirstOrDefault(t => t.GetInterfaces().Contains(type))!;
        }
    }
}