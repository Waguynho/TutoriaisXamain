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
                HorizontalOptions = LayoutOptions.Center,

                CornerRadius = 20,

                Command = new Command(async () => {
                    await Navigation.PushAsync(new GridAdvancedView());
                })
            };

            Button btnToDataTemplate = new Button
            {
                Text = "DataTemplates",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,

                BorderRadius = 20,

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
