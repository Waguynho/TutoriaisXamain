using Phoneword.Utils;
using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System.Diagnostics;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class WebInterfaceViewModel : ViewModelBase, IWebInterfaceViewModel
    {
        private string baseAssetUrl = "";

        public string BaseAssetUrl
        {
            get { return baseAssetUrl; }
            set
            {
                SetProperty(ref baseAssetUrl, value);
            }
        }

        private string htmlContent;
        public string HtmlContent
        {
            get { return htmlContent; }
            set
            {
                SetProperty(ref htmlContent, value);
            }
        }

        public WebInterfaceViewModel(IPageContext context) : base(context)
        {

        }

        public override void BeforeBinding()
        {
            base.BeforeBinding();
            HtmlContent = DependencyService.Get<IAssetHandler>().ReadAssetContent("index.html");
            BaseAssetUrl = DependencyService.Get<IBaseUrlAsset>().GetAssetBase();
            System.Diagnostics.Debug.WriteLine("====== Source: " + BaseAssetUrl.ToString());
        }
    }
}
