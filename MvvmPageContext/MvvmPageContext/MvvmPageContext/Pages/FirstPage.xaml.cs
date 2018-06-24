using MvvmPageContext.Pages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmPageContext.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FirstPage : ContentPage, IFirstPage
	{
		public FirstPage ()
		{
			InitializeComponent ();
		}
	}
}