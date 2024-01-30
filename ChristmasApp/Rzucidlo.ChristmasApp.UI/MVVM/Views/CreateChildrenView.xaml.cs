using Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;

namespace Rzucidlo.ChristmasApp.UI.MVVM.Views;

public partial class CreateChildrenView : ContentPage
{
    public CreateChildrenView(CreateChildrenViewModel childrenViewModel)
    {
        InitializeComponent();

        BindingContext = childrenViewModel;
    }
}