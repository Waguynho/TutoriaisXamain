using Phoneword.Utils;
using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
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

        private ICommand onReturnToken;

        public ICommand OnReturnToken
        {
            get { return onReturnToken; }
            set
            {
                SetProperty(ref onReturnToken, value);
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

        private async void ShowToken()
        {
            try
            {
                HttpRest httpRest = new HttpRest();

                var result = await httpRest.MakePostRequest(Login, PassWord);

                await PageContext.ShowMessage("Aviso", result, "cancelar");
            }
            catch (System.Exception ex)
            {

                await PageContext.ShowMessage("ERRO", ex.Message + " " + ex.InnerException, "cancelar");
            }

        }
    }
}

