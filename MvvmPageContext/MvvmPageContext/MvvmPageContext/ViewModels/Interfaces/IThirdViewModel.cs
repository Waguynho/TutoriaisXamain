using System.Windows.Input;

namespace MvvmPageContext.ViewModels.Interfaces
{
    public interface IThirdViewModel
    {
        /// <summary>
        /// Commando responsável por exibir mensagem.
        /// </summary>
        ICommand ShowCustomMessageCommand { get; }
    }
}
