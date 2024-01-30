using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Rzucidlo.ChristmasApp.UI.Tools;

public static class ToastFactory
{
    public static async Task CreateToast(string text)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var duration = ToastDuration.Short;
        var fontSize = 14d;

        var toast = Toast.Make(text, duration, fontSize);

        await toast.Show(cancellationTokenSource.Token);
    }
}