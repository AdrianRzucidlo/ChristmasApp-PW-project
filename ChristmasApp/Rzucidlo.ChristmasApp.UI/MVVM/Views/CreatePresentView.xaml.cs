using Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;

namespace Rzucidlo.ChristmasApp.UI.MVVM.Views;

public partial class CreatePresentView : ContentPage
{
    public CreatePresentView(CreatePresentViewModel createPresentViewModel)
    {
        InitializeComponent();

        BindingContext = createPresentViewModel;
    }
}