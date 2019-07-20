using System;

namespace Phoneword.ViewModels.Interfaces
{
    public interface IBarCodeReaderViewModel : IViewModel
    {
        Action<string> ResultCallBack { get; set; }
    }
}
