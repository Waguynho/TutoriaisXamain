using Phoneword.Converters;
using Phoneword.Localization;
using Phoneword.Views.Interfaces;
using System;
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
            listView.SetBinding(ListView.SelectedItemProperty, "SelectedItem", BindingMode.TwoWay);

            listView.ItemTemplate = GetDataTemplate();
            listView.Header = GetHeaderTemplate();
            listView.Footer = GetFooterTemplate();

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

        private StackLayout GetHeaderTemplate()
        {
                StackLayout stackHeaderTemplate = new StackLayout
                {
                    Padding = 5,
                    Orientation = StackOrientation.Horizontal,
                    BackgroundColor = Color.Orange,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                var title = new Label { FontAttributes = FontAttributes.Bold };             

                title.SetBinding(Label.TextProperty, "HeaderList");
                title.TextColor = Color.Yellow;
                title.HorizontalOptions = LayoutOptions.CenterAndExpand;    
                title.VerticalOptions = LayoutOptions.CenterAndExpand;

                stackHeaderTemplate.Children.Add(title);

                return stackHeaderTemplate ;            
        }

        private StackLayout GetFooterTemplate()
        {
            StackLayout stackFooterTemplate = new StackLayout
            {
                Padding = 5,
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.Red,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var footer = new Label { FontAttributes = FontAttributes.Bold };

            footer.Text = DateTime.Now.ToString("dd/MM/yyyy");
            footer.TextColor = Color.GreenYellow;
            footer.HorizontalOptions = LayoutOptions.EndAndExpand;
            footer.VerticalOptions = LayoutOptions.CenterAndExpand;

            stackFooterTemplate.Children.Add(footer);

            return stackFooterTemplate;
        }
    }
}
