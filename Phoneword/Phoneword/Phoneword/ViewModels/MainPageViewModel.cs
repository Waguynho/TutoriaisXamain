using Phoneword.Localization;
using Phoneword.Utils;
using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class MainPageViewModel : ViewModelBase, IMainPageViewModel
    {
        public MainPageViewModel(IPageContext pageContext) : base(pageContext)
        {
            PhoneNumbers = new List<string>();
            CallCommand = new Command(ExecuteCall);
            CallHistoryCommand = new Command(ExecuteCallHistory);
            TranslateCommand = new Command(ExecuteTranslate);
            ShowMonsterCommand = new Command(ExecuteShowMonster);
            ShowThownsandRowsCommand = new Command(ExecuteShowThownsandRows);
            TranslatedNumber = "Digite um texto";
            CallButtonText = LanguageResource.call;
        }

        private IList<string> PhoneNumbers { get; set; }

        private string titleMainPage = "Título A";

        public string TitleMainPage
        {
            get { return titleMainPage; }
            set
            {
                SetProperty(ref titleMainPage, value);
            }
        }

        private bool callEnable = false;

        public bool CallEnable
        {
            get { return callEnable; }
            set
            {
                SetProperty(ref callEnable, value);
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


        public ICommand CallCommand { private set; get; }

        public void ExecuteCall()
        {
            try
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    var result = dialer.Dial(TranslatedNumber);

                    if (string.IsNullOrEmpty(TranslatedNumber) == false)
                    {
                        PhoneNumbers.Add(TranslatedNumber);
                    }
                }

                TitleMainPage = (TitleMainPage != "Título A") ? "Título A" : "Título B";
            }
            catch (Exception ex)
            {
                PageContext.CurrentPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public ICommand CallHistoryCommand { get; set; }

        public string Teste(int x)
        {
            return "Numbers";
        }

        public void ExecuteCallHistory()
        {
            PageContext.NavigateTo<ICallHistoryView, ICallHistoryViewModel>(vm => vm.Numbers = this.PhoneNumbers);
        }

        public ICommand TranslateCommand { get; set; }

        public void ExecuteTranslate()
        {
            string translated = Core.PhonewordTranslator.ToNumber(TranslatedNumber);

            if (!string.IsNullOrWhiteSpace(TranslatedNumber))
            {
                CallEnable = true;
                CallButtonText = LanguageResource.call + " " + translated;
            }
            else
            {
                CallEnable = false;
                CallButtonText = LanguageResource.call;
            }
        }

        public ICommand ShowMonsterCommand { get; set; }

        public void ExecuteShowMonster()
        {
            this.PageContext.NavigateTo<IHelloMonsterView, IHelloMonsterViewModel>();
        }

        public ICommand ShowThownsandRowsCommand { get; set; }

        public void ExecuteShowThownsandRows()
        {
            this.PageContext.NavigateTo<IThousandRowsView, IThousandRowsViewModel>();
        }
    }
}
