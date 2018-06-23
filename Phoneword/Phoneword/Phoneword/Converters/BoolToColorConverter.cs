using System;
using System.Globalization;
using Xamarin.Forms;

namespace Phoneword.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(bool))
            {
                string array = parameter as string; 

                return (bool)value == true ? Color.GreenYellow : Color.Red;
            }

            return Color.Blue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(bool))
            {
              return  (bool)value == true ? Color.Red : Color.Blue;
            }

            return Color.Red;
        }
    }
}
