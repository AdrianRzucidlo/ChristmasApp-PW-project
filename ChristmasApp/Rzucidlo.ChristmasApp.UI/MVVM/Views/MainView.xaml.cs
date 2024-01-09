using Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;

namespace Rzucidlo.ChristmasApp.UI.MVVM.Views;

public partial class MainView : ContentPage
{
    public MainView()
    {
        InitializeComponent();

        BindingContext = new MainViewModel();
    }
}