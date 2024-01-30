using Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;

namespace Rzucidlo.ChristmasApp.UI.MVVM.Views;

public partial class UpdatePresentView : ContentPage
{
    public UpdatePresentView(UpdatePresentViewModel updatePresentViewModel)
    {
        InitializeComponent();

        BindingContext = updatePresentViewModel;
    }
}