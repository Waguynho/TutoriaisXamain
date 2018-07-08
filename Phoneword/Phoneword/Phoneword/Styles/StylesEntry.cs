using Phoneword.Utils;
using Xamarin.Forms;
namespace Phoneword.Styles
{
    public class StylesEntry
    {
        public static Style EntryDefault {
            get
            {
                return GetStyleDefault();
            }
        }

        private static Style GetStyleDefault()
        {
            Style buttonStyle = new Style(typeof(Entry));

            buttonStyle.Setters.Add(View.BackgroundColorProperty, Statics.EntryBackGroudColor);
            buttonStyle.Setters.Add(Entry.TextColorProperty, Statics.EntryTextColor);
            buttonStyle.Setters.Add(Entry.VerticalOptionsProperty, LayoutOptions.Center);
            buttonStyle.Setters.Add(Entry.HorizontalOptionsProperty, LayoutOptions.FillAndExpand);

            return buttonStyle;
        }
    }
}
