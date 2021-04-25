using Phoneword.Behaviors;
using Phoneword.Controls;
using Phoneword.Styles;
using Phoneword.Views.Interfaces;
using System.Collections.Generic;
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

            WEntry loginInput = new WEntry();
            loginInput.Style = StylesEntry.EntryDefault;
            loginInput.InvertedFlow = true;
            loginInput.SetBinding(Entry.TextProperty, "Login", BindingMode.TwoWay);

            Label passWord = new Label();
            passWord.TextColor = Color.White;
            passWord.Text = "Pass Word";


            Entry passWordInput = new Entry();
            passWordInput.Style = StylesEntry.EntryDefault;
            passWordInput.SetBinding(Entry.TextProperty, "PassWord", BindingMode.TwoWay);

            SetBehaviorsForPassWord(passWordInput);

            passWordInput.SetBinding(Entry.TextColorProperty, "ColorFont");

            Button btnEnter = new Button
            {
                Text = "Enter",
                Style = StylesButton.ButtonDefault
            };

            btnEnter.SetBinding(Button.CommandProperty, "OnReturnToken");

            #region FireBaseDb

            BoxView line = new BoxView();
            line.Color = Color.Silver;
            line.HeightRequest = 9;
            line.Margin = 5;
            line.VerticalOptions = LayoutOptions.Fill;
            line.HorizontalOptions = LayoutOptions.FillAndExpand;

            Label nameLabel = new Label();
            nameLabel.Text = "Nome";
            nameLabel.TextColor = Color.White;
            nameLabel.FontAttributes = FontAttributes.Bold;

            WEntry nameInput = new WEntry();
            nameInput.Style = StylesEntry.EntryDefault;
            nameInput.SetBinding(Entry.TextProperty, "Name", BindingMode.OneWayToSource);
            nameInput.SetBinding(Entry.IsFocusedProperty, "IsFocused", BindingMode.OneWayToSource);

            Label descriptionLabel = new Label();
            descriptionLabel.Text = "Descrição";
            descriptionLabel.TextColor = Color.White;
            descriptionLabel.FontAttributes = FontAttributes.Bold;
            descriptionLabel.SetBinding(Entry.TextProperty, "Description", BindingMode.OneWayToSource);



            WEntry descriptionInput = new WEntry();
            descriptionInput.Style = StylesEntry.EntryDefault;
            descriptionInput.Keyboard = Keyboard.Text;
            descriptionInput.SetBinding(Entry.TextProperty, "Description", BindingMode.TwoWay);

            Label ratingLabel = new Label();
            ratingLabel.Text = "Nota";
            ratingLabel.TextColor = Color.White;
            ratingLabel.FontAttributes = FontAttributes.Bold;

            WEntry ratingInput = new WEntry();
            ratingInput.Style = StylesEntry.EntryDefault;
            ratingInput.Keyboard = Keyboard.Numeric;
            ratingInput.SetBinding(Entry.TextProperty, "Rating", BindingMode.TwoWay);

            Label moodLabel = new Label();
            moodLabel.Text = "Humor";
            moodLabel.TextColor = Color.White;
            moodLabel.FontAttributes = FontAttributes.Bold;

            WEntry moodInput = new WEntry();
            moodInput.Style = StylesEntry.EntryDefault;
            moodInput.Keyboard = Keyboard.Numeric;
            moodInput.SetBinding(Entry.TextProperty, "Mood", BindingMode.TwoWay);

            Button btnUpSert = new Button
            {
                Text = "Upsert",
                Style = StylesButton.ButtonDefault
            };

            btnUpSert.SetBinding(Button.CommandProperty, "OnReturnTinder");


            #endregion

            StackLayout statckView = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Padding = 3,
                Children = { subTitle, login, loginInput, passWord, passWordInput, btnEnter, line, nameLabel, nameInput, descriptionLabel, descriptionInput, ratingLabel , ratingInput, moodLabel, moodInput, btnUpSert }
            };

            ScrollView scrollView = new ScrollView();
            scrollView.Content = statckView;

            Content = scrollView;
        }

        private void SetBehaviorsForPassWord(Entry passWordInput)
        {
            EnterBehavior enterBehaviorColor = new EnterBehavior();
            enterBehaviorColor.BindingContext = this.BindingContext;
            enterBehaviorColor.SetBinding(EnterBehavior.EnterCommandProperty, "OnReturnColor", BindingMode.OneWay);

            EnterBehavior enterBehaviorToken = new EnterBehavior();
            enterBehaviorToken.BindingContext = this.BindingContext;
            enterBehaviorToken.SetBinding(EnterBehavior.EnterCommandProperty, "OnReturnToken", BindingMode.OneWay);

            passWordInput.Behaviors.Add(enterBehaviorColor);
            passWordInput.Behaviors.Add(enterBehaviorToken);
        }

        private ICollection<Behavior> GetBehaviors()
        {
            return null;
        }

    }
}
