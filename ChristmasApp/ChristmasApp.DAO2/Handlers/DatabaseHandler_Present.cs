using Rzucidlo.ChristmasApp.Core.Interfaces;
using Rzucidlo.ChristmasApp.Core.Models;

namespace Rzucidlo.ChristmasApp.DAO2.Handlers;

public sealed partial class DatabaseHandler : IDatabaseHandler
{
    public Task<bool> CreatePresent(IPresent createPresentDto, int childrenId)
    {
        var children = _christmasDatabase.Childrens.FirstOrDefault(x => x.Id == childrenId);

        if (children is null)
        {
            return Task.FromResult(false);
        }

        var present = new Present { Name = createPresentDto.Name };
        present.Id = GetIdForPresent();

        present.Children = children;
        children.Presents.Add(present);

        _christmasDatabase.Presents.Add(present);

        return Task.FromResult(true);
    }

    public Task<bool> DeletePresent(int presentId, int childrenId)
    {
        var children = _christmasDatabase.Childrens.FirstOrDefault(x => x.Id == childrenId);

        if (children is null)
        {
            return Task.FromResult(false);
        }

        var present = _christmasDatabase.Presents.FirstOrDefault(x => x.Id == presentId);
        var childrenPresent = children.Presents.FirstOrDefault(p => p.Id == presentId);

        if (present is null || childrenPresent is null)
        {
            return Task.FromResult(false);
        }

        children.Presents.Remove(present);
        _christmasDatabase.Presents.Remove(present);

        return Task.FromResult(true);
    }

    public Task<bool> UpdatePresent(IPresent updatePresentDto, int childrenId, int presentId)
    {
        var children = _christmasDatabase.Childrens.FirstOrDefault(c => c.Id == childrenId);
        if (children is null)
        {
            return Task.FromResult(false);
        }

        var childrenPresent = children.Presents.FirstOrDefault(p => p.Id == presentId);
        var present = _christmasDatabase.Presents.FirstOrDefault(p => p.Id == presentId);

        if (childrenPresent is null || present is null)
        {
            return Task.FromResult(false);
        }

        present.Name = updatePresentDto.Name;
        childrenPresent.Name = updatePresentDto.Name;

        return Task.FromResult(true);
    }

    private int GetIdForPresent()
        => _christmasDatabase.Presents.Any()
            ? (_christmasDatabase.Presents.Max(c => c.Id) + 1)
            : 1;
}