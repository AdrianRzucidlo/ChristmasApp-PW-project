using Rzucidlo.ChristmasApp.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rzucidlo.ChristmasApp.Core.DTO.Present
{
    public record CreatePresentDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; init; } = string.Empty;

        public static implicit operator Models.Present(CreatePresentDto createPresentDto)
            => new() { Name = createPresentDto.Name };
    }
}