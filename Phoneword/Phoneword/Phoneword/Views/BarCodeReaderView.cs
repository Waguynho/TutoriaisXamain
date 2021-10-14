using Phoneword.Styles;
using Phoneword.Views.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;


namespace Phoneword.Views
{
    public class BarCodeReaderView : ContentPage, IBarCodeReaderView
    {
    

        public BarCodeReaderView()
        {
            Title = "Read Bar Code";

            Label resultText = new Label();
            resultText.SetBinding(Label.TextProperty, "TextResult");


            Button scanButton = new Button
            {
                Text = "Scan Code",
                Style = StylesButton.ButtonDefault
            };

            scanButton.SetBinding(Button.CommandProperty, "ReadBarCodeCommand");

            StackLayout stackMain = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { scanButton ,resultText },
                Padding = 5,
                HeightRequest = 10
            };

            this.BackgroundColor = Color.Purple;

         
            Content = stackMain;
        }

      
    }
}
