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
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var topLeft = new Label { Text = "Top Left" };
            var topRight = new Label { Text = "Top Right" };
            var bottomLeft = new Label { Text = "Bottom Left" };
            var bottomRight = new Label { Text = "Bottom Right" };

            grid.Children.Add(topLeft, 0, 0);
            grid.Children.Add(topRight, 1, 0);
            grid.Children.Add(bottomLeft, 0, 1);
            grid.Children.Add(bottomRight, 1, 1);

            Content = grid;
        }
    }
}
