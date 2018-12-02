using Phoneword.Behaviors;
using Phoneword.Styles;
using Phoneword.Views.Interfaces;
using Xamarin.Forms;

namespace Phoneword.Views
{
    public class LoginView : ContentPage, ILoginView
    {
        public LoginView()
        {
            
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            CreateLayout();
        }

        private void CreateLayout()
        {

            Label subTitle = new Label();            
            subTitle.TextColor = Color.White;
            subTitle.SetBinding(Label.TextProperty, "PassWord", BindingMode.TwoWay);
            subTitle.FontAttributes = FontAttributes.Bold;

            Label login = new Label();
            login.Text = "Login";
            login.TextColor = Color.White;
            login.FontAttributes = FontAttributes.Bold;

            Entry loginInput = new Entry();
            loginInput.Style = StylesEntry.EntryDefault;
            //loginInput.SetBinding(Entry.BehaviorsProperty, "BehaviorsEntry", BindingMode.TwoWay);
            loginInput.SetBinding(Entry.TextProperty, "Login", BindingMode.TwoWay);

            Label passWord = new Label();
            passWord.TextColor = Color.White;
            passWord.Text = "Pass Word";


            Entry passWordInput = new Entry();
            passWordInput.Style = StylesEntry.EntryDefault;
            passWordInput.SetBinding(Entry.TextProperty, "PassWord", BindingMode.TwoWay);


            var enterBehavior = new EnterBehavior();
            enterBehavior.BindingContext = this.BindingContext;
            enterBehavior.SetBinding(EnterBehavior.EnterCommandProperty , "OnReturnPassWord", BindingMode.TwoWay);
            passWordInput.Behaviors.Add(enterBehavior);


            Button btnEnter = new Button
            {
                Text = "Enter",
                Style = StylesButton.ButtonDefault
            };

            StackLayout statckView = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Padding = 3,
                Children = { subTitle,  login, loginInput, passWord, passWordInput, btnEnter }
            };

            Content = statckView;
        }
        
    }
}
