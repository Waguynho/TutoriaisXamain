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

                Command = new Command(async () => {
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
            
            StackLayout stackMain = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { btnToGrid, btnToDataTemplate, btnFileAccess },
                Padding = 5
            };

            Content = stackMain;
        }
    }
}
