using System;
using System.Globalization;
using Xamarin.Forms;

namespace Phoneword.Converters
{
    public class BoolColorConverter : IValueConverter
    {
        private Color positiveCase;
        private Color negativeCase;

        public BoolColorConverter(Color positiveCase, Color negativeCase)
        {
            this.positiveCase = positiveCase;
            this.negativeCase = negativeCase;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(bool))
            {
                return (bool)value == true ? this.positiveCase : this.negativeCase;
            }

            return Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(bool))
            {
                return (bool)value == true ? this.negativeCase : this.positiveCase;
            }

            return Color.Red;
        }
    }
}
