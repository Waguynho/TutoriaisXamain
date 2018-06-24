using MvvmPageContext.Pages;
using MvvmPageContext.Pages.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MvvmPageContext
{
    public partial class App : Application
	{
		public App ()
		{
            AutofacConfig.ConfigureContainer();

			InitializeComponent();

            var firstPage = AutofacConfig.GetPage<IFirstPage, FirstPage>();

            MainPage = new NavigationPage(firstPage);
		}

		protected override void OnStart ()
		{
            
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
