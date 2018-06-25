using Phoneword.Localization;
using Phoneword.Utils;
using Phoneword.Views.Interfaces;
using System.Collections.Generic;
using Xamarin.Forms;


namespace Phoneword
{
    public partial class MainPage : ContentPage, IMainPage
    {
        public static string TranslatedNumber;
        public static IList<string> PhoneNumbers { get; set; }

        public MainPage()
        {
            InitializeComponent();
            PhoneNumbers = new List<string>();
            callButton.Text = LanguageResource.call;
            callButton.BackgroundColor = Statics.ButtonColor;
        }
    }
}