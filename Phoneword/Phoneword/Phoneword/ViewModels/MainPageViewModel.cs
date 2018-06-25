using Phoneword.Localization;
using Phoneword.Utils;
using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class MainPageViewModel : ViewModelBase, IMainPageViewModel
    {
        private string titleMainPage = "XXx";

        public string TitleMainPage
        {
            get { return titleMainPage; }
            set
            {
                SetProperty(ref titleMainPage, value);
            }
        }

        private string translatedNumber;

        public string TranslatedNumber
        {
            get { return translatedNumber; }
            set
            {
                SetProperty(ref translatedNumber, value);
            }
        }

        private string callButtonText;

        public string CallButtonText
        {
            get { return callButtonText; }
            set
            {
                SetProperty(ref callButtonText, value);
            }
        }

        public Color ButtonColor
        {
            get
            {
                return Statics.ButtonColor;
            }
        }
        public MainPageViewModel(IPageContext pageContext) : base(pageContext)
        {
            CallCommand = new Command(ExecuteCall);
            CallHistoryCommand = new Command(ExecuteCallHistory);
            TranslateCommand = new Command(ExecuteTranslate);
            ShowMonsterCommand = new Command(ExecuteShowMonster);
            TranslatedNumber = "Digite um texto";
            CallButtonText = LanguageResource.call;
        }

        public ICommand CallCommand { private set; get; }

        public void ExecuteCall()
        {
            try
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    var result = dialer.Dial(MainPage.TranslatedNumber);

                    if (string.IsNullOrEmpty(MainPage.TranslatedNumber) == false)
                    {
                        MainPage.PhoneNumbers.Add(MainPage.TranslatedNumber);
                    }
                }

                TitleMainPage = (TitleMainPage != "XXx") ? "XXx" : "Título A";
            }
            catch (Exception ex)
            {
                PageContext.CurrentPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public ICommand CallHistoryCommand { get; set; }

        public void ExecuteCallHistory()
        {
            this.PageContext.NavigateTo<ICallHistoryView, ICallHistoryViewModel>();
        }

        public ICommand TranslateCommand { get; set; }

        public void ExecuteTranslate()
        {
            MainPage.TranslatedNumber = Core.PhonewordTranslator.ToNumber(TranslatedNumber);

            if (!string.IsNullOrWhiteSpace(TranslatedNumber))
            {
                // callButton.IsEnabled = true;
                CallButtonText = LanguageResource.call + " " + MainPage.TranslatedNumber;
            }
            else
            {
                //callButton.IsEnabled = false;
                CallButtonText = LanguageResource.call;
            }
        }

        public ICommand ShowMonsterCommand { get; set; }

        public void ExecuteShowMonster()
        {
            this.PageContext.NavigateTo<IHelloMonsterView, IHelloMonsterViewModel>();
        }
    }
}
