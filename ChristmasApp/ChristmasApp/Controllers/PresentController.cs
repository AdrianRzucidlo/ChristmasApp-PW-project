using Microsoft.AspNetCore.Mvc;
using Rzucidlo.ChristmasApp.Core.DTO.Present;
using Rzucidlo.ChristmasApp.Core.Interfaces;

namespace Rzucidlo.ChristmasApp.API.Controllers;

[ApiController]
[Route("/api/children/{childrenId}/present")]
public class PresentController : Controller
{
    private readonly IDataRepository _dataRepository;

    public PresentController(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePresentDto createPresentDto, [FromRoute] int childrenId)
    {
        var result = await _dataRepository.CreatePresent(createPresentDto, childrenId);

        return result is true ? Created($"/api/children/{childrenId}", null) : NotFound();
    }

    [HttpPut("/{presentId}")]
    public async Task<IActionResult> Update([FromBody] UpdatePresentDto createPresentDto, [FromRoute] int childrenId, [FromRoute] int presentId)
    {
        var result = await _dataRepository.UpdatePresent(createPresentDto, childrenId, presentId);

        return result is true ? Ok() : NotFound();
    }

    [HttpDelete("/{presentId}")]
    public async Task<IActionResult> Delete([FromRoute] int presentId, [FromRoute] int childrenId)
    {
        var result = await _dataRepository.DeletePresent(presentId, childrenId);

        return result is true ? Ok() : NotFound();
    }
}