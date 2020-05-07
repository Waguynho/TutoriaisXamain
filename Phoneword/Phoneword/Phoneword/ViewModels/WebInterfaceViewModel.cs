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

        public WebInterfaceViewModel(IPageContext context) : base(context)
        {

        }

        public override void BeforeBinding()
        {
            base.BeforeBinding();
            BaseAssetUrl = "@" + DependencyService.Get<IBaseUrlAsset>().GetAssetBase() + "index.html";
            System.Diagnostics.Debug.WriteLine("====== Source: " + BaseAssetUrl.ToString());
        }
    }
}
