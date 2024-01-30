using Rzucidlo.ChristmasApp.BL.Builders;
using Rzucidlo.ChristmasApp.Core.Interfaces;
using System.Reflection;

namespace Rzucidlo.ChristmasApp.BL.Providers;

public sealed class DAOHandlerProvider
{
    public Type GetDaoProvider(string libraryPath)
    {
        var dllPath = ProjectBuilder.GetProjectDLL(libraryPath);

        var assembly = Assembly.UnsafeLoadFrom(dllPath);

        var type = typeof(IDatabaseHandler);

        var types = assembly.GetTypes();

        return assembly.GetTypes().FirstOrDefault(t => t.GetInterfaces().Contains(type))!;
    }
}