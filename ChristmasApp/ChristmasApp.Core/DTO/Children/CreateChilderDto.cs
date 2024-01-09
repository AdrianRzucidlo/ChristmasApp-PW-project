using Rzucidlo.ChristmasApp.Core.Enums;
using Rzucidlo.ChristmasApp.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rzucidlo.ChristmasApp.Core.DTO.Children
{
    public record CreateChildrenDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; init; } = string.Empty;

        [Required]
        [Range(0, 18)]
        public int Age { get; init; }

        [Required]
        [MaxLength(100)]
        public string Address { get; init; } = string.Empty;

        [Required]
        public ChildrenBehaviourType ChildrenBehaviourType { get; init; }

        public static implicit operator Models.Children(CreateChildrenDto childrenDto)
            => new()
            {
                Address = childrenDto.Address,
                Name = childrenDto.Name,
                Age = childrenDto.Age,
                ChildrenBehaviourType = childrenDto.ChildrenBehaviourType
            };
    }
}