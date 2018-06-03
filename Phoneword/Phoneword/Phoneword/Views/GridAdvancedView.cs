using Xamarin.Forms;

namespace Phoneword.Views
{
    public class GridAdvancedView : ContentPage
    {
        public GridAdvancedView()
        {
            Title = "Grids";
            CreateMainLayout();
        }

        private void CreateMainLayout()
        {
            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.WhiteSmoke,

                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                }
            };

            grid.Children.Add(new Label
            {
                Text = "Cell 1",
                BackgroundColor = Color.Green,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            }, 0, 0);

            grid.Children.Add(new Label
            {
                Text = "Cell 2",
                TextColor = Color.White,
                BackgroundColor = Color.Black
            }, 0, 1);

            grid.Children.Add(new Label
            {
                Text = "Cell 3",
                TextColor = Color.White,
                BackgroundColor = Color.Blue
            }, 0, 2);

            grid.Children.Add(new Label
            {
                Text = "Cell 4",
                TextColor = Color.Pink,
                BackgroundColor = Color.Blue
            }, 0, 3);

            grid.Children.Add(new Label
            {
                Text = "Cell 5",
                TextColor = Color.White,
                BackgroundColor = Color.Blue
            }, 1, 0);

            grid.Children.Add(new Label
            {
                Text = "Cell 6",
                TextColor = Color.White,
                BackgroundColor = Color.Blue
            }, 1, 1);

            grid.Children.Add(new Label
            {
                Text = "Cell 7",
                TextColor = Color.Black,
                BackgroundColor = Color.GreenYellow
            }, 1, 2);

            grid.Children.Add(new Label
            {
                Text = "Cell 8",
                TextColor = Color.BlueViolet,
                BackgroundColor = Color.Pink
            }, 1, 3);

            grid.Children.Add(new Label
            {
                Text = "Cell 9",
                TextColor = Color.White,
                BackgroundColor = Color.PeachPuff
            }, 2, 0);

            grid.Children.Add(new Label
            {
                Text = "Cell 10",
                TextColor = Color.White,
                BackgroundColor = Color.Plum
            }, 2, 1);

            grid.Children.Add(new Label
            {
                Text = "Cell 11",
                TextColor = Color.Purple,
                BackgroundColor = Color.Red
            }, 2, 2 );


            Content = grid;
        }
    }
}
