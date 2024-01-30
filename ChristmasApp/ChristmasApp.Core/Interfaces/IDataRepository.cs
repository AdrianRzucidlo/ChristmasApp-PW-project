using Rzucidlo.ChristmasApp.Core.DTO.Children;

namespace Rzucidlo.ChristmasApp.Core.Interfaces;

public interface IDataRepository
{
    IReadOnlyList<GetChildrenDto> GetAllChildren();

    Task<int> CreateChildren(IChildren childrenDto);

    Task<bool> CreatePresent(IPresent createPresentDto, int childrenId);

    Task<bool> DeleteChildren(int childrenId);

    Task<bool> DeletePresent(int presentId, int childrenId);

    GetChildrenDto? GetChildren(int childrenId);

    IReadOnlyList<GetChildrenDto> GetChildrens(int count, int skipValue);

    Task<bool> UpdateChildren(IChildren childrenDto, int childrenId);

    Task<bool> UpdatePresent(IPresent updatePresentDto, int childrenId, int presentId);
}