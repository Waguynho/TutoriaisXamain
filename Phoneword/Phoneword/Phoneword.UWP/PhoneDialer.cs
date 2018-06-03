using Phoneword.UWP;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls;
using Windows.UI.Popups;
using Xamarin.Forms;


[assembly: Dependency(typeof(PhoneDialer))]
namespace Phoneword.UWP
{
    public class PhoneDialer : IDialer
    {
        bool dialled = false;

        public bool Dial(string number)
        {
            DialNumber(number);

            return dialled;
        }

        async Task DialNumber(string number)
        {
            var dialog = new MessageDialog(number + " Adicionado ao Histórico!", "Aviso");

            await dialog.ShowAsync();

            dialled = true;
        }
    }
}
