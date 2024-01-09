using Rzucidlo.ChristmasApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rzucidlo.ChristmasApp.DAO2.InMemoryDatabase
{
    public sealed class ChristmasInMemoryDatabase
    {
        public List<Children> Childrens { get; set; } = [];
        public List<Present> Presents { get; set; } = [];
    }
}