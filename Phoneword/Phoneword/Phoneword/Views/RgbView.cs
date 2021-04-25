using Phoneword.Styles;
using Phoneword.Views.Interfaces;
using Xamarin.Forms;

namespace Phoneword.Views
{
    public class RgbView : ContentPage, IRgbView
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            CreateLayout();
        }

        private void CreateLayout()
        {
            Title = "WS - RGB";

            Slider redSlider = new Slider();
            redSlider.SetBinding(Slider.DragCompletedCommandProperty, "DragedCommand", BindingMode.OneWay);
            redSlider.SetBinding(Slider.ValueProperty, "RedValue", BindingMode.OneWayToSource);
            redSlider.BackgroundColor = Color.Red;
            redSlider.MaximumTrackColor = Color.White;
            redSlider.MinimumTrackColor = Color.Red;
            redSlider.ThumbColor = Color.Red;
            redSlider.Maximum = 255;
            redSlider.Minimum = 0;

            Label redLabel = new Label();
            redLabel.SetBinding(Label.TextProperty, "RedLabel", BindingMode.OneWay);

            Slider blueSlider = new Slider();
            blueSlider.SetBinding(Slider.DragCompletedCommandProperty, "DragedCommand", BindingMode.OneWay);
            blueSlider.SetBinding(Slider.ValueProperty, "BlueValue", BindingMode.OneWayToSource);
            blueSlider.BackgroundColor = Color.Blue;
            blueSlider.MaximumTrackColor = Color.White;
            blueSlider.MinimumTrackColor = Color.Blue;
            blueSlider.ThumbColor = Color.Blue;
            blueSlider.Maximum = 255;
            blueSlider.Minimum = 0;

            Label blueLabel = new Label();
            blueLabel.SetBinding(Label.TextProperty, "BlueLabel", BindingMode.OneWay);

            Slider greenSlider = new Slider();
            greenSlider.SetBinding(Slider.DragCompletedCommandProperty, "DragedCommand", BindingMode.OneWay);
            greenSlider.SetBinding(Slider.ValueProperty, "GreenValue", BindingMode.OneWayToSource);
            greenSlider.BackgroundColor = Color.Green;
            greenSlider.MaximumTrackColor = Color.White;
            greenSlider.MinimumTrackColor = Color.Green;
            greenSlider.ThumbColor = Color.Green;
            greenSlider.Maximum = 255;
            greenSlider.Minimum = 0;

            Label greenLabel = new Label();
            greenLabel.SetBinding(Label.TextProperty, "GreenLabel", BindingMode.OneWay);

            Frame frame = new Frame();
            frame.SetBinding(Frame.BackgroundColorProperty, "FrameColor", BindingMode.OneWay);
            frame.BorderColor = Color.Black;

            StackLayout stackLayout = new StackLayout();
            stackLayout.Padding = new Thickness(15);
            stackLayout.Children.Add(redSlider);
            stackLayout.Children.Add(redLabel);
            stackLayout.Children.Add(blueSlider);
            stackLayout.Children.Add(blueLabel);
            stackLayout.Children.Add(greenSlider);
            stackLayout.Children.Add(greenLabel);
            stackLayout.Children.Add(frame);

            ScrollView scroll = new ScrollView();
            scroll.Content = stackLayout;
          
            Content = scroll;
        }
    }
}
