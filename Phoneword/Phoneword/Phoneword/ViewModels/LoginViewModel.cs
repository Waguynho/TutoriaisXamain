using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class LoginViewModel : ViewModelBase, ILoginViewModel
    {
        private ICommand onReturnPassWord;

        public ICommand OnReturnPassWord
        {
            get { return onReturnPassWord; }
            set
            {

                SetProperty(ref onReturnPassWord, value);

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
        private void setBehaviorsEntry()
        {
            OnReturnPassWord = new Command(LoginAction);
        }

        private void LoginAction()
        {
            if (PassWord.Equals("123") && Login.ToLower().Equals("ws"))

            {
                PageContext.ShowMessage("Aviso", "Logado com sucesso", "cancelar");
            }
            else
            {
                PageContext.ShowMessage("Erro", "Credenciais incorretas", "cancelar");

            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName); 

            switch (propertyName)
            {
                case nameof(OnReturnPassWord):

                    //OnReturnPassWord.Execute(null);
                    break;
            }
        }
    }
}
