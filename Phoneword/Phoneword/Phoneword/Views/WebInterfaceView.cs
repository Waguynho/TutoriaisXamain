using Phoneword.Views.Interfaces;
using Xamarin.Forms;


namespace Phoneword.Views
{
    public class WebInterfaceView : ContentPage, IWebInterfaceView
    {
        public WebInterfaceView()
        {
            SetTitleView();
        }

        private void SetTitleView()
        {
            Title = "Web View Sample";
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            CreateLayout();
        }

        private void CreateLayout()
        {
            Switch toggle = new Switch
            {
                BackgroundColor = Color.BurlyWood,
                Margin = new Thickness(5, 1),
                OnColor = Color.AliceBlue,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.FillAndExpand,                
            };

            toggle.SetBinding(Switch.IsToggledProperty, "IsToggled", BindingMode.TwoWay);

            WebView web = new WebView();
            web.SetBinding(WebView.SourceProperty, "WebSource", BindingMode.OneWay);
            web.VerticalOptions = LayoutOptions.FillAndExpand;
            web.HorizontalOptions = LayoutOptions.FillAndExpand;
            web.BackgroundColor = Color.Pink;

            StackLayout statckView = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Padding = 3,
                Children = { toggle, web },
                BackgroundColor = Color.Blue
            };

            Content = statckView;
        }
    }
}
