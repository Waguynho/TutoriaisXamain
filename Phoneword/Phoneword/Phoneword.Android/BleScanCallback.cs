using Android.Bluetooth;
using Java.Interop;
using Phoneword.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static Android.Bluetooth.BluetoothAdapter;

namespace Phoneword.Droid
{
    public class BleScanCallback : Java.Lang.Object,  ILeScanCallback
    {
        public BleScanCallback()
        {
            this.SetJniIdentityHashCode(1);
            DiscoveredDevices = new List<BluetoothDevice>(10);
        }

        public List<BluetoothDevice> DiscoveredDevices { get; set; }
        public Action<BluetoothDeviceBase> OnDiscover { get; set; }

        public JniManagedPeerStates JniManagedPeerState { get; }

  
        public void Disposed()
        {
            
        }

        public void DisposeUnlessReferenced()
        {
            
        }

        public void Finalized()
        {
            
        }

        public void OnLeScan(BluetoothDevice device, int rssi, byte[] scanRecord)
        {
            if (OnDiscover != null && device.Type == BluetoothDeviceType.Le)
            {
                BluetoothDeviceBase bluetoothDeviceBase = new BluetoothDeviceBase(device.Address, device.Name);
                OnDiscover.Invoke(bluetoothDeviceBase);
                if (DiscoveredDevices.Any(d => d.Address == device.Address) == false)
                {
                    DiscoveredDevices.Add(device);
                }
            }
        }

        public void SetJniIdentityHashCode(int value)
        {
            
        }

        public void SetJniManagedPeerState(JniManagedPeerStates value)
        {
            
        }

        public void SetPeerReference(JniObjectReference reference)
        {
            
        }
    }
}