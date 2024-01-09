using Microsoft.EntityFrameworkCore;
using Rzucidlo.ChristmasApp.Core.DTO.Children;
using Rzucidlo.ChristmasApp.Core.Models;
using Rzucidlo.ChristmasApp.DAO.Database;
using Rzucidlo.ChristmasApp.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Rzucidlo.ChristmasApp.DAO.Providers
{
    public sealed partial class DatabaseProvider : IDatabaseProvider
    {
        private readonly ChristmasDbContext _christmasDbContext;

        public DatabaseProvider()
        {
            _christmasDbContext = new ChristmasDbContext();
        }

        public async Task<int> CreateChildren(CreateChildrenDto childrenDto)
        {
            var result = await _christmasDbContext.Childrens.AddAsync(childrenDto);
            await _christmasDbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public Children? GetChildren(int childrenId)
        {
            var result = _christmasDbContext.Childrens.FirstOrDefault(c => c.Id == childrenId);

            return result;
        }

        public IReadOnlyList<Children> GetChildrens(int count, int skipValue)
            => _christmasDbContext.Childrens.Skip(skipValue).Take(count).Include(c => c.Presents).ToList();

        public async Task<bool> UpdateChildren(UpdateChildrenDto childrenDto, int childrenId)
        {
            var childrenToUpdate = _christmasDbContext.Childrens.FirstOrDefault(c => c.Id == childrenId);

            if (childrenToUpdate is null)
            {
                return false;
            }

            childrenToUpdate.Address = childrenDto.Address;
            childrenToUpdate.Age = childrenDto.Age;
            childrenToUpdate.Name = childrenDto.Name;
            childrenToUpdate.ChildrenBehaviourType = childrenDto.ChildrenBehaviourType;

            await _christmasDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteChildren(int childrenId)
        {
            var childrenToDelete = _christmasDbContext.Childrens.FirstOrDefault(c => c.Id == childrenId);

            if (childrenToDelete is null)
            {
                return false;
            }

            _christmasDbContext.Childrens.Remove(childrenToDelete);

            await _christmasDbContext.SaveChangesAsync();

            return true;
        }
    }
}