using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MvvmPageContext.ViewModels.Interfaces
{
    public interface ISecondViewModel
    {
        /// <summary>
        /// Commando responsável por navegar para a terceira página.
        /// </summary>
        ICommand GoToThirdPageCommand { get; }
    }
}
