using Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;

namespace Rzucidlo.ChristmasApp.UI.MVVM.Views;

public partial class UpdateChildrenView : ContentPage
{
    public UpdateChildrenView(UpdateChildrenViewModel childrenDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = childrenDetailsViewModel;
    }
}