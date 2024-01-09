using Rzucidlo.ChristmasApp.Core.DTO.Children;
using Rzucidlo.ChristmasApp.Core.Models;
using Rzucidlo.ChristmasApp.DAO2.InMemoryDatabase;
using Rzucidlo.ChristmasApp.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Rzucidlo.ChristmasApp.DAO2.Providers
{
    public sealed partial class DatabaseProvider : IDatabaseProvider
    {
        private readonly ChristmasInMemoryDatabase _christmasDatabase;

        public DatabaseProvider()
        {
            _christmasDatabase = new ChristmasInMemoryDatabase();
        }

        public Task<int> CreateChildren(CreateChildrenDto childrenDto)
        {
            Children children = childrenDto;
            children.Id = GetIdForChildren();

            _christmasDatabase.Childrens.Add(children);

            return Task.FromResult(children.Id);
        }

        public Task<bool> DeleteChildren(int childrenId)
        {
            var children = _christmasDatabase.Childrens.FirstOrDefault(c => c.Id == childrenId);

            if (children is null)
            {
                return Task.FromResult(false);
            }

            _christmasDatabase.Childrens.Remove(children);

            return Task.FromResult(true);
        }

        public Children? GetChildren(int childrenId)
            => _christmasDatabase.Childrens.FirstOrDefault(c => c.Id == childrenId);

        public IReadOnlyList<Children> GetChildrens(int count, int skipValue)
            => _christmasDatabase.Childrens.Skip(skipValue).Take(count).ToList();

        public Task<bool> UpdateChildren(UpdateChildrenDto childrenDto, int childrenId)
        {
            var children = _christmasDatabase.Childrens.FirstOrDefault(c => c.Id == childrenId);

            if (children is null)
            {
                return Task.FromResult(false);
            }

            children.Address = childrenDto.Address;
            children.Age = childrenDto.Age;
            children.Name = childrenDto.Name;
            children.ChildrenBehaviourType = childrenDto.ChildrenBehaviourType;

            return Task.FromResult(true);
        }

        private int GetIdForChildren()
            => (_christmasDatabase.Childrens.Max(c => c.Id) + 1);
    }
}