using Rzucidlo.ChristmasApp.Core.DTO.Children;
using Rzucidlo.ChristmasApp.Core.DTO.Present;

namespace Rzucidlo.ChristmasApp.UI.QueryObjects;

public sealed record UpdatePresentQueryParameter
{
    public int PresentId { get; init; }

    public UpdatePresentDto UpdatePresentDto { get; init; } = new();

    public GetChildrenDto GetChildrenDto { get; init; } = new();
}