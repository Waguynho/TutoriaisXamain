using Phoneword.Views;
using Xamarin.Forms;

namespace Phoneword
{
    public class HelloMonsterView : ContentPage
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
                HorizontalOptions = LayoutOptions.Center,
#pragma warning disable CS0618 // Type or member is obsolete
                BorderRadius = 20,
#pragma warning restore CS0618 // Type or member is obsolete
                Command = new Command(async () => {
                    await Navigation.PushAsync(new GridAdvancedView());
                })
            };

            Button btnToDataTemplate = new Button
            {
                Text = "DataTemplates",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
#pragma warning disable CS0618 // Type or member is obsolete
                BorderRadius = 20,
#pragma warning restore CS0618 // Type or member is obsolete
                Command = new Command(async() => {

                    await Navigation.PushAsync(new DataTemplateAdvancedView());
                })
            };

            StackLayout stackMain = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { btnToGrid, btnToDataTemplate },
                Padding = 5
            };

            Content = stackMain;
        }
    }
}
