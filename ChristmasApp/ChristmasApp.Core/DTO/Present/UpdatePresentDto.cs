using Rzucidlo.ChristmasApp.Core.Interfaces;

namespace Rzucidlo.ChristmasApp.Core.DTO.Present;

public sealed record UpdatePresentDto : CreatePresentDto, IPresent
{
}