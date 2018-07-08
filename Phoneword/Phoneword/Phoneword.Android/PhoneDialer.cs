using Android.Content;
using Android.Widget;
using Phoneword.Droid;
using Xamarin.Forms;

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