using Xamarin.Forms;

namespace Phoneword
{
    public class HelloMonsterView : ContentPage
    {
        public HelloMonsterView()
        {
            var listView = new ListView
            {
                RowHeight = 40
            };
            listView.ItemsSource = new TodoItem[] {
                new TodoItem { Name = "Buy pears" },
                new TodoItem { Name = "Buy oranges", Done=true} ,
                new TodoItem { Name = "Buy mangos" },
                new TodoItem { Name = "Buy apples", Done=true },
                new TodoItem { Name = "Buy bananas", Done=true }
            };

            listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { listView }
            };
        }
    }
}
