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
                StackLayout stackDataTemplate = new StackLayout
                {
                    Padding = 5,
                    Orientation = StackOrientation.Horizontal,
                    //BackgroundColor = Color.Pink,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                var task = new Label { FontAttributes = FontAttributes.Bold };
                var done = new Label();

                task.SetBinding(Label.TextProperty, "Name");
                task.TextColor = Color.White;
                task.HorizontalOptions = LayoutOptions.Start;

                done.SetBinding(Label.TextProperty, "Done");
                done.HorizontalOptions = LayoutOptions.EndAndExpand;

                var convertColor = new BoolToColorConverter();
                convertColor.Convert(this, typeof(Color), null, null);
                done.SetBinding(Label.TextColorProperty, new Binding("Done", BindingMode.TwoWay, convertColor));


                stackDataTemplate.Children.Add(task);
                stackDataTemplate.Children.Add(done);

                return new ViewCell { View =  stackDataTemplate};
            });
        }
    }
}
