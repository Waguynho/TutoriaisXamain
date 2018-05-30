using Phoneword.Converters;
using Xamarin.Forms;

namespace Phoneword.Views
{
    public class DataTemplateAdvancedView : ContentPage
    {
        public DataTemplateAdvancedView()
        {
            Title = "TaskList";

            var listView = new ListView
            {
                RowHeight = 40
            };
            listView.ItemsSource = new TodoItem[] {
                new TodoItem { Name = "Buy pears", Done = false },
                new TodoItem { Name = "Buy oranges", Done= true} ,
                new TodoItem { Name = "Buy mangos"  , Done = false },
                new TodoItem { Name = "Buy apples", Done= true },
                new TodoItem { Name = "Buy bananas", Done= true }
            };

            var dataTemplate = new DataTemplate();

            listView.ItemTemplate = GetDataTemplate();

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { listView }
            };
        }

        private DataTemplate GetDataTemplate()
        {

            return new DataTemplate(() =>
            {
                var grid = new Grid();

                var task = new Label { FontAttributes = FontAttributes.Bold };
                var done = new Label();

                task.SetBinding(Label.TextProperty, "Name");
                done.SetBinding(Label.TextProperty, "Done");
                var convertColor = new BoolToColorConverter();
                convertColor.Convert(this, typeof(Color), null, null);
                done.SetBinding(Label.TextColorProperty, new Binding("Done", BindingMode.TwoWay, convertColor));

                grid.Children.Add(task, 0, 0);
                grid.Children.Add(done, 1, 0);

                return new ViewCell { View = grid };
            });
        }
    }
}
