using Rzucidlo.ChristmasApp.Core.DTO.Present;

namespace Rzucidlo.ChristmasApp.Core.DTO.Children;

public sealed record GetChildrenDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public int Age { get; init; }

    public string Address { get; init; } = string.Empty;

    public string ChildrenBehaviour { get; init; } = string.Empty;

    public List<GetPresentDto> Presents { get; init; } = [];
}