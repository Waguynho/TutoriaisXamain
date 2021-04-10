using Autofac;
using Phoneword.ViewModels;
using Phoneword.ViewModels.Interfaces;
using Phoneword.Views;
using Phoneword.Views.Interfaces;

namespace Phoneword
{
    public class AutofacConfig
    {
        #region Fields

        private static IContainer _container;

        public static IContainer Buider { get { return _container; } }

        #endregion

        #region Properties

        /// <summary>
        /// Recupera uma page do contâiner. Você pode usar na Classe App.cs por exemplo
        /// </summary>
        public static TPage GetPage<TService, TPage>()
            where TService : IPage
            where TPage : class
        {
            if (_container == null || !_container.IsRegistered<TService>())
                return default(TPage);

            var pageContext = _container.Resolve<IPageContext>();
            return (TPage)pageContext.CurrentPage;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Responsável por registras em dependências ( Autofac ).
        /// </summary>
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //PageContext for Main Page, wich will propagate
            builder.Register((c, p) => new PageContext(c.Resolve<IComponentContext>(), c.Resolve<IMainPage>()))
                .As<IPageContext>()
                .SingleInstance();

            #region Views

            builder.RegisterType<HelloMonsterView>().As<IHelloMonsterView>();
            builder.RegisterType<MainPage>().As<IMainPage>();
            builder.RegisterType<CallHistoryPage>().As<ICallHistoryView>();
            builder.RegisterType<DataTemplateAdvancedView>().As<IDataTemplateAdvancedView>();
            builder.RegisterType<WebInterfaceView>().As<IWebInterfaceView>();
            builder.RegisterType<FileView>().As<IFileView>();
            builder.RegisterType<LoginView>().As<ILoginView>();
            builder.RegisterType<ThousandRowsView>().As<IThousandRowsView>();
            builder.RegisterType<BarCodeReaderView>().As<IBarCodeReaderView>();
            builder.RegisterType<StudentsView>().As<IStudentsView>();
            builder.RegisterType<BleView>().As<IBleView>();

            #endregion

            #region Viewmodels

            builder.RegisterType<HelloMonsterViewModel>().As<IHelloMonsterViewModel>();
            builder.RegisterType<MainPageViewModel>().As<IMainPageViewModel>();
            builder.RegisterType<CallHistoryViewModel>().As<ICallHistoryViewModel>();
            builder.RegisterType<DataTemplateAdvancedViewModel>().As<IDataTemplateAdvancedViewModel>();
            builder.RegisterType<FileViewModel>().As<IFileViewModel>();
            builder.RegisterType<WebInterfaceViewModel>().As<IWebInterfaceViewModel>();
            builder.RegisterType<LoginViewModel>().As<ILoginViewModel>();
            builder.RegisterType<ThousandRowsViewModel>().As<IThousandRowsViewModel>();
            builder.RegisterType<BarCodeReaderViewModel>().As<IBarCodeReaderViewModel>();
            builder.RegisterType<StudentsViewModel>().As<IStudentsViewModel>();
            builder.RegisterType<BleViewModel>().As<IBleViewModel>();

            #endregion


            //Main Page Register
            builder.Register(c => new MainPage()).As<IMainPage>()
            .OnActivated(e => e.Instance.BindingContext = _container.Resolve<IMainPageViewModel>());

            #region Page Context Register 


            #endregion



            _container = builder.Build();
        }

        public static TService  RESOLVER<TService>()
        {
            return _container.Resolve<TService>();
    }

        #endregion
    }
}
