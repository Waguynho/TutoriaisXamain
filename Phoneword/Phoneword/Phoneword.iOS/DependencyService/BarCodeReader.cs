using System;
using System.Threading.Tasks;
using Phoneword.iOS.DependencyService;
using Phoneword.Utils;
using Xamarin.Forms;
using ZXing.Mobile;


[assembly: Dependency(typeof(BarCodeReader))]
namespace Phoneword.iOS.DependencyService
{
    public class BarCodeReader: IBarCodeReader
    {
        private MobileBarcodeScanner scanner;
        public Action<string> ResultCallBack { get; set; }

        public BarCodeReader()
        {
        }

        public async Task Scan()
        {
            scanner = new ZXing.Mobile.MobileBarcodeScanner();

            var options = GetFormats();

            var result = await scanner.Scan(options);

            if (result != null && ResultCallBack != null)
            {
                ResultCallBack.Invoke(result.Text);
            }
        }

        private MobileBarcodeScanningOptions GetFormats()
        {
            var options = new MobileBarcodeScanningOptions();
            options.PossibleFormats = new System.Collections.Generic.List<ZXing.BarcodeFormat> {
                ZXing.BarcodeFormat.CODABAR,
                ZXing.BarcodeFormat.CODE_128,
                ZXing.BarcodeFormat.DATA_MATRIX,
                ZXing.BarcodeFormat.EAN_13,
                ZXing.BarcodeFormat.QR_CODE,
                ZXing.BarcodeFormat.EAN_8,
                ZXing.BarcodeFormat.ITF
            };
            return options;
        }
    }
}
