using Android.Content;
using Android.Views;
using Phoneword.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntry))]
namespace Phoneword.Droid.Renders
{
    class CustomEntry : EntryRenderer
    {
        public CustomEntry(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && e.NewElement != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);
                Control.TextDirection = TextDirection.AnyRtl;
                Control.LayoutDirection = LayoutDirection.Rtl;
                

            }
        }
    }
}