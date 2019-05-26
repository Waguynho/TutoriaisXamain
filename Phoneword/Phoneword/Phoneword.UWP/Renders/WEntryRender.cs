using Phoneword.Controls;
using Phoneword.UWP.Renders;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(WEntry), typeof(WEntryRender))]
namespace Phoneword.UWP.Renders
{
    class WEntryRender: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && e.NewElement != null)
            {
                SetInvertedFlow((WEntry)e.NewElement);
            }
        }

        private void SetInvertedFlow(WEntry wEntry)
        {
            if (wEntry.InvertedFlow)
            {
                Control.FlowDirection = Windows.UI.Xaml.FlowDirection.RightToLeft;
                Control.Background = new SolidColorBrush(Windows.UI.Colors.BlueViolet);
            }
        }
    }
}
