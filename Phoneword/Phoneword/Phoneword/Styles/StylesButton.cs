using Phoneword.Utils;
using Xamarin.Forms;
namespace Phoneword.Styles
{
    public class StylesButton
    {
        public static Style ButtonDefault {
            get
            {
                return GetStyleDefault();
            }
        }

        private static Style GetStyleDefault()
        {
            Style buttonStyle = new Style(typeof(Button));

            buttonStyle.Setters.Add(View.BackgroundColorProperty, Statics.ButtonColor);
            buttonStyle.Setters.Add(Button.CornerRadiusProperty, 25);
            buttonStyle.Setters.Add(Button.VerticalOptionsProperty, LayoutOptions.Center);
            buttonStyle.Setters.Add(Button.HorizontalOptionsProperty, LayoutOptions.FillAndExpand);

            return buttonStyle;
        }
    }
}
