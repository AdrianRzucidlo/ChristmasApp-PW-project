using Rzucidlo.ChristmasApp.Core.DTO.Children;
using Rzucidlo.ChristmasApp.Core.DTO.Present;
using Rzucidlo.ChristmasApp.Core.Interfaces;

namespace Rzucidlo.ChristmasApp.BL.Repository;

public sealed class DataRepository : IDataRepository
{
    private readonly IDatabaseHandler _databaseHandler;

    public DataRepository(IDatabaseHandler databaseHandler)
    {
        _databaseHandler = databaseHandler;
    }

    public async Task<int> CreateChildren(IChildren childrenDto)
        => await _databaseHandler.CreateChildren(childrenDto);

    public async Task<bool> CreatePresent(IPresent createPresentDto, int childrenId)
        => await _databaseHandler.CreatePresent(createPresentDto, childrenId);

    public async Task<bool> DeleteChildren(int childrenId)
        => await _databaseHandler.DeleteChildren(childrenId);

    public async Task<bool> DeletePresent(int presentId, int childrenId)
        => await _databaseHandler.DeletePresent(presentId, childrenId);

    public GetChildrenDto? GetChildren(int childrenId)
    {
        var children = _databaseHandler.GetChildren(childrenId);

        return children is not null
            ? new() { Name = children.Name, Address = children.Address, Id = children.Id, Age = children.Age, ChildrenBehaviour = children.ChildrenBehaviourType.ToString(), Presents = children.Presents.Select(p => new GetPresentDto { Id = p.Id, Name = p.Name }).ToList() }
            : null;
    }

    public IReadOnlyList<GetChildrenDto> GetChildrens(int count, int skipValue)
    {
        var children = _databaseHandler.GetChildrens(count, skipValue);

        return children.Select(x => new GetChildrenDto { Name = x.Name, Address = x.Address, Id = x.Id, Age = x.Age, ChildrenBehaviour = x.ChildrenBehaviourType.ToString(), Presents = x.Presents.Select(p => new GetPresentDto { Id = p.Id, Name = p.Name }).ToList() }).ToList();
    }

    public IReadOnlyList<GetChildrenDto> GetAllChildren()
    {
        var children = _databaseHandler.GetAllChildren();

        return children.Select(x => new GetChildrenDto { Name = x.Name, Address = x.Address, Id = x.Id, Age = x.Age, ChildrenBehaviour = x.ChildrenBehaviourType.ToString(), Presents = x.Presents.Select(p => new GetPresentDto { Id = p.Id, Name = p.Name }).ToList() }).ToList();
    }

    public async Task<bool> UpdateChildren(IChildren childrenDto, int childrenId)
        => await _databaseHandler.UpdateChildren(childrenDto, childrenId);

    public async Task<bool> UpdatePresent(IPresent updatePresentDto, int childrenId, int presentId)
        => await _databaseHandler.UpdatePresent(updatePresentDto, childrenId, presentId);
}