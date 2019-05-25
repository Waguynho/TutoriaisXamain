using Phoneword.UWP.Renders;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntry))]
namespace Phoneword.UWP.Renders
{
    class CustomEntry: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && e.NewElement != null)
            {
                Control.FlowDirection = Windows.UI.Xaml.FlowDirection.RightToLeft;
                Control.Background = new SolidColorBrush(Windows.UI.Colors.BlueViolet);
            }
        } 
    }
}
