using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rzucidlo.ChristmasApp.Core.DTO.Present
{
    public sealed record UpdatePresentDto : CreatePresentDto
    {
        [Required]
        public int PresentId { get; init; }
    }
}