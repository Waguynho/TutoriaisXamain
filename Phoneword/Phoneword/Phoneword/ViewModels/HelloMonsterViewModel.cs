using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class HelloMonsterViewModel : ViewModelBase, IHelloMonsterViewModel
    {
        public HelloMonsterViewModel(IPageContext context) : base(context)
        {

        }

        public ICommand DataTemplateCommand { private set; get; }
        public ICommand FileAccessCommand { private set; get; }
        public ICommand WebInterfaceCommand { private set; get; }
        public ICommand LoginCommand { private set; get; }
        public ICommand BarCodeCommand { private set; get; }
        public ICommand StudentsCommand { private set; get; }
        public ICommand BleCommand { private set; get; }

        public void ExecuteDataTemplate()
        {
            try
            {
                PageContext.NavigateTo<IDataTemplateAdvancedView, IDataTemplateAdvancedViewModel>();
            }
            catch (Exception ex)
            {
                PageContext.CurrentPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public void ExecuteFileAccess()
        {
            try
            {
                PageContext.NavigateTo<IFileView, IFileViewModel>();
            }
            catch (Exception ex)
            {
                PageContext.CurrentPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public void ExecuteWebInterface()
        {
            try
            {
                PageContext.NavigateTo<IWebInterfaceView, IWebInterfaceViewModel>();
            }
            catch (Exception ex)
            {
                PageContext.CurrentPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public async void ExecuteBarCode()
        {
            try
            {
                await PageContext.NavigateTo<IBarCodeReaderView, IBarCodeReaderViewModel>();
            }
            catch (Exception ex)
            {
               await PageContext.CurrentPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public async void CreateStudents()
        {
            try
            {
                await PageContext.NavigateTo<IStudentsView, IStudentsViewModel>();
            }
            catch (Exception ex)
            {
                await PageContext.CurrentPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public async void ExecuteBle()
        {
            try
            {
                await PageContext.NavigateTo<IBleView, IBleViewModel>();
            }
            catch (Exception ex)
            {
                await PageContext.CurrentPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
        
        public void Teste(string result)
        {
            Device.BeginInvokeOnMainThread(() => {
                PageContext.CurrentPage.DisplayAlert("Leitura...", result, "OK");
            });
         
        }

        public void ExecuteLogin()
        {
            try
            {
                PageContext.NavigateTo<ILoginView, ILoginViewModel>();
            }
            catch (Exception ex)
            {
                PageContext.CurrentPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public override void BeforeBinding()
        {
            DataTemplateCommand = new Command(ExecuteDataTemplate);
            FileAccessCommand = new Command(ExecuteFileAccess); 
            WebInterfaceCommand = new Command(ExecuteWebInterface);
            LoginCommand = new Command(ExecuteLogin);
            BarCodeCommand = new Command(ExecuteBarCode);
            StudentsCommand = new Command(CreateStudents);
            BleCommand = new Command(ExecuteBle);
        }
    }
}
