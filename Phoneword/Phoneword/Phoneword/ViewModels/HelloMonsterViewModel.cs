using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class HelloMonsterViewModel : ViewModelBase, IHelloMonsterViewModel
    {
        public HelloMonsterViewModel(IPageContext context)
            : base(context)
        {
            DataTemplateCommand = new Command(ExecuteDataTemplate);
        }

        public ICommand DataTemplateCommand { private set; get; }

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
    }
}
