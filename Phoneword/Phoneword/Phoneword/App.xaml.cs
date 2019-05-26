using Phoneword.Controls;
using Phoneword.Localization;
using Phoneword.ViewModels.Interfaces;
using Phoneword.Views;
using Phoneword.Views.Interfaces;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Phoneword
{
    public partial class App : Application
    {
        private string msgErro;

        public App()
        {
            InitializeComponent();

            #region Select Language
            //FORÇA TROCA DE LINGUAGEM
            //LanguageResource.Culture = new System.Globalization.CultureInfo("pt-BR");
            #endregion

            InitializeMainPage();
        }

        private void InitializeMainPage()
        {

            AutofacConfig.ConfigureContainer();
            MainPage firstPage = AutofacConfig.GetPage<IMainPage, MainPage>();

            WNavigationPage navigationPage = new WNavigationPage((Page)firstPage);
            navigationPage.BarBackgroundColor = Color.FromHex("#c2c2d6");
            navigationPage.BarTextColor = Color.White;

            MainPage = navigationPage;
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}