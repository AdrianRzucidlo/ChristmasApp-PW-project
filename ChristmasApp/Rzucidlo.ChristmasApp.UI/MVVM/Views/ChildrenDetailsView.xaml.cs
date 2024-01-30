using Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;

namespace Rzucidlo.ChristmasApp.UI.MVVM.Views;

public partial class ChildrenDetailsView : ContentPage
{
    private readonly ChildrenDetailsViewModel _childrenDetailsViewModel;

    public ChildrenDetailsView(ChildrenDetailsViewModel childrenDetailsViewModel)
    {
        InitializeComponent();

        BindingContext = childrenDetailsViewModel;

        _childrenDetailsViewModel = childrenDetailsViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _childrenDetailsViewModel.LoadPresentsCommand.Execute(null);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        _childrenDetailsViewModel.LoadPresentsCommand.Execute(null);
    }
}