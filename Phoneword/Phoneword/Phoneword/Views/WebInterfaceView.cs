using Phoneword.Views.Interfaces;
using Xamarin.Forms;

namespace Phoneword.Views
{
    public class WebInterfaceView : ContentPage, IWebInterfaceView
    {
        public WebInterfaceView()
        {
            Title = "Web View Sample";
            CreateLayout();
        }

        private void CreateLayout()
        {
            Label subTitle = new Label();
            subTitle.Text = "Web View";
            subTitle.TextColor = Color.Red;
            subTitle.FontAttributes = FontAttributes.Bold;

            WebView web = new WebView();
            var source = new HtmlWebViewSource();
            //source.BaseUrl = @"ms-appx-web:///";
            source.SetBinding(HtmlWebViewSource.BaseUrlProperty, "BaseAssetUrl");
            
            web.Source = source;
            web.VerticalOptions = LayoutOptions.FillAndExpand;
            web.HorizontalOptions = LayoutOptions.FillAndExpand;

            StackLayout statckView = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Padding = 3,
                Children = { subTitle, web }
            };

            Content = statckView;
        }
    }
}
