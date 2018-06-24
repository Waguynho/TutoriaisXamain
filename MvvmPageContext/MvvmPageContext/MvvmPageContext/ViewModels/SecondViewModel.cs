using MvvmPageContext.Pages.Interfaces;
using MvvmPageContext.ViewModels.Base;
using MvvmPageContext.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmPageContext.ViewModels
{
    public class SecondViewModel : ViewModelBase, ISecondViewModel
    {
        #region Fields

        private Command _goToThirdPageCommand;

        #endregion

        #region Constructor

        public SecondViewModel(IPageContext context)
            : base(context)
        { }

        #endregion

        #region ISecondViewModel members

        /// <summary>
        /// Commando responsável por navegar para a terceira página.
        /// </summary>
        public ICommand GoToThirdPageCommand
        {
            get
            {
                return _goToThirdPageCommand ??
                      (_goToThirdPageCommand = new Command(async () =>
                        await Context.NavigateTo<IThirdPage, IThirdViewModel>()));
            }
        }

        #endregion
    }
}
