using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Phoneword.Views.Interfaces
{
    public interface IPageContext
    {
        // <summary>
        // Obtém a IPage atual.
        // </summary>
        IPage CurrentPage { get; }

        /// <summary>
        /// Navega para uma TPage conectada a uma TViewModel.
        /// Modelo de navegação baseado na NavigationStack.
        /// </summary>
        /// <typeparam name="TPage">Nova página</typeparam>
        /// <typeparam name="TViewModel">Viewmodel</typeparam>
        /// <returns></returns>
        Task NavigateTo<TPage, TViewModel>()
           where TPage : class, IPage
           where TViewModel : class;

        /// <summary>
        /// Navega para uma TPage conectada a uma TViewModel, fazendo uma injeção do valor para uma propriedade
        /// desta viewmodel.
        /// Modelo de navegação baseado na NavigationStack.
        /// </summary>
        /// <typeparam name="TPage">Nova página</typeparam>
        /// <typeparam name="TViewModel">Viewmodel</typeparam>
        /// <param name="property">Proprieda</param>
        /// <param name="value">Valor</param>
        /// <returns></returns>
        Task NavigateTo<TPage, TViewModel>(Expression<Func<object>> property, object value)
            where TPage : class, IPage
            where TViewModel : class;

        /// <summary>
        /// Navega para uma TPage conectada a uma TViewModel.
        /// Modelo de navegação baseado na ModalStack.
        /// </summary>
        /// <typeparam name="TPage">Nova página</typeparam>
        /// <typeparam name="TViewModel">Viewmodel</typeparam>
        /// <returns></returns>
        Task ModalNavigateTo<TPage, TViewModel>()
           where TPage : class, IPage
           where TViewModel : class;

        /// <summary>
        /// Exibe uma lista de ações que permitindo ao usuário sua escolha ( Apresentação de forma nativa ).
        /// </summary>
        /// <param name="title">Título</param>
        /// <param name="cancel">Texto apresentado na opção de cancelar</param>
        /// <param name="destruction"></param>
        /// <param name="buttons">Opções</param>
        /// <returns></returns>
        Task<string> ShowConfirmationMessage(string title, string cancel, string destruction, params string[] buttons);

        /// <summary>
        /// Apresenta uma caixa de diálogo com um única opção de cancelar.
        /// </summary>
        /// <param name="title">Título</param>
        /// <param name="message">Mensagem</param>
        /// <param name="cancel">Texto exibido no botão de cancelar.</param>
        /// <returns></returns>
        Task ShowMessage(string title, string message, string cancel);

        /// <summary>
        /// Apresenta uma caixa de diálogo com um única opção de cancelar.
        /// </summary>
        /// <param name="title">Título</param>
        /// <param name="message">Mensagem</param>
        /// <param name="accept">Texto exibido no botão de confirmação</param>
        /// <param name="cancel">Texto exibido no botão de cancelar.</param>
        /// <returns></returns>
        Task<bool> ShowMessage(string title, string message, string accept, string cancel);

    }
}
