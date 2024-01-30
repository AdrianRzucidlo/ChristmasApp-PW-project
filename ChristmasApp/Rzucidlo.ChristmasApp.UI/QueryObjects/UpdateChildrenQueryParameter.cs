using Rzucidlo.ChristmasApp.Core.DTO.Children;

namespace Rzucidlo.ChristmasApp.UI.QueryObjects;

public sealed record UpdateChildrenQueryParameter
{
    public UpdateChildrenDto UpdateChildrenDto { get; init; } = new();

    public int Id { get; init; }
}