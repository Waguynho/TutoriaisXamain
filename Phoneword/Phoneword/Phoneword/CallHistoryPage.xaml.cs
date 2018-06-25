using Phoneword.Views.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Phoneword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CallHistoryPage : ContentPage, ICallHistoryView
    {
        public CallHistoryPage ()
        {
            InitializeComponent();
		}
	}
}