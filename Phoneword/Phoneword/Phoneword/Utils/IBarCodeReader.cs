using System;
using System.Threading.Tasks;

namespace Phoneword.Utils
{
    public interface IBarCodeReader
    {
        Action<string> ResultCallBack { get; set; }
        Task Scan();
    }
}
