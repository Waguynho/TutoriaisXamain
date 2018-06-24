using MvvmPageContext.Pages.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmPageContext.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ThirdPage : ContentPage, IThirdPage
    {
		public ThirdPage ()
		{
			InitializeComponent ();
		}
	}
}