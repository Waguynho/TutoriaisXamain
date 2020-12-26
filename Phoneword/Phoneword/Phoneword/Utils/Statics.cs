using Xamarin.Forms;

namespace Phoneword.Utils
{
    public class Statics
    {
        public static Color ButtonColor
        {
            get { return Color.Orange; }
        }

        public static Color PageBackGroudColor
        {
            get { return Color.FromHex("#00001a"); }
        }

        public static Color EntryBackGroudColor
        {
            get { return Color.White; }
        }

        public static Color EntryTextColor
        {
            get { return Color.Black; }
        }

        public static string BaseUriCars
        {
            get { return "http://node1.wscompany.com.br/api"; }
        }

        public static string BaseUriPhoneWord
        {
            get { return "https://phoneword-acf12.firebaseio.com/"; }
        }
    }
}
