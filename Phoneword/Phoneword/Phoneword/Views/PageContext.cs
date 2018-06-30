using Autofac;
using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Phoneword.Views
{
    public class PageContext : IPageContext
    {

        #region Fields

        private IComponentContext _componentContext;
        private IPage _page;

        #endregion

        #region Properties

        /// <summary>
        /// Obtém a IPage atual.
        /// </summary>
        public IPage CurrentPage
        {
            get
            {
                var xamarinPage = _page as Page;
                if (xamarinPage == null) return null;

                var stack = xamarinPage.Navigation.NavigationStack;

                return stack.Any() ? stack.Last() as IPage : _page;
            }
        }

        #endregion

        #region Constructor

        public PageContext(IComponentContext componentContext, IPage page)
        {
            _componentContext = componentContext;
            _page = page;
        }
        #endregion

        #region Methods

        #region Navigation

        /// <summary>
        /// Navega para uma TPage conectada a uma TViewModel.
        /// </summary>
        /// <typeparam name="TPage">Nova página</typeparam>
        /// <typeparam name="TViewModel">Viewmodel</typeparam>
        /// <returns></returns>
        public async Task NavigateTo<TPage, TViewModel>()
          where TPage : class, IPage
            where TViewModel : IViewModel
        {
            //Resolvendo dependências.
            var newPage = _componentContext.Resolve<TPage>();
            var viewmodel = _componentContext.Resolve<TViewModel>();

            if (newPage != null && viewmodel != null)
            {
                viewmodel.BeforeBinding();

                //Conectando a Nova View com a Viewmodel.
                newPage.BindingContext = viewmodel;

                //Empilhando a página atual.
                await ((Page)CurrentPage).Navigation.PushAsync(newPage as Page);
                //await ((Page)CurrentPage).Navigation.
            }
        }

        /// <summary>
        /// Navega para uma TPage conectada a uma TViewModel, fazendo uma injeção do valor para uma propriedade
        /// desta viewmodel.
        /// </summary>
        /// <typeparam name="TPage">Nova página</typeparam>
        /// <typeparam name="TViewModel">Viewmodel</typeparam>
        /// <param name="property">Proprieda</param>
        /// <param name="value">Valor</param>
        /// <returns></returns>
        public Task NavigateTo<TPage, TViewModel>(Action<TViewModel> actiionViewModel)
            where TPage : class, IPage
            where TViewModel : IViewModel
        {
            //Resolvendo dependências.
            var newPage = _componentContext.Resolve<TPage>();
            var viewModel = _componentContext.Resolve<TViewModel>();

            //Preenchendo a ViewModel
            actiionViewModel.Invoke((TViewModel)viewModel);

            if (newPage != null && viewModel != null)
            {
                viewModel.BeforeBinding();

                //Conectando a Nova View com a Viewmodel.
                newPage.BindingContext = viewModel;


                //SetPropertyValue<TViewModel>(property.Body, viewmodel, value);
                //Empilhando a página atual.
                return ((Page)CurrentPage).Navigation.PushAsync(newPage as Page);
            }
            return null;
        }

        /// <summary>
        /// Navega para uma TPage conectada a uma TViewModel.
        /// Modelo de navegação baseado na ModalStack.
        /// </summary>
        /// <typeparam name="TPage">Nova página</typeparam>
        /// <typeparam name="TViewModel">Viewmodel</typeparam>
        /// <returns></returns>
        public async Task ModalNavigateTo<TPage, TViewModel>()
            where TPage : class, IPage
            where TViewModel : class
        {
            //Resolvendo dependências.
            var newPage = _componentContext.Resolve<TPage>();
            var viewmodel = _componentContext.Resolve<TViewModel>();

            if (newPage != null && viewmodel != null)
            {
                //Conectando a Nova View com a Viewmodel.
                newPage.BindingContext = viewmodel;
                //Empilhando a página atual.
                await ((Page)CurrentPage).Navigation.PushModalAsync(newPage as Page);
            }
        }

        private void SetPropertyValue<T>(Expression property, object root, object value)
        {
            var member = property as MemberExpression;
            if (member == null) return;

            var propertyInfo = member.Member as PropertyInfo;
            if (propertyInfo == null) return;

            var propertySetter = root.GetType()
                                .GetTypeInfo()
                                .DeclaredProperties
                                .First(c => c.Name.Equals(propertyInfo.Name, StringComparison.OrdinalIgnoreCase));

            if (propertySetter != null)
                propertySetter.SetValue(root, value);
        }

        #endregion

        #region Messaging

        /// <summary>
        /// Exibe uma lista de ações que permitindo ao usuário sua escolha ( Apresentação de forma nativa ).
        /// </summary>
        /// <param name="title">Título</param>
        /// <param name="cancel">Texto apresentado na opção de cancelar</param>
        /// <param name="destruction"></param>
        /// <param name="buttons">Opções</param>
        /// <returns></returns>
        public async Task<string> ShowConfirmationMessage(string title, string cancel, string destruction, params string[] buttons)
        {
            var result = await CurrentPage.DisplayActionSheet(title, cancel, destruction, buttons);
            return result;
        }

        /// <summary>
        /// Apresenta uma caixa de diálogo com um única opção de cancelar.
        /// </summary>
        /// <param name="title">Título</param>
        /// <param name="message">Mensagem</param>
        /// <param name="cancel">Texto exibido no botão de cancelar.</param>
        /// <returns></returns>
        public async Task ShowMessage(string title, string message, string cancel)
        {
            await CurrentPage.DisplayAlert(title, message, cancel);
        }

        /// <summary>
        /// Apresenta uma caixa de diálogo com um única opção de cancelar.
        /// </summary>
        /// <param name="title">Título</param>
        /// <param name="message">Mensagem</param>
        /// <param name="accept">Texto exibido no botão de confirmação</param>
        /// <param name="cancel">Texto exibido no botão de cancelar.</param>
        /// <returns></returns>
        public async Task<bool> ShowMessage(string title, string message, string accept, string cancel)
        {
            var result = await CurrentPage.DisplayAlert(title, message, accept, cancel);
            return result;
        }

        #endregion

        #endregion
    }
}