using Microsoft.AspNetCore.Mvc;
using Rzucidlo.ChristmasApp.Core.DTO.Children;
using Rzucidlo.ChristmasApp.Core.Interfaces;

namespace Rzucidlo.ChristmasApp.API.Controllers;

[ApiController]
[Route("/api/children")]
public class ChildrenController : Controller
{
    private readonly IDataRepository _dataRepository;

    public ChildrenController(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    [HttpGet("/{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var children = _dataRepository.GetChildren(id);

        return children is null ? NotFound() : Ok(children);
    }

    [HttpGet]
    public IActionResult Get()
    {
        var childrens = _dataRepository.GetAllChildren();

        return Ok(childrens);
    }

    [HttpGet("/{count}/{skip}")]
    public IActionResult Get([FromRoute] int count, [FromRoute] int skip)
    {
        var childrens = _dataRepository.GetChildrens(count, skip);

        return Ok(childrens);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateChildrenDto createChildrenDto)
    {
        var result = await _dataRepository.CreateChildren(createChildrenDto);

        return Created($"/api/children/{result}", null);
    }

    [HttpPut("/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateChildrenDto createChildrenDto)
    {
        var result = await _dataRepository.UpdateChildren(createChildrenDto, id);

        return result ? Ok() : NotFound();
    }

    [HttpDelete("/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _dataRepository.DeleteChildren(id);

        return result ? Ok() : NotFound();
    }
}