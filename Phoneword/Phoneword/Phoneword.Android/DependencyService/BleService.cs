using Android.Bluetooth;
using Android.Util;
using Android.Widget;
using BluetoothLE.Core;
using Java.Util;
using Phoneword.Droid.DependencyService;
using Phoneword.Models;
using Phoneword.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
//[assembly: Dependency(typeof(BleService))]
namespace Phoneword.Droid.DependencyService
{
    public class BleService : IBleService
    {
        private string namesChar = string.Empty;
        private double timeOut = 10;
        private IList<BluetoothDeviceBase> Devices;
        private static BluetoothLE.Core.IAdapter _bluetoothAdapter;


        public Action OnConnect { get; set; }
        public Action<BluetoothDeviceBase> OnDiscover { get; set; }
        public BleService()
        {
            Initialize();
        }
        public virtual void Initialize()
        {

            Devices = new List<BluetoothDeviceBase>();
            if (_bluetoothAdapter == null)
            {
                _bluetoothAdapter = Xamarin.Forms.DependencyService.Get<BluetoothLE.Core.IAdapter>(DependencyFetchTarget.GlobalInstance);
            }
            _bluetoothAdapter.ScanTimeout = TimeSpan.FromSeconds(timeOut);
            _bluetoothAdapter.ConnectionTimeout = TimeSpan.FromSeconds(timeOut);
            _bluetoothAdapter.DeviceConnected += OnDeviceConected;
            _bluetoothAdapter.DeviceDiscovered += OnDeviceDiscovered;
            _bluetoothAdapter.DeviceDisconnected += OnDisconnected;
            _bluetoothAdapter.DeviceFailedToConnect += OnFailConnect;
            _bluetoothAdapter.ScanTimeoutElapsed += OnTimeout;

          

        }

        private void OnTimeout(object sender, EventArgs e)
        {
            var response = sender;
            Type type = response.GetType();
        }

        private void OnFailConnect(object sender, BluetoothLE.Core.Events.DeviceConnectionEventArgs e)
        {
            string message = e.ErrorMessage;
        }

        public async Task Scan()
        {
            await Task.Run(() =>
           {
               if (_bluetoothAdapter.IsScanning == false)
               {
                   Devices.Clear();
                   _bluetoothAdapter.StartScanningForDevices();
               }
               
           });
        }

        private void OnDisconnected(object sender, BluetoothLE.Core.Events.DeviceConnectionEventArgs e)
        {
            string msdDisconected = e.ErrorMessage;
        }

        private void OnDeviceDiscovered(object sender, BluetoothLE.Core.Events.DeviceDiscoveredEventArgs e)
        {
           // BluetoothDeviceBase e 

            //if (Devices.All(x => x.Address != e.Device))
            //{
            //    Devices.Add(e.Device);
            //    BluetoothDevice bluetoothDevice = (BluetoothDevice)e.Device.NativeDevice;
            //    if (OnDiscover != null)
            //    {
            //        OnDiscover.Invoke(bluetoothDevice.Address);
            //    }
            //}
        }

        private void OnDeviceConected(object sender, BluetoothLE.Core.Events.DeviceConnectionEventArgs e)
        {
            var device = e.Device;
            //Devices.Remove(device);
            //Devices.Add(device);

            device.DiscoverServices();
            device.ServiceDiscovered += OnServicesDiscover;
            var id = e.Device.Id;
            var name = e.Device.Name;
            var native = e.Device.NativeDevice;
            if (OnConnect != null)
            {
                OnConnect.Invoke();
            }

          

            Log.Debug("WSD", "============ DEVICE");
            Log.Debug("WSD", string.Concat("Name: ", name, " ID: ", id.ToString(), " Native: ", native, " Rssi: ", device.Rssi));
            _bluetoothAdapter.StopScanningForDevices();
        }

        private void OnServicesDiscover(object sender, BluetoothLE.Core.Events.ServiceDiscoveredEventArgs e)
        {
            var Service = e.Service;
            Log.Debug("WSD", "============ Service");
            Log.Debug("WSD", string.Concat("IsPrimary: ", Service.IsPrimary, " ID: ", Service.Id.ToString(), Service.ToString()));
            Service.CharacteristicDiscovered += OnCharacteristicDiscovered;
            Service.DiscoverCharacteristics();
        }

        private void OnCharacteristicDiscovered(object sender, BluetoothLE.Core.Events.CharacteristicDiscoveredEventArgs e)
        {
            try
            {
                var characteristic = e.Characteristic;
                Log.Debug("WSD", "============ Characteristic");

                if (characteristic.CanRead && characteristic.CanWrite)
                {
                    characteristic.Read();
                    if (characteristic.Value != null)
                    {
                        string value = UTF8Encoding.ASCII.GetString(characteristic.Value);
                        Log.Debug("WSD", string.Concat(" READ AND WRITE: ", characteristic.StringValue, " Value: ", value));
                    }

                }
                else if (characteristic.CanWrite || characteristic.CanUpdate)
                {
                    
                    if (characteristic.Value != null)
                    {
                        string value = UTF8Encoding.ASCII.GetString(characteristic.Value);
                        Log.Debug("WSD", string.Concat("JUST WRITE/UPDATE: ", characteristic.StringValue, " Value: ", value));
                    }
                }
                else if (characteristic.CanRead)
                {
                    characteristic.Read(); 
                    if (characteristic.Value != null)
                    {
                        string value = UTF8Encoding.ASCII.GetString(characteristic.Value);
                        Log.Debug("WSD", string.Concat("JUST READ: ", characteristic.StringValue, " Value: ", value));
                    }
                }


                LogDescriptors();
            }
            catch (Exception R)
            {
                Log.Debug("WSD ERROR", R.Message);
                int X;
            }

        }

        private static void LogDescriptors()
        {
            //foreach (var des in native.Descriptors)
            //{
            //    if (des.GetValue() != null)
            //    {
            //        string desvalue = UTF8Encoding.UTF8.GetString(des.GetValue());
            //        Log.Debug("WSD", string.Concat("Descriptor: ", desvalue, " UIID:", des.Uuid));
            //    }
            //    else
            //    {

            //        Log.Debug("WSD", string.Concat("Descriptor: ", des.DescribeContents(), " UIID:", des.Uuid));
            //    }

            //}
        }

        public void WriteData(char data)
        {
            try
            {
                //IDevice device = _bluetoothAdapter.ConnectedDevices.First();
                //string name = device.Name;
                //BluetoothLE.Core.Extensions.Write(
                //    device,
                //    device.Services[0].Id.ToString(),
                //    device.Services[0].Characteristics[3].Uuid,
                //    new byte[] { Convert.ToByte(data) });

            }
            catch (Exception R)
            {
                Log.Debug("WSD ERROR", R.Message);
                int X;
            }


        }
      
        public Task Connect(BluetoothDeviceBase deviceId)
        {
            try
            {
                return Task.Run(async () =>
                 {
                     //var selected = Devices.First<IDevice>(d => d.Id == new Guid(deviceId));
                     //_bluetoothAdapter.ConnectToDevice(selected);

                  
                 });
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return Task.Delay(100);
            }

        }
    }
}