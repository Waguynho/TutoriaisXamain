﻿using Phoneword.Views.Interfaces;
using System;
using Xamarin.Forms;

namespace Phoneword.Views
{
    public class WebInterfaceView : ContentPage, IWebInterfaceView
    {
        public WebInterfaceView()
        {
            SetTitleView();
        }

        private void SetTitleView()
        {
            Title = "Web View Sample";
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            CreateLayout();
        }

        private void CreateLayout()
        {
            Label subTitle = new Label();
            subTitle.Text = "Web View";
            subTitle.BackgroundColor = Color.White;
            subTitle.TextColor = Color.Red;
            subTitle.Margin = 3;
            subTitle.FontAttributes = FontAttributes.Bold;
            subTitle.VerticalOptions = LayoutOptions.Fill;
            subTitle.HorizontalOptions = LayoutOptions.CenterAndExpand;

            WebView web = new WebView();
            web.VerticalOptions = LayoutOptions.FillAndExpand;
            web.HorizontalOptions = LayoutOptions.FillAndExpand;
            web.BackgroundColor = Color.Pink;
            //web.Source = "https://wagner.santos.wscompany.com.br/";

            HtmlWebViewSource htmlWebViewSource = new HtmlWebViewSource();
            htmlWebViewSource.SetBinding(HtmlWebViewSource.BaseUrlProperty, "BaseAssetUrl");
            htmlWebViewSource.SetBinding(HtmlWebViewSource.HtmlProperty, "HtmlContent");

            web.Source = htmlWebViewSource;
            web.BackgroundColor = Color.Blue;
            web.VerticalOptions = LayoutOptions.FillAndExpand;
            web.HorizontalOptions = LayoutOptions.FillAndExpand;

            StackLayout statckView = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Padding = 3,
                Children = { subTitle, web},
                BackgroundColor = Color.Red
            };

            Content = statckView;
        }
    }
}
