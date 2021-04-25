using Phoneword.Models;
using Phoneword.Utils;
using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class LoginViewModel : ViewModelBase, ILoginViewModel
    {
        private ICommand onReturnColor;

        public ICommand OnReturnColor
        {
            get { return onReturnColor; }
            set
            {
                SetProperty(ref onReturnColor, value);
            }
        }

        private bool isFocused;

        public bool IsFocused
        {
            get { return isFocused; }
            set
            {
                if (isFocused != value)
                {
                    isFocused = value;
                }

            }
        }


        private ICommand onReturnToken;

        public ICommand OnReturnToken
        {
            get { return onReturnToken; }
            set
            {
                SetProperty(ref onReturnToken, value);
            }
        }

        private ICommand onReturnTinder;

        public ICommand OnReturnTinder
        {
            get { return onReturnTinder; }
            set
            {
                SetProperty(ref onReturnTinder, value);
            }
        }

        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                SetProperty(ref login, value);
            }
        }

        private string rating = "0";
        public string Rating
        {
            get { return rating; }
            set
            {
                SetProperty(ref rating, value);
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                SetProperty(ref description, value);
            }
        }

        private string mood = "0";
        public string Mood
        {
            get { return mood; }
            set
            {
                SetProperty(ref mood, value);
            }
        }

        private string passWord;
        public string PassWord
        {
            get { return passWord; }
            set
            {
                SetProperty(ref passWord, value);
            }
        }
        private Color colorFont = Color.Pink;
        public Color ColorFont
        {
            get { return colorFont; }
            set
            {
                SetProperty(ref colorFont, value);
            }
        }
        public LoginViewModel(IPageContext context) : base(context)
        {

        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            if (propertyName == nameof(Rating))
            {
                OnRatingChanged();
            }
            else if (propertyName == nameof(Mood))
            {
                OnMoodChanged();
            }
            base.OnPropertyChanged(propertyName);
        }

        private void OnMoodChanged()
        {
            Mood = KeepLimits(Mood);
        }

        private void OnRatingChanged()
        {
            try
            {
                Rating = KeepLimits(Rating);
            }
            catch (System.Exception)
            {

                Rating = "0";
            }
        }

        private string KeepLimits(string value)
        {
            int number = int.Parse(value);

            if (number < 0 || number > 10)
            {
                value = "0";
            }
            return value;
        }

        public override void BeforeBinding()
        {
            base.BeforeBinding();
        }
        public override void AfterBinding()
        {
            base.AfterBinding();
            setBehaviorsEntry();
        }
        private bool IsLoginSuccess()
        {
            return PassWord.Equals("123") && Login.ToLower().Equals("ws");
        }
        private void setBehaviorsEntry()
        {
            OnReturnColor = new Command(ChangeColor);
            OnReturnToken = new Command(ShowToken);
            OnReturnTinder = new Command(TinderUpdate);
        }



        private void ChangeColor()
        {
            if (IsLoginSuccess())

            {
                ColorFont = Color.Green;
            }
            else
            {
                ColorFont = Color.Red;
            }
        }

        private async void TinderUpdate()
        {
            try
            {
                HttpRest httpRest = new HttpRest();

                TinderWoman tinder = new TinderWoman();
                tinder.description = Description;
                tinder.ratting = int.Parse(Rating);
                tinder.mood = int.Parse(Mood);

                string request = Statics.BaseUriPhoneWord + "tinder/" + Name + ".json";
                string body = Newtonsoft.Json.JsonConvert.SerializeObject(tinder);
                int x;
                string result = await httpRest.PutRequest(request, body);

                if (result == "OK")
                {
                    await PageContext.ShowMessage("Aviso", "Salvo com sucesso", "cancelar");
                }
                else
                {
                    await PageContext.ShowMessage("Erro", result, "cancelar");
                }
            }
            catch (System.Exception ex)
            {

                await PageContext.ShowMessage("ERRO", ex.Message + " " + ex.InnerException, "cancelar");
            }

        }

        private async void ShowToken()
        {
            try
            {
                HttpRest httpRest = new HttpRest();

                var result = await httpRest.AuthenticateCarsApi(Login, PassWord);

                await PageContext.ShowMessage("Aviso", result, "cancelar");
            }
            catch (System.Exception ex)
            {

                await PageContext.ShowMessage("ERRO", ex.Message + " " + ex.InnerException, "cancelar");
            }

        }
    }
}

