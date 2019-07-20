using Phoneword.Views.Interfaces;
using System;
using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace Phoneword.Views
{
    public class BarCodeReaderView : ZXingScannerPage, IBarCodeReaderView
    {

        public ScanResultDelegate ResultCommand
        {
            get
            {

                return (ScanResultDelegate)GetValue(ResultCommandProperty);
            }
            set
            {
                SetValue(ResultCommandProperty, value);
            }
        }

        public static readonly BindableProperty ResultCommandProperty = BindableProperty.Create(
          propertyName: nameof(ResultCommand),
          returnType: typeof(ScanResultDelegate),
          declaringType: typeof(BarCodeReaderView),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnEnterChanged
          );

        private static void OnEnterChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as BarCodeReaderView).OnScanResult += (ScanResultDelegate)newValue;
        }

        public BarCodeReaderView()
        {
            Title = "Read Bar Code";

            Label resultText = new Label();
            resultText.SetBinding(Label.TextProperty, "TextResult");


            #region temp ws
            this.SetBinding(BarCodeReaderView.ResultCommandProperty, "OnScanResult");
            this.SetBinding(ZXingScannerPage.IsScanningProperty, "IsCanning");
            #endregion


            //this.OnScanResult += this.ScanView_OnScanResult;





            //scanView.SetBinding(ZXingScannerView.ScanResultCommandProperty, "OnScanResult");
            //scanView.SetBinding(ZXingScannerView.IsScanningProperty, "IsCanning");

            StackLayout stackMain = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { resultText },
                Padding = 5
            };

            ScrollView scroll = new ScrollView();
            scroll.Content = stackMain;

           // Content = scroll;
        }

        private void ScanView_OnScanResult(ZXing.Result result)
        {
            Console.WriteLine(result);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           // this.IsScanning = true;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //this.IsScanning = false;
        }
    }
}
