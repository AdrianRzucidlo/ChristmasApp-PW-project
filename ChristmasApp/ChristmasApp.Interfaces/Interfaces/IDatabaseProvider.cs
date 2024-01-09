using Rzucidlo.ChristmasApp.Core.DTO.Children;
using Rzucidlo.ChristmasApp.Core.DTO.Present;
using Rzucidlo.ChristmasApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rzucidlo.ChristmasApp.Interfaces.Interfaces
{
    public interface IDatabaseProvider
    {
        Task<int> CreateChildren(CreateChildrenDto childrenDto);

        Children? GetChildren(int childrenId);

        IReadOnlyList<Children> GetChildrens(int count, int skipValue);

        Task<bool> UpdateChildren(UpdateChildrenDto childrenDto, int childrenId);

        Task<bool> DeleteChildren(int childrenId);

        Task<bool> UpdatePresent(UpdatePresentDto updatePresentDto, int childrenId);

        Task<bool> CreatePresent(CreatePresentDto createPresentDto, int childrenId);
    }
}