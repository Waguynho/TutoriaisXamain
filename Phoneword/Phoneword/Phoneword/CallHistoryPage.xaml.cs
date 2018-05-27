using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Phoneword
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CallHistoryPage : ContentPage
	{
        public IList<string> PhoneNumbers { get; set; }
        public CallHistoryPage (IList<string> numbers)
        {
            this.PhoneNumbers = numbers;
            InitializeComponent ();
		}
	}
}