using Phoneword.Models;
using System;
using System.Threading.Tasks;

namespace Phoneword.Utils
{
    public interface IBleService
    {
        Task Scan();
        Task Connect(BluetoothDeviceBase deviceBase);
        void WriteData(char data);
        Action<string> OnConnect { get; set; }
        Action<BluetoothDeviceBase> OnDiscover { get; set; }
        
    }
}
