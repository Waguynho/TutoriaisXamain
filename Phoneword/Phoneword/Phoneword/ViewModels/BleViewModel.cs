using Phoneword.Models;
using Phoneword.Utils;
using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class BleViewModel : ViewModelBase, IBleViewModel
    {
        private IBleService bleService;
        public BleViewModel(IPageContext context) : base(context)
        {
            bleService = DependencyService.Get<IBleService>(DependencyFetchTarget.GlobalInstance);
            bleService.OnDiscover = OnDiscoverDevice;
            bleService.OnConnect = Connect;
            Devices = new ObservableCollection<BluetoothDeviceBase>();
            ScanCommand = new Command(ExecuteScan);
            ConnectCommand = new Command(ExecuteConnect);
            WriteCommand = new Command(ExecuteWrite);
        }

        private void ExecuteConnect()
        {
            if (SelectedItem != null)
            {
                _ = bleService.Connect(SelectedItem);
                Feedback = "CONECTADO!";
            }
        }

        private async void ExecuteScan()
        {
            try
            {
                Devices.Clear();
                await bleService.Scan();
            }
            catch (Exception e)
            {

                await PageContext.ShowMessage("error", e.Message, "OK");
            }

        }

        public ICommand ScanCommand { private set; get; }
        public ICommand ConnectCommand { private set; get; }
        public ICommand WriteCommand { private set; get; }

        private ObservableCollection<BluetoothDeviceBase> devices;

        public ObservableCollection<BluetoothDeviceBase> Devices
        {
            get { return devices; }
            set { SetProperty(ref devices, value); }
        }


        private BluetoothDeviceBase selectedItem;

        public BluetoothDeviceBase SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
        }

        private bool isToggled;

        public bool IsToggled
        {
            get { return isToggled; }
            set { SetProperty(ref isToggled, value); }
        }

        private string feedback = "Aguardando Ação...";
        public string Feedback
        {
            get { return feedback; }
            set { SetProperty(ref feedback, value); }
        }

        private async void ExecuteWrite(object arg)
        {
            await Task.Run(async () =>
            {
                if (arg != null && arg is char)
                {
                    bleService.WriteData((char)arg);
                }
                else
                {
                    bleService.WriteData('0');
                }

            });

            //await PageContext.CurrentPage.DisplayAlert("AVISO!", "Enviou dados", "CLOSE");
        }

        private void Connect(string connectMenssage)
        {
            try
            {

            }
            catch (Exception ex)
            {

                string msg = ex.Message;
            }
            //            PageContext.ShowMessage("CONECTED", "Device conected ", "OK");
        }

        private void OnDiscoverDevice(BluetoothDeviceBase deviceBase)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                if (!Devices.Any(d => d.Address == deviceBase.Address))
                {
                    Devices.Add(deviceBase);
                }

            });
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsToggled))
            {
                char charToSend = IsToggled ? '1' : '0';
                Feedback = IsToggled ? "DIREITA" : "ESQUERDA";
                System.Diagnostics.Debug.WriteLine("YOU SENT::: "+charToSend);
                ExecuteWrite(charToSend);
            }
        }
    }
}
