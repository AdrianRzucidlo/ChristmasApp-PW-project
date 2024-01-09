using Microsoft.AspNetCore.Mvc;
using Rzucidlo.ChristmasApp.Core.DTO.Children;
using Rzucidlo.ChristmasApp.Interfaces.Interfaces;

namespace Rzucidlo.ChristmasApp.API.Controllers
{
    [ApiController]
    [Route("/api/children")]
    public class ChildrenController : Controller
    {
        private readonly IDatabaseProvider _databaseProvider;

        public ChildrenController(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        [HttpGet("/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var children = _databaseProvider.GetChildren(id);

            return children is null ? NotFound() : Ok(children);
        }

        [HttpGet("/{count}/{skip}")]
        public IActionResult Get([FromRoute] int count, [FromRoute] int skip)
        {
            var childrens = _databaseProvider.GetChildrens(count, skip);

            return Ok(childrens);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateChildrenDto createChildrenDto)
        {
            var result = await _databaseProvider.CreateChildren(createChildrenDto);

            return Created($"/api/children/{result}", null);
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateChildrenDto createChildrenDto)
        {
            var result = await _databaseProvider.UpdateChildren(createChildrenDto, id);

            return result ? Ok() : NotFound();
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _databaseProvider.DeleteChildren(id);

            return result ? Ok() : NotFound();
        }
    }
}