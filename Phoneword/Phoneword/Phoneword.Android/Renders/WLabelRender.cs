using Android.Content;
using Android.Views;
using Phoneword.Controls;
using Phoneword.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(Label), typeof(WLabelRender))]
namespace Phoneword.Droid.Renders
{
    class WLabelRender : LabelRenderer
    {
        public WLabelRender(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null && e.NewElement != null)
            {
                Control.SetTextIsSelectable(true);
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