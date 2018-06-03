using Android.App;
using Android.Content;
using Android.Telephony;
using Phoneword.Droid;
using System.Linq;
using Android.Content;
using Xamarin.Forms;
using Android.Widget;

[assembly: Dependency(typeof(PhoneDialer))]
namespace Phoneword.Droid
{
    public class PhoneDialer : Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IDialer
    {

        public bool Dial(string number)
        {
            Context ctx = Android.App.Application.Context;
          
            Toast.MakeText(ctx, number + " Adicionado ao Histórico!", ToastLength.Long).Show();
            return true;
        }

    }
}