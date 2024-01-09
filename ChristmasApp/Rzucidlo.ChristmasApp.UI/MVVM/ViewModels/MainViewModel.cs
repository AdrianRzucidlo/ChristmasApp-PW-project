using Rzucidlo.ChristmasApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rzucidlo.ChristmasApp.UI.MVVM.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Children> Childrens { get; set; } = new ObservableCollection<Children> { new Children() { Age = 5, Name = "adiran" }, new Children() { Age = 3, Name = "adi1ran" } };
    }
}