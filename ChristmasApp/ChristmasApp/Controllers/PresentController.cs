using Microsoft.AspNetCore.Mvc;
using Rzucidlo.ChristmasApp.Core.DTO.Present;
using Rzucidlo.ChristmasApp.Interfaces.Interfaces;

namespace Rzucidlo.ChristmasApp.API.Controllers
{
    [ApiController]
    [Route("/api/children/{childrenId}/present")]
    public class PresentController : Controller
    {
        private readonly IDatabaseProvider _databaseProvider;

        public PresentController(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePresentDto createPresentDto, [FromRoute] int childrenId)
        {
            var result = await _databaseProvider.CreatePresent(createPresentDto, childrenId);

            return result is true ? Created($"/api/children/{childrenId}", null) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePresentDto createPresentDto, [FromRoute] int childrenId)
        {
            var result = await _databaseProvider.UpdatePresent(createPresentDto, childrenId);

            return result is true ? Ok() : NotFound();
        }
    }
}