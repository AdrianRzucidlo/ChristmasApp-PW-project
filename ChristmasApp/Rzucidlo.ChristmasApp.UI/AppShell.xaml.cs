using Rzucidlo.ChristmasApp.UI.MVVM.Views;

namespace Rzucidlo.ChristmasApp.UI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CreateChildrenView), typeof(CreateChildrenView));
        Routing.RegisterRoute(nameof(ListChildrenView), typeof(ListChildrenView));
        Routing.RegisterRoute(nameof(UpdateChildrenView), typeof(UpdateChildrenView));
        Routing.RegisterRoute(nameof(ChildrenDetailsView), typeof(ChildrenDetailsView));
        Routing.RegisterRoute(nameof(CreatePresentView), typeof(CreatePresentView));
        Routing.RegisterRoute(nameof(UpdatePresentView), typeof(UpdatePresentView));
    }
}