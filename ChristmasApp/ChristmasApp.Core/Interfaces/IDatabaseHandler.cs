using Rzucidlo.ChristmasApp.Core.Models;

namespace Rzucidlo.ChristmasApp.Core.Interfaces;

public interface IDatabaseHandler
{
    Task<int> CreateChildren(IChildren childrenDto);

    Children? GetChildren(int childrenId);

    IReadOnlyList<Children> GetChildrens(int count, int skipValue);

    IReadOnlyList<Children> GetAllChildren();

    Task<bool> UpdateChildren(IChildren childrenDto, int childrenId);

    Task<bool> DeleteChildren(int childrenId);

    Task<bool> UpdatePresent(IPresent updatePresentDto, int childrenId, int presentId);

    Task<bool> CreatePresent(IPresent createPresentDto, int childrenId);

    Task<bool> DeletePresent(int presentId, int childrenId);
}