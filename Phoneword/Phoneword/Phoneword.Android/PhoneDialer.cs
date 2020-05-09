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
            Context ctx = MainActivity.Instance.ApplicationContext;
            Toast.MakeText(ctx, number + " ADD TO HISTORY!", ToastLength.Long).Show();
            return true;
        }
    }
}
   
