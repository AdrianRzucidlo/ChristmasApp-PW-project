using Rzucidlo.ChristmasApp.Core.Interfaces;
using Rzucidlo.ChristmasApp.Core.Models;
using Rzucidlo.ChristmasApp.DAO2.InMemoryDatabase;

namespace Rzucidlo.ChristmasApp.DAO2.Handlers;

public sealed partial class DatabaseHandler : IDatabaseHandler
{
    private readonly ChristmasInMemoryDatabase _christmasDatabase;

    public DatabaseHandler()
    {
        _christmasDatabase = new ChristmasInMemoryDatabase();
    }

    public Task<int> CreateChildren(IChildren childrenDto)
    {
        var children = new Children
        {
            Name = childrenDto.Name,
            Address = childrenDto.Address,
            ChildrenBehaviourType = childrenDto.ChildrenBehaviourType,
            Age = childrenDto.Age,
            Id = GetIdForChildren()
        };

        _christmasDatabase.Childrens.Add(children);

        return Task.FromResult(children.Id);
    }

    public Task<bool> DeleteChildren(int childrenId)
    {
        var children = _christmasDatabase.Childrens.FirstOrDefault(c => c.Id == childrenId);

        if (children is null)
        {
            return Task.FromResult(false);
        }

        _christmasDatabase.Childrens.Remove(children);

        return Task.FromResult(true);
    }

    public Children? GetChildren(int childrenId)
        => _christmasDatabase.Childrens.FirstOrDefault(c => c.Id == childrenId);

    public IReadOnlyList<Children> GetChildrens(int count, int skipValue)
        => _christmasDatabase.Childrens.Skip(skipValue).Take(count).ToList();

    public IReadOnlyList<Children> GetAllChildren()
        => _christmasDatabase.Childrens.ToList();

    public Task<bool> UpdateChildren(IChildren childrenDto, int childrenId)
    {
        var children = _christmasDatabase.Childrens.FirstOrDefault(c => c.Id == childrenId);

        if (children is null)
        {
            return Task.FromResult(false);
        }

        children.Address = childrenDto.Address;
        children.Age = childrenDto.Age;
        children.Name = childrenDto.Name;
        children.ChildrenBehaviourType = childrenDto.ChildrenBehaviourType;

        return Task.FromResult(true);
    }

    private int GetIdForChildren()
        => _christmasDatabase.Childrens.Any()
            ? (_christmasDatabase.Childrens.Max(c => c.Id) + 1)
            : 1;
}