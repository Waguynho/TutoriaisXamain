using Xamarin.Forms;

namespace Phoneword
{
    public class HelloMonsterView : ContentPage
    {
        public HelloMonsterView()
        {
            var red = new Label
            {
                Text = "Stop",
                BackgroundColor = Color.Red,
                FontSize = 20,
                WidthRequest = 100
            };
            var yellow = new Label
            {
                Text = "Slow down",
                BackgroundColor = Color.Yellow,
                FontSize = 20,
                WidthRequest = 100
            };
            var green = new Label
            {
                Text = "Go",
                BackgroundColor = Color.Green,
                FontSize = 20,
                WidthRequest = 200
            };

            Content = new StackLayout
            {
                Spacing = 20,
                VerticalOptions = LayoutOptions.End,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Start,
                Children = { red, yellow, green }
            };
        }
    }
}
