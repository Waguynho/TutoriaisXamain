using Android.Bluetooth;
using Android.Runtime;

namespace Phoneword.Droid
{
    public class WsBluetoothGattCallback : BluetoothGattCallback
    {
        public override void OnConnectionStateChange(BluetoothGatt gatt, [GeneratedEnum] GattStatus status, [GeneratedEnum] ProfileState newState)
        {
            if (newState == ProfileState.Disconnected)
            {
                //gatt.Connect();

               // base.OnConnectionStateChange(gatt, status, newState);
            }
            else
            {
                base.OnConnectionStateChange(gatt, status, newState);
            }

        }

         
    }
}