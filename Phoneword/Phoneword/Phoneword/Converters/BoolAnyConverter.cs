using System;
using System.Globalization;
using Xamarin.Forms;

namespace Phoneword.Converters
{
    public class BoolAnyConverter<KTypeReturn> : IValueConverter
    {
        private readonly KTypeReturn positiveCase;
        private readonly KTypeReturn negativeCase;

        public BoolAnyConverter(KTypeReturn positiveCase, KTypeReturn negativeCase)
        {
            this.positiveCase = positiveCase;
            this.negativeCase = negativeCase;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(bool))
            {
                if ((bool)value)
                {
                    return positiveCase;
                }

                return negativeCase;
            }

            return positiveCase;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(bool))
            {
                if ((bool)value)
                {
                    return negativeCase;
                }

                return positiveCase;
            }

            return negativeCase;
        }
    }
}
