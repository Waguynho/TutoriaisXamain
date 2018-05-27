using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        string translatedNumber;
        public static IList<string> PhoneNumbers { get; set; }

        public MainPage()
        {
            InitializeComponent();
            PhoneNumbers = new List<string>();
        }

        void OnTranslate(object sender, EventArgs e)
        {


            translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);

            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                    "Dial a Number",
                    "Would you like to call " + translatedNumber + "?",
                    "Yes",
                    "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    dialer.Dial(translatedNumber);
                    PhoneNumbers.Add(translatedNumber);
                }
            }
        }

        async void OnCallHistory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CallHistoryPage(PhoneNumbers));
        }
    }
}