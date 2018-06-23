using Phoneword.Localization;
using Phoneword.Views;
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
            //FORÇA TROCA DE LINGUAGEM
            //LanguageResource.Culture = new System.Globalization.CultureInfo("pt-BR");
            #endregion

            MainPage = new NavigationPage(new MainPage());
           // MainPage = new NavigationPage(new DataTemplateAdvancedView());
        }

        protected override void OnStart()
        {
            
            // Handle when your app starts
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