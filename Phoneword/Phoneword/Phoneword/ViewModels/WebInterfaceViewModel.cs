using Phoneword.Utils;
using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class WebInterfaceViewModel : ViewModelBase, IWebInterfaceViewModel
    {
        public WebInterfaceViewModel(IPageContext context) : base(context)
        {

        }

        HtmlWebViewSource htmlWebViewSource = new HtmlWebViewSource();

        private WebViewSource webSource;
        public WebViewSource WebSource
        {
            get { return webSource; }
            set
            {
                SetProperty(ref webSource, value);
            }
        }

        private bool isToggled;
        public bool IsToggled
        {
            get { return isToggled; }
            set
            {
                SetProperty(ref isToggled, value);
            }
        }

        public override void BeforeBinding()
        {
            base.BeforeBinding();
            BuildHtmlViewSource();
            StartWebSource();
        }

        private void StartWebSource()
        {
            WebSource = htmlWebViewSource;
        }

        private void BuildHtmlViewSource()
        {
            htmlWebViewSource.Html = DependencyService.Get<IAssetHandler>().ReadAssetContent("index.html");
            htmlWebViewSource.BaseUrl = DependencyService.Get<IBaseUrlAsset>().GetAssetBase();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (nameof(IsToggled) == propertyName)
            {
                ChangeSourceWebView();
            }
        }

        private void ChangeSourceWebView()
        {
            if (IsToggled)
            {
                WebSource = "https://wagner.santos.wscompany.com.br/";
            }
            else
            {
                WebSource = htmlWebViewSource;
            }             
        }
    }
}
