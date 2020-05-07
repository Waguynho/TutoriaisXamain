using Phoneword.iOS.Renderes;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WKWebView), typeof(CWebViewRenderer))]
namespace Phoneword.iOS.Renderes
{
    public class CWebViewRenderer : WkWebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
        }
    }
}