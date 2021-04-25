using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class RgbViewModel : ViewModelBase, IRgbViewModel
    {
        private ICommand dragedCommand;

        public ICommand DragedCommand
        {
            get { return dragedCommand; }
            set
            {
                SetProperty(ref dragedCommand, value);
            }
        }       

        private double redValue;

        public double RedValue
        {
            get { return redValue; }
            set
            {
                SetProperty(ref redValue, value);
            }
        }

        private double blueValue;

        public double BlueValue
        {
            get { return blueValue; }
            set
            {
                SetProperty(ref blueValue, value);
            }
        }

        private double greenValue;

        public double GreenValue
        {
            get { return greenValue; }
            set
            {
                SetProperty(ref greenValue, value);
            }
        }

        string redLabel = "0";
        public string RedLabel
        {
            get { return redLabel; }
            set
            {
                SetProperty(ref redLabel, value);
            }
        }

        string blueLabel = "0";
        public string BlueLabel
        {
            get { return blueLabel; }
            set
            {
                SetProperty(ref blueLabel, value);
            }
        }

        string greenLabel = "0";
        public string GreenLabel
        {
            get { return greenLabel; }
            set
            {
                SetProperty(ref greenLabel, value);
            }
        }

        private Color frameColor;

        public Color FrameColor
        {
            get { return frameColor; }
            set
            {
                SetProperty(ref frameColor, value);
            }
        }

        public RgbViewModel(IPageContext context) : base(context)
        {

        }

        public override void BeforeBinding()
        {
            base.BeforeBinding();
        }
        public override void AfterBinding()
        {
            base.AfterBinding();
            SetCommands();
        }


        private void SetCommands()
        {
            DragedCommand = new Command(SendToArduino);
        }

        public async void SendToArduino()
        {
            try
            {
                FrameColor = Color.FromRgb(RedValue, GreenValue, BlueValue);
                //await ((Page)PageContext.CurrentPage).DisplayAlert("", "Released!", "OK");
            }
            catch (Exception ex)
            {
                await PageContext.CurrentPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

       

      

 

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(RedValue))
            {
                RedLabel = RedValue.ToString();
            }

            if (propertyName == nameof(BlueValue))
            {
                BlueLabel = BlueValue.ToString();
            }

            if (propertyName == nameof(GreenValue))
            {
                GreenLabel = GreenValue.ToString();
            }
        }
    }
}

