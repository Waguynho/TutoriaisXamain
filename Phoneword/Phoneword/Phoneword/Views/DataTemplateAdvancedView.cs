using Phoneword.Converters;
using Phoneword.Localization;
using Phoneword.Utils;
using Phoneword.Views.Interfaces;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Phoneword.Views
{
    public class DataTemplateAdvancedView : ContentPage, IDataTemplateAdvancedView
    {
        readonly BoolAnyConverter<string> templateText = new BoolAnyConverter<string>("Feito", "Em aberto");
        readonly BoolColorConverter templateTextColor = new BoolColorConverter(Color.GreenYellow, Color.Red);
        readonly BoolColorConverter headerTextColor = new BoolColorConverter(Color.Yellow, Color.White);

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
            listView.GroupHeaderTemplate = GetHeaderTemplate();
            listView.Footer = GetFooterTemplate();
            listView.SeparatorColor = Color.White;

            listView.SetBinding(ListView.ItemsSourceProperty, "Groups", BindingMode.Default);
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

                done.SetBinding(Label.TextProperty, new Binding("Done", BindingMode.TwoWay, templateText));
                done.HorizontalOptions = LayoutOptions.EndAndExpand;
                done.SetBinding(Label.TextColorProperty, new Binding("Done", BindingMode.TwoWay, templateTextColor));

                stackDataTemplate.Children.Add(task);
                stackDataTemplate.Children.Add(done);

                var moreAction = new MenuItem { Text = "More" };
                moreAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));

                moreAction.Clicked += (sender, e) =>
                {
                    var mi = ((MenuItem)sender);
                    Debug.WriteLine("More Context Action clicked: " + mi.CommandParameter);
                };

                MenuItem detailAction = new MenuItem { Text = "Detail" };
                detailAction.SetBinding(MenuItem.CommandProperty, new Binding("DetailCommand", BindingMode.TwoWay, null, null, null, this.BindingContext));
                detailAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));

                var viewCell = new ViewCell { View = stackDataTemplate };
                viewCell.ContextActions.Add(moreAction);
                viewCell.ContextActions.Add(detailAction);

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

                title.SetBinding(Label.TextProperty, new Binding("KeyGroup", BindingMode.Default, templateText));
                title.SetBinding(Label.TextColorProperty, "KeyGroup", BindingMode.TwoWay, headerTextColor);
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
