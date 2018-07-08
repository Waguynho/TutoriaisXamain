using Phoneword.Styles;
using Phoneword.Views.Interfaces;
using Xamarin.Forms;

namespace Phoneword.Views
{
    public class FileView : ContentPage, IFileView
    {
        public FileView()
        {
            CreateLayout();
        }
        private void CreateLayout()
        {
            Title = "Access Files";

            Label cacheLabel = new Label();
            cacheLabel.Text = "App Cache";
            cacheLabel.TextColor = Color.White;
            cacheLabel.FontAttributes = FontAttributes.Bold;

            Label cacheLabelValue = new Label();
            cacheLabelValue.TextColor = Color.White;
            cacheLabelValue.SetBinding(Label.TextProperty, "AppCachePath", BindingMode.OneWay);

            Label pathLabel = new Label();
            pathLabel.Text = "App Path";
            pathLabel.TextColor = Color.White;
            pathLabel.FontAttributes = FontAttributes.Bold;

            Label pathLabelValue = new Label();
            pathLabelValue.TextColor = Color.White;
            pathLabelValue.SetBinding(Label.TextProperty, "AppPath", BindingMode.OneWay);

            Entry input = new Entry();
            input.Style = StylesEntry.EntryDefault;
            input.SetBinding(Entry.TextProperty, "TextInput", BindingMode.TwoWay);

            Button btnWriteFile = new Button
            {
                Text = "Write in File",
                Style = StylesButton.ButtonDefault
            };
            btnWriteFile.SetBinding(Button.CommandProperty, "WriteFileCommand");

            Button btnReadFile = new Button
            {
                Text = "Read File",
                Style = StylesButton.ButtonDefault
            };
            btnReadFile.SetBinding(Button.CommandProperty, "ReadFileCommand");


            StackLayout stackButtons = new StackLayout
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Orientation = StackOrientation.Horizontal,
                Padding = 3,
                Children = { btnWriteFile, btnReadFile}
            };

            btnReadFile.SetBinding(Button.CommandProperty, "ReadFileCommand");

            Label contentLabel = new Label();
            contentLabel.Text = "Content File";
            contentLabel.TextColor = Color.White;
            contentLabel.FontAttributes = FontAttributes.Bold;

            Label contentLabelValue = new Label();
            contentLabelValue.TextColor = Color.White;
            contentLabelValue.FontAttributes = FontAttributes.Italic;
            contentLabelValue.SetBinding(Label.TextProperty, "FileContent", BindingMode.OneWay);
            

            StackLayout statckView = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Padding = 3,
                Children = { cacheLabel, cacheLabelValue, pathLabel, pathLabelValue, input, stackButtons, contentLabel,  contentLabelValue }
            };

            Content = statckView;
        }
    }
}
