using Phoneword.Converters;
using Phoneword.Localization;
using Phoneword.Views.Interfaces;
using Xamarin.Forms;

namespace Phoneword.Views
{
    public class DataTemplateAdvancedView : ContentPage, IDataTemplateAdvancedView
    {
        public DataTemplateAdvancedView()
        {
            CreateLayout();
        }

        private void CreateLayout()
        {
            Title = LanguageResource.task_list;
            BackgroundColor = Color.FromHex("#00001a");

            var listView = new ListView
            {
                RowHeight = 40
            };

            listView.SetBinding(ListView.ItemsSourceProperty, "ToDoItems", BindingMode.TwoWay);

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
                task.TextColor = Color.White;

                done.SetBinding(Label.TextProperty, "Done");

                var convertColor = new BoolToColorConverter();
                string parametros = "Teste de parâmetros";
                convertColor.Convert(this, typeof(Color), parametros, null);
                done.SetBinding(Label.TextColorProperty, new Binding("Done", BindingMode.TwoWay, convertColor));

                grid.Children.Add(task, 0, 0);
                grid.Children.Add(done, 1, 0);

                return new ViewCell { View = grid };
            });
        }
    }
}
