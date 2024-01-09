using Rzucidlo.ChristmasApp.Core.DTO.Present;
using Rzucidlo.ChristmasApp.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rzucidlo.ChristmasApp.DAO.Providers
{
    public sealed partial class DatabaseProvider : IDatabaseProvider
    {
        public async Task<bool> UpdatePresent(UpdatePresentDto updatePresentDto, int childrenId)
        {
            var children = _christmasDbContext.Childrens.FirstOrDefault(c => c.Id == childrenId);
            if (children is null)
            {
                return false;
            }

            var present = _christmasDbContext.Presents.FirstOrDefault(c => c.Id == updatePresentDto.PresentId);

            if (present is null || !children.Presents.Contains(present))
            {
                return false;
            }

            present.Name = updatePresentDto.Name;

            await _christmasDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreatePresent(CreatePresentDto createPresentDto, int childrenId)
        {
            var children = _christmasDbContext.Childrens.FirstOrDefault(c => c.Id == childrenId);
            if (children is null)
            {
                return false;
            }

            children.Presents.Add(createPresentDto);

            await _christmasDbContext.SaveChangesAsync();

            return true;
        }
    }
}