using Rzucidlo.ChristmasApp.Core.DTO.Present;
using Rzucidlo.ChristmasApp.Core.Models;
using Rzucidlo.ChristmasApp.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rzucidlo.ChristmasApp.DAO2.Providers
{
    public sealed partial class DatabaseProvider : IDatabaseProvider
    {
        public Task<bool> CreatePresent(CreatePresentDto createPresentDto, int childrenId)
        {
            var children = _christmasDatabase.Childrens.FirstOrDefault(x => x.Id == childrenId);

            if (children is null)
            {
                return Task.FromResult(false);
            }

            Present present = createPresentDto;
            present.Id = GetIdForPresent();

            present.Children = children;
            children.Presents.Add(createPresentDto);

            _christmasDatabase.Presents.Add(present);

            return Task.FromResult(true);
        }

        public Task<bool> UpdatePresent(UpdatePresentDto updatePresentDto, int childrenId)
        {
            var children = _christmasDatabase.Childrens.FirstOrDefault(c => c.Id == childrenId);
            if (children is null)
            {
                return Task.FromResult(false);
            }

            var childrenPresent = children.Presents.FirstOrDefault(p => p.Id == updatePresentDto.PresentId);
            var present = _christmasDatabase.Presents.FirstOrDefault(p => p.Id == updatePresentDto.PresentId);

            if (childrenPresent is null || present is null)
            {
                return Task.FromResult(false);
            }

            present.Name = updatePresentDto.Name;
            childrenPresent.Name = updatePresentDto.Name;

            return Task.FromResult(true);
        }

        private int GetIdForPresent()
            => (_christmasDatabase.Presents.Max(c => c.Id) + 1);
    }
}