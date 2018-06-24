using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MvvmPageContext.Pages.Interfaces
{
    public interface IPage
    {
        /// <summary>
        /// Objeto que contêm propriedades que estarão no contexto do Binding.
        /// </summary>
        object BindingContext { get; set; }

        /// <summary>
        /// Exibe uma lista de ações que permitindo ao usuário sua escolha ( Apresentação de forma nativa ).
        /// </summary>
        /// <param name="title">Título</param>
        /// <param name="cancel">Texto apresentado na opção de cancelar</param>
        /// <param name="destruction"></param>
        /// <param name="buttons">Opções</param>
        /// <returns></returns>
        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);

        /// <summary>
        /// Apresenta uma caixa de diálogo com um única opção de cancelar.
        /// </summary>
        /// <param name="title">Título</param>
        /// <param name="message">Mensagem</param>
        /// <param name="cancel">Texto exibido no botão de cancelar.</param>
        /// <returns></returns>
        Task DisplayAlert(string title, string message, string cancel);

        /// <summary>
        /// Apresenta uma caixa de diálogo com um única opção de cancelar.
        /// </summary>
        /// <param name="title">Título</param>
        /// <param name="message">Mensagem</param>
        /// <param name="accept">Texto exibido no botão de confirmação</param>
        /// <param name="cancel">Texto exibido no botão de cancelar.</param>
        /// <returns></returns>
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);

    }
}
