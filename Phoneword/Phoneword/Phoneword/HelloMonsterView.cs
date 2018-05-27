using Xamarin.Forms;

namespace Phoneword
{
    public class HelloMonsterView : ContentPage
    {
        public HelloMonsterView()
        {
            StackLayout stack = new StackLayout();
            this.Content = stack;

            Label texto = new Label();
            texto.Text = "Olá Monstro!";
            texto.TextColor = Color.Blue;
            texto.FontSize = 17;
            texto.VerticalOptions = LayoutOptions.CenterAndExpand;
            texto.HorizontalOptions = LayoutOptions.CenterAndExpand;

            stack.Children.Add(texto);                
        }
    }
}
