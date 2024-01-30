using Microsoft.EntityFrameworkCore;
using Rzucidlo.ChristmasApp.Core.Interfaces;
using Rzucidlo.ChristmasApp.Core.Models;
using Rzucidlo.ChristmasApp.DAO.Database;

namespace Rzucidlo.ChristmasApp.DAO.Handlers;

public sealed partial class DatabaseHandler : IDatabaseHandler
{
    private readonly ChristmasDbContext _christmasDbContext;

    public DatabaseHandler()
    {
        _christmasDbContext = new ChristmasDbContext();
    }

    public async Task<int> CreateChildren(IChildren childrenDto)
    {
        var result = await _christmasDbContext.Childrens.AddAsync(new Children
        { Name = childrenDto.Name, Address = childrenDto.Address, ChildrenBehaviourType = childrenDto.ChildrenBehaviourType, Age = childrenDto.Age });

        await _christmasDbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public Children? GetChildren(int childrenId)
    {
        var result = _christmasDbContext.Childrens.FirstOrDefault(c => c.Id == childrenId);

        return result;
    }

    public IReadOnlyList<Children> GetChildrens(int count, int skipValue)
        => _christmasDbContext.Childrens.Skip(skipValue).Take(count).Include(c => c.Presents).ToList();

    public IReadOnlyList<Children> GetAllChildren()
        => _christmasDbContext.Childrens.ToList();

    public async Task<bool> UpdateChildren(IChildren childrenDto, int childrenId)
    {
        var childrenToUpdate = _christmasDbContext.Childrens.FirstOrDefault(c => c.Id == childrenId);

        if (childrenToUpdate is null)
        {
            return false;
        }

        childrenToUpdate.Address = childrenDto.Address;
        childrenToUpdate.Age = childrenDto.Age;
        childrenToUpdate.Name = childrenDto.Name;
        childrenToUpdate.ChildrenBehaviourType = childrenDto.ChildrenBehaviourType;

        await _christmasDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteChildren(int childrenId)
    {
        var childrenToDelete = _christmasDbContext.Childrens.FirstOrDefault(c => c.Id == childrenId);

        if (childrenToDelete is null)
        {
            return false;
        }

        _christmasDbContext.Childrens.Remove(childrenToDelete);

        await _christmasDbContext.SaveChangesAsync();

        return true;
    }
}