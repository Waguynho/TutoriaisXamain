using Phoneword.Styles;
using Phoneword.Views.Interfaces;
using Xamarin.Forms;

namespace Phoneword.Views
{
    public class HelloMonsterView : ContentPage, IHelloMonsterView
    {
        public HelloMonsterView()
        {
            Title = "Main Screen";
            CreateMainLayout();
        }

        private void CreateMainLayout()
        {
            Button btnToGrid = new Button
            {
                Text = "Grids",
                Style = StylesButton.ButtonDefault,

                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new GridAdvancedView());
                })
            };

            Button btnToDataTemplate = new Button
            {
                Text = "DataTemplates",
                Style = StylesButton.ButtonDefault
            };

            btnToDataTemplate.SetBinding(Button.CommandProperty, "DataTemplateCommand");

            Button btnFileAccess = new Button
            {
                Text = "File Access",
                Style = StylesButton.ButtonDefault
            };

            btnFileAccess.SetBinding(Button.CommandProperty, "FileAccessCommand");

            Button btnWebInterface = new Button
            {
                Text = "Web View",
                Style = StylesButton.ButtonDefault
            };

            btnWebInterface.SetBinding(Button.CommandProperty, "WebInterfaceCommand");

            Button btnLogin = new Button
            {
                Text = "Login View",
                Style = StylesButton.ButtonDefault
            };

            btnLogin.SetBinding(Button.CommandProperty, "LoginCommand");

            StackLayout stackMain = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { btnToGrid, btnToDataTemplate, btnFileAccess, btnWebInterface, btnLogin },
                Padding = 5
            };

            ScrollView scroll = ConfigureScroolView(stackMain);

            Content = scroll;
        }

        private  ScrollView ConfigureScroolView(Layout stackMain)
        {
            ScrollView scroll = new ScrollView();
            scroll.Orientation = ScrollOrientation.Vertical;
            scroll.Content = stackMain;
            scroll.Padding = new Thickness(5, 10);

            return scroll;
        }
    }
}
