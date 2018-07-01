using Phoneword.Converters;
using Phoneword.Localization;
using Phoneword.Utils;
using Phoneword.Views.Interfaces;
using System;
using Xamarin.Forms;

namespace Phoneword.Views
{
    public class DataTemplateAdvancedView : ContentPage, IDataTemplateAdvancedView
    {
        BoolToColorConverter convertColor = new BoolToColorConverter();

        public DataTemplateAdvancedView()
        {
            CreateLayout();
        }

        private void CreateLayout()
        {
            Title = LanguageResource.task_list;
            BackgroundColor = Statics.PageBackGroudColor;

            var listView = new ListView
            {
                RowHeight = 40
            };

            listView.IsGroupingEnabled = true;
            listView.ItemTemplate = GetDataTemplate();
            listView.Footer = GetFooterTemplate();
            listView.GroupHeaderTemplate = GetHeaderTemplate();

            listView.SetBinding(ListView.ItemsSourceProperty, "Groups", BindingMode.OneWay);
            listView.SetBinding(ListView.SelectedItemProperty, "SelectedItem", BindingMode.TwoWay);


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

                stackDataTemplate.SetBinding(StackLayout.BackgroundColorProperty, "BackGroundCell");

                var task = new Label { FontAttributes = FontAttributes.Bold };
                var done = new Label();

                task.SetBinding(Label.TextProperty, "Name");
                task.TextColor = Color.White;
                task.HorizontalOptions = LayoutOptions.Start;

                done.SetBinding(Label.TextProperty, "Done");
                done.HorizontalOptions = LayoutOptions.EndAndExpand;

                convertColor.Convert(this, typeof(Color), null, null);
                done.SetBinding(Label.TextColorProperty, new Binding("Done", BindingMode.TwoWay, convertColor));

                stackDataTemplate.Children.Add(task);
                stackDataTemplate.Children.Add(done);

                var viewCell = new ViewCell { View = stackDataTemplate };
                viewCell.SetBinding(View.BackgroundColorProperty, "BackGroundCell");
                return viewCell;
            });
        }

        private DataTemplate GetHeaderTemplate()
        {
            return new DataTemplate(() =>
            {

                StackLayout stackHeaderTemplate = new StackLayout
                {
                    Padding = 5,
                    Orientation = StackOrientation.Horizontal,
                    BackgroundColor = Color.Orange,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                stackHeaderTemplate.BackgroundColor = Color.Purple;

                var title = new Label { FontAttributes = FontAttributes.Bold };

                title.SetBinding(Label.TextProperty, "KeyGroup");
                title.TextColor = Color.Yellow;
                title.HorizontalOptions = LayoutOptions.CenterAndExpand;
                title.VerticalOptions = LayoutOptions.CenterAndExpand;

                stackHeaderTemplate.Children.Add(title);
                var viewCell = new ViewCell { View = stackHeaderTemplate };
                return viewCell;
            });
        }

        private StackLayout GetFooterTemplate()
        {
            StackLayout stackFooterTemplate = new StackLayout
            {
                Padding = 5,
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.Black,
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
