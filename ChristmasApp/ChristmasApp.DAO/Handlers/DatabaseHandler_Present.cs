using Rzucidlo.ChristmasApp.Core.Interfaces;
using Rzucidlo.ChristmasApp.Core.Models;

namespace Rzucidlo.ChristmasApp.DAO.Handlers;

public sealed partial class DatabaseHandler : IDatabaseHandler
{
    public async Task<bool> UpdatePresent(IPresent updatePresentDto, int childrenId, int presentId)
    {
        var children = _christmasDbContext.Childrens.FirstOrDefault(c => c.Id == childrenId);
        if (children is null)
        {
            return false;
        }

        var present = _christmasDbContext.Presents.FirstOrDefault(c => c.Id == presentId);

        if (present is null || !children.Presents.Contains(present))
        {
            return false;
        }

        present.Name = updatePresentDto.Name;

        await _christmasDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> CreatePresent(IPresent createPresentDto, int childrenId)
    {
        var children = _christmasDbContext.Childrens.FirstOrDefault(p => p.Id == childrenId);
        if (children is null)
        {
            return false;
        }

        children.Presents.Add(new Present { Name = createPresentDto.Name });

        await _christmasDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeletePresent(int presentId, int childrenId)
    {
        var present = _christmasDbContext.Presents.FirstOrDefault(p => p.Id == presentId);
        if (present is null || present.Children.Id != childrenId)
        {
            return false;
        }

        _christmasDbContext.Presents.Remove(present);

        await _christmasDbContext.SaveChangesAsync();

        return true;
    }
}