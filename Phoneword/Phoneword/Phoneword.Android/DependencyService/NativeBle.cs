using Android.Bluetooth;
using Android.Widget;
using Java.Util;
using Phoneword.Droid.DependencyService;
using Phoneword.Models;
using Phoneword.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(NativeBle))]
namespace Phoneword.Droid.DependencyService
{
    public class NativeBle : IBleService
    {
        public string MessageToSend { get; set; } = "0";

        BluetoothDevice paredDevice = null;

        BluetoothSocket bthSocket = null;

        WsBluetoothGattCallback wsBluetoothGattCallback = new WsBluetoothGattCallback();

        private static BluetoothAdapter mBluetoothAdapter = null;
        private double timeOut = 10;
        public Action OnConnect { get; set; }
        public Action<BluetoothDeviceBase> OnDiscover { get; set; }

        public NativeBle()
        {

            mBluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            //verificamos que no sea nulo el sensor
            if (mBluetoothAdapter == null)
            {
                Toast.MakeText(MainActivity.Instance.BaseContext, "NULO", ToastLength.Long);
            }

            //Verificamos que este habilitado
            if (!mBluetoothAdapter.Enable())
            {
                Toast.MakeText(MainActivity.Instance.BaseContext, "NOT ENABLE", ToastLength.Long);
            }

        }

        private static UUID MY_UUID = UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");


        public async Task Connect(BluetoothDeviceBase bluetoothDeviceBase)
        {

            try
            {
                if (mBluetoothAdapter.IsEnabled)
                {
                    mBluetoothAdapter.CancelDiscovery();
                }

                await ConnectDevice(bluetoothDeviceBase.Name);

            }
            catch (System.Exception eX)
            {
                //en caso de generarnos error cerramos el socket
                string err = eX.Message;
                try
                {
                    //btSocket.Close();

                }
                catch (System.Exception se)
                {
                    string msg2 = se.Message;
                    await Task.Delay(100);
                }

                await Task.Delay(100);
            }

            await Task.Delay(100);
        }

        public async Task Scan()
        {

            try
            {
                mBluetoothAdapter.StartDiscovery();

                foreach (var bd in mBluetoothAdapter.BondedDevices)
                {
                    System.Diagnostics.Debug.WriteLine("Paired devices found: " + bd.Name.ToUpper());
                    if (OnDiscover != null)
                    {
                        OnDiscover.Invoke(new BluetoothDeviceBase(bd.Address, bd.Name));
                    }
                }

                mBluetoothAdapter.CancelDiscovery();
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
            }
        }

        public async void WriteData(char data)
        {
            try
            {
                if (paredDevice == null)
                    System.Diagnostics.Debug.WriteLine("Named device not found.");
                else
                {
                    UUID uuid = UUID.FromString("00001101-0000-1000-8000-00805f9b34fb");
                    bthSocket = null;
                    bthSocket = paredDevice.CreateInsecureRfcommSocketToServiceRecord(uuid);

                    if (bthSocket != null)
                    {

                        await bthSocket.ConnectAsync();

                        if (bthSocket.IsConnected)
                        {
                            System.Diagnostics.Debug.WriteLine("Connected!");

                            byte[] toSend = new byte[1];
                            toSend[0] = (byte)data;

                            await bthSocket.OutputStream.WriteAsync(toSend, 0, toSend.Count());

                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Not Connected!");

                        }

                        await Task.Delay(1500);
                        if (bthSocket != null)
                        {
                            bthSocket.Close();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR ONE:... " + ex.Message);
                try
                {


                }
                catch (Exception ex2)
                {

                    System.Diagnostics.Debug.WriteLine("ERROR TWO:... " + ex2.Message);
                }
            }


        }



        private async void writeDataLegace(Java.Lang.String data)
        {


            //Extraemos el stream de salida
            try
            {

            }
            catch (System.Exception e)
            {
                System.Console.WriteLine("Error al enviar" + e.Message);
            }


        }

        public List<string> PairedDevices()
        {

            List<string> devices = new List<string>();

            foreach (var bd in mBluetoothAdapter.BondedDevices)
                devices.Add(bd.Name);

            return devices;
        }
        private async Task ConnectDevice(string name)
        {
            try
            {

                await Task.Delay(500);

                if (mBluetoothAdapter == null)
                    System.Diagnostics.Debug.WriteLine("No Bluetooth adapter found.");
                else
                    System.Diagnostics.Debug.WriteLine("Adapter found!!");

                if (!mBluetoothAdapter.IsEnabled)
                    System.Diagnostics.Debug.WriteLine("Bluetooth adapter is not enabled.");
                else
                    System.Diagnostics.Debug.WriteLine("Adapter enabled!");

                System.Diagnostics.Debug.WriteLine("Try to connect to " + name);

                paredDevice = mBluetoothAdapter.BondedDevices.Where(d => d.Name == name).FirstOrDefault();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DEVICE CONNECT ERROR: " + ex.Message);
            }
            finally
            {


            }

        }
    }
}