using Microsoft.Maui.HotReload;
using Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;

namespace Rzucidlo.ChristmasApp.UI.MVVM.Views;

public partial class ListChildrenView : ContentPage
{
    private ListChildrenViewModel _mainViewModel;

    public ListChildrenView(ListChildrenViewModel mainViewModel)
    {
        InitializeComponent();

        BindingContext = mainViewModel;

        _mainViewModel = mainViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _mainViewModel.LoadChildrensCommand.Execute(null);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        _mainViewModel.LoadChildrensCommand.Execute(null);
    }
}