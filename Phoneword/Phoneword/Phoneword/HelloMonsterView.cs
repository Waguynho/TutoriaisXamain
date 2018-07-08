using Phoneword.Utils;
using Phoneword.Views;
using Phoneword.Views.Interfaces;
using Xamarin.Forms;

namespace Phoneword
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
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Statics.ButtonColor,
                CornerRadius = 25,

                Command = new Command(async () => {
                    await Navigation.PushAsync(new GridAdvancedView());
                })
            };

            Button btnToDataTemplate = new Button
            {
                Text = "DataTemplates",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Statics.ButtonColor,
                CornerRadius = 25,                
            };

            btnToDataTemplate.SetBinding(Button.CommandProperty, "DataTemplateCommand");

            Button btnFileAccess = new Button
            {
                Text = "File Access",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Statics.ButtonColor,
                CornerRadius = 25,
            };

            btnFileAccess.SetBinding(Button.CommandProperty, "FileAccessCommand");

            StackLayout stackMain = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //BackgroundColor = Color.Orange,
                Orientation = StackOrientation.Vertical,
                Children = { btnToGrid, btnToDataTemplate, btnFileAccess },
                Padding = 5
            };

            Content = stackMain;
        }
    }
}
