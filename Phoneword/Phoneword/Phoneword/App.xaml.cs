using Phoneword.Localization;
using Phoneword.Views;
using Phoneword.Views.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Phoneword
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            #region Select Language
            //FOR�A TROCA DE LINGUAGEM
            //LanguageResource.Culture = new System.Globalization.CultureInfo("pt-BR");
            #endregion

            AutofacConfig.ConfigureContainer();

            MainPage firstPage = AutofacConfig.GetPage<IMainPage, MainPage>();

            var navigationPage = new NavigationPage(firstPage);
            navigationPage.BarBackgroundColor = Color.FromHex("#c2c2d6");
            navigationPage.FlowDirection = FlowDirection.MatchParent;
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