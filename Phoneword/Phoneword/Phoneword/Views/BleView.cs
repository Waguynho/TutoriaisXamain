using Phoneword.Styles;
using Phoneword.Utils;
using Phoneword.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Phoneword.Views
{
    public class BleView: ContentPage, IBleView
    {
        public BleView()
        {
            CreateLayout();
        }

        private void CreateLayout()
        {
            Title = "Bluetooth Ws";
            BackgroundColor = Statics.PageBackGroudColor;

            Button btnScan = new Button
            {
                Text = "Scan",
                Style = StylesButton.ButtonDefault
            };

            btnScan.SetBinding(Button.CommandProperty, "ScanCommand");

            Button btnConnect = new Button
            {
                Text = "Connect",
                Style = StylesButton.ButtonDefault
            };

            btnConnect.SetBinding(Button.CommandProperty, "ConnectCommand");

            Button btgWrite = new Button
            {
                Text = "Send Data",
                Style = StylesButton.ButtonDefault
            };

            btgWrite.SetBinding(Button.CommandProperty, "WriteCommand");

            Xamarin.Forms.Switch toogleButton = new Xamarin.Forms.Switch();

            toogleButton.SetBinding(Xamarin.Forms.Switch.IsToggledProperty, "IsToggled", BindingMode.OneWayToSource);
            toogleButton.HorizontalOptions = LayoutOptions.FillAndExpand;
            toogleButton.BackgroundColor = Color.FromHex("#C9EBE4");
            toogleButton.ThumbColor = Color.Red;
            toogleButton.OnColor = Color.Green;
            //toogleButton.Scale = 2;
            toogleButton.WidthRequest = 70;
            toogleButton.HeightRequest = 80;

            var listView = new ListView
            {
                RowHeight = 40
            };

            listView.ItemTemplate = GetDataTemplate();
            listView.SeparatorColor = Color.White;

            listView.SetBinding(ListView.ItemsSourceProperty, "Devices", BindingMode.Default);
            listView.SetBinding(ListView.SelectedItemProperty, "SelectedItem", BindingMode.TwoWay);
            listView.VerticalOptions = LayoutOptions.FillAndExpand;


            Label feedback = new Label();
            feedback.HorizontalOptions = LayoutOptions.Center;
            feedback.VerticalOptions = LayoutOptions.FillAndExpand;
            feedback.Margin = new Thickness(5, 20);
            feedback.FontSize = Device.GetNamedSize(NamedSize.Large, feedback);
            feedback.TextColor = Color.White;
            feedback.FontAttributes = FontAttributes.Bold;
            feedback.SetBinding(Label.TextProperty, "Feedback", BindingMode.OneWay);

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {btnScan, btnConnect , toogleButton, /*btgWrite,*/ listView, feedback }
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

                var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                var addressLabel = new Label();

                nameLabel.SetBinding(Label.TextProperty, "Name");
                nameLabel.TextColor = Color.White;
                nameLabel.HorizontalOptions = LayoutOptions.Start;

                addressLabel.SetBinding(Label.TextProperty, new Binding("Address", BindingMode.TwoWay));
                addressLabel.HorizontalOptions = LayoutOptions.EndAndExpand;
                addressLabel.TextColor = Color.White;

                stackDataTemplate.Children.Add(nameLabel);
                stackDataTemplate.Children.Add(addressLabel);

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
    }
}
