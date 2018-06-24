using System.Windows.Input;

namespace MvvmPageContext.ViewModels.Interfaces
{
    public interface IFirstViewModel
    {
        /// <summary>
        /// Commando responsável por navegar para a segunda página.
        /// </summary>
        ICommand GoToSecondPageCommand { get; }
    }
}
