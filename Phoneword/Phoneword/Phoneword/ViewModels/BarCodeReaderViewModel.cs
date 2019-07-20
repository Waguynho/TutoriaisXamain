using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;
using static ZXing.Net.Mobile.Forms.ZXingScannerPage;

namespace Phoneword.ViewModels
{
    public class BarCodeReaderViewModel: ViewModelBase, IBarCodeReaderViewModel
    {
        public BarCodeReaderViewModel(IPageContext context) : base(context)
        {
            IsCanning = true;
            OnScanResult = ProcessResul;
        }
        

        private void ProcessResul(Result result)
        {
            TextResult =  string.Concat(result.Text," Format: ",result.BarcodeFormat,", País: " ,result.ResultMetadata[ResultMetadataType.POSSIBLE_COUNTRY]);
            if (ResultCallBack != null)
            {
                ResultCallBack.Invoke(TextResult);
                IsCanning = false;                
            }
        }

        private ScanResultDelegate onScanResult;

        public ScanResultDelegate OnScanResult
        {
            get { return onScanResult; }
            set
            {
                SetProperty(ref onScanResult, value);
            }
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

        public Action<string> ResultCallBack { get; set; }
    }
}
