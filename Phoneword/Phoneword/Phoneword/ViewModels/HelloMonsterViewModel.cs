using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class HelloMonsterViewModel : ViewModelBase, IHelloMonsterViewModel
    {
        public HelloMonsterViewModel(IPageContext context): base(context)
        {

        }

        public ICommand DataTemplateCommand { private set; get; }
        public ICommand FileAccessCommand { private set; get; }

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

        public override void BeforeBinding()
        {
            DataTemplateCommand = new Command(ExecuteDataTemplate);
            FileAccessCommand = new Command(ExecuteFileAccess);
        }
    }
}
