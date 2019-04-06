using Phoneword.Styles;
using Phoneword.Views.Interfaces;
using Xamarin.Forms;

namespace Phoneword.Views
{
    public class ThousandRowsView : ContentPage, IThousandRowsView
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            CreateLayout();
            Title = "Repetidor";
        }

        private void CreateLayout()
        {
            Label adviceLabel = new Label();
            adviceLabel.TextColor = Color.White;
            adviceLabel.Text = "Quantidade (Repetições)";
            adviceLabel.FontAttributes = FontAttributes.Bold;

            Slider sliderQuantity = new Slider();
            sliderQuantity.Maximum = 5000;
            sliderQuantity.SetBinding(Slider.ValueProperty, "LimitRepetition", BindingMode.OneWayToSource);


            Label repetitionLabel = new Label();
            repetitionLabel.TextColor = Color.White;
            repetitionLabel.SetBinding(Label.TextProperty, "LimitRepetition", BindingMode.OneWay);


            Entry textInput = new Entry();
            textInput.BackgroundColor = Color.White;
            textInput.TextColor = Color.Black;
            textInput.Placeholder = "Digite aqui...";
            textInput.SetBinding(Entry.TextProperty, "CopyText", BindingMode.TwoWay);


            Button repeatButton = new Button();
            repeatButton.Text = "Repetir";
            repeatButton.Style = StylesButton.ButtonDefault;
            repeatButton.SetBinding(Button.CommandProperty, "RepeatCommand");

            Editor copyEditor = new Editor();
            copyEditor.BackgroundColor = Color.White;
            copyEditor.TextColor = Color.Black;
            copyEditor.VerticalOptions = LayoutOptions.FillAndExpand;
            copyEditor.AutoSize = EditorAutoSizeOption.TextChanges;
            copyEditor.SetBinding(Editor.TextProperty, "RepeatText", BindingMode.OneWay);

            StackLayout statckView = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Padding = 8,
                Children = { adviceLabel, sliderQuantity, repetitionLabel, textInput, repeatButton, copyEditor }
            };

            Content = statckView;
        }

    }
}
