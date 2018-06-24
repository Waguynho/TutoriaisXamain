using MvvmPageContext.Pages.Interfaces;
using MvvmPageContext.ViewModels.Base;
using MvvmPageContext.ViewModels.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmPageContext.ViewModels
{
    public class ThirdViewModel : ViewModelBase, IThirdViewModel
    {
        #region Fields

        private Command _showCustomMessageCommand;

        #endregion

        #region Constructor

        public ThirdViewModel(IPageContext context)
            : base(context)
        { }

        #endregion

        #region IThirdViewModel members

        /// <summary>
        /// Commando responsável por exibir mensagem.
        /// </summary>
        public ICommand ShowCustomMessageCommand
        {
            get
            {
                return _showCustomMessageCommand ??
                      (_showCustomMessageCommand = new Command(() =>
                     {
                         Context.ShowMessage("Mensagem", "PageContext com mensagem.", "Ok");
                         Context.NavigateTo<IFirstPage, IFirstViewModel>();
                     }));
            }
        }

        #endregion
    }

}
