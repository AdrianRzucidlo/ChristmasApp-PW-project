using Rzucidlo.ChristmasApp.UI.MVVM.Views;

namespace Rzucidlo.ChristmasApp.UI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainView();
        }
    }
}