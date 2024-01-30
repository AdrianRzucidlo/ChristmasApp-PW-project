using Rzucidlo.ChristmasApp.Core.Interfaces;

namespace Rzucidlo.ChristmasApp.Core.DTO.Present;

public sealed record GetPresentDto : IPresent
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;
}