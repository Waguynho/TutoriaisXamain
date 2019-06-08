using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class ThousandRowsViewModel : ViewModelBase, IThousandRowsViewModel
    {
        public ThousandRowsViewModel(IPageContext context) : base(context)
        {
            RepeatCommand = new Command(Repeat);
        }


        private int limitRepetition;

        public int LimitRepetition
        {
            get { return limitRepetition; }
            set
            {
                SetProperty(ref limitRepetition, value);
            }
        }

        private string copyText;

        public string CopyText
        {
            get { return copyText; }
            set
            {
                SetProperty(ref copyText, value);
            }
        }

        private string repeatText;

        public string RepeatText
        {
            get { return repeatText; }
            set
            {
                SetProperty(ref repeatText, value);
            }
        }

        private ICommand repeatCommand;

        public ICommand RepeatCommand
        {
            get { return repeatCommand; }
            set
            {
                SetProperty(ref repeatCommand, value);
            }
        }
        private async void Repeat()
        {
            if (IsExpiredLicense())
            {
                bool confirm = await PageContext.ShowMessage("Aviso!", "Licensa expirada, deseja renova-la?", "Sim", "Não");

                if (confirm)
                {
                    await PageContext.ShowMessage("...", "Faça uma vídeo chamada!", "OK");
                }
            }
            else
            {
                SetRepeatSentence();
            }
        }

        private void SetRepeatSentence()
        {
            string copy = string.Empty;

            for (int i = 0; i < LimitRepetition; i++)
            {
                if (isSecretWord())
                {
                    ShowSecretSentence();
                    break;
                }
                copy += CopyText + "\n";
            }

            RepeatText = copy;
        }

        private bool isSecretWord()
        {

            if (!string.IsNullOrEmpty(CopyText) && CopyText.ToLower().Contains("maria") && CopyText.ToLower().Contains("paula"))
            {
                return true;
            }

            return false;
        }

        private bool IsExpiredLicense()
        {
            DateTime limiteDate = new DateTime(2019, 08, 15, 15, 30, 59);

            if (DateTime.Now > limiteDate)
            {
                return true;
            }

            return false;
        }

        private void ShowSecretSentence()
        {
            PageContext.ShowMessage("Aviso", "Minha Rainda!", "verdade");
        }

        private void SetDefualValues()
        {
            LimitRepetition = 30;
            CopyText = "paula maria";
        }

        public override void AfterBinding()
        {
            base.AfterBinding();

            //SetDefualValues();
        }
    }
}
