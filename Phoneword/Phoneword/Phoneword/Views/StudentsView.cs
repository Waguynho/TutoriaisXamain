using Phoneword.Styles;
using Phoneword.Views.Interfaces;
using Xamarin.Forms;

namespace Phoneword.Views
{
    public class StudentsView : ContentPage, IStudentsView
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            CreateLayout();
        }

        private void CreateLayout()
        {
            Title = "Students";


            Button btnAddStudents = new Button
            {
                Text = "Add Students",
                Style = StylesButton.ButtonDefault
            };

            btnAddStudents.SetBinding(Button.CommandProperty, "CreateStudentesCommand");

            ListView studentsRegistred = new ListView();
            studentsRegistred.SetBinding(ListView.ItemsSourceProperty, "Students", BindingMode.OneWay);

            StackLayout statckView = new StackLayout
            {
                BackgroundColor = Color.Blue,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Padding = 3,
                Children = {  btnAddStudents, studentsRegistred }
            };

            Content = statckView;
        }
    }
}
