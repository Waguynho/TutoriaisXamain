using Phoneword.Utils;
using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class BarCodeReaderViewModel: ViewModelBase, IBarCodeReaderViewModel
    {
        public ICommand ReadBarCodeCommand { private set; get; }

        public BarCodeReaderViewModel(IPageContext context) : base(context)
        {
            ReadBarCodeCommand = new Command(ExecuteScan);
        }


        private void ProcessResul(string result)
        {
            TextResult =  result;
            IsCanning = false;

        }


        private bool isCanning;
        public bool IsCanning
        {
            get { return isCanning; }
            set
            {
                SetProperty(ref isCanning, value);
            }
        }

        private  string  textResult = "Waiting for read";

        public string TextResult
        {
            get { return textResult; }
            set
            {
                SetProperty(ref textResult, value);
            }
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

        }


        public async void ExecuteScan()
        {
            try
            {
                IsCanning = true;

                var scanner = DependencyService.Get<IBarCodeReader>();
                scanner.ResultCallBack = ProcessResul;
                await scanner.Scan();
            }
            catch (Exception ex)
            {
                await PageContext.CurrentPage.DisplayAlert("Erro", ex.Message, "OK");
                IsCanning = true;

            }
        }
    }
}
