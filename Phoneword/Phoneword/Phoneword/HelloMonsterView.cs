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
            listView.ItemsSource = new string[]
            {
                "Buy pears", "Buy oranges", "Buy mangos", "Buy apples", "Buy bananas"
            };
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { listView }
            };
        }
    }
}
