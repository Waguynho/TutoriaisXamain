using Android.Content;
using Android.Views;
using Phoneword.Controls;
using Phoneword.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(WEntry), typeof(WEntryRender))]
namespace Phoneword.Droid.Renders
{
    class WEntryRender : EntryRenderer
    {
        public WEntryRender(Context context) : base(context)
        {
        }

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
                Control.LayoutDirection = LayoutDirection.Rtl;
                Control.TextDirection = TextDirection.Rtl;
            }        
        }
    }
}