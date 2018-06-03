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
            Title = "Main Page";
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
            try
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    var result = dialer.Dial(translatedNumber);
                    PhoneNumbers.Add(translatedNumber);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        async void OnCallHistory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CallHistoryPage(PhoneNumbers));
        }

        async void OnHelooMonster(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelloMonsterView());
        }

    }
}