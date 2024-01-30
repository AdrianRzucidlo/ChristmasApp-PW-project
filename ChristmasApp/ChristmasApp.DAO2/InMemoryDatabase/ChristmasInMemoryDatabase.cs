using Rzucidlo.ChristmasApp.Core.Models;

namespace Rzucidlo.ChristmasApp.DAO2.InMemoryDatabase;

public sealed class ChristmasInMemoryDatabase
{
    public List<Children> Childrens { get; set; } = [];
    public List<Present> Presents { get; set; } = [];
}