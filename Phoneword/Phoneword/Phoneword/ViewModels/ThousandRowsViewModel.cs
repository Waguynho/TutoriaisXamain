using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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
        private void Repeat()
        {
            string copy = string.Empty;

            for (int i = 0; i < LimitRepetition; i++)
            {
                copy += CopyText + "\n";
            }

            RepeatText = copy;
            //if (LimitRepetition < 2000)
            //{
            //    PageContext.ShowMessage("titulo", "< 2000", "ok");
            //}

        }
    }
}
