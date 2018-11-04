using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phoneword.Behaviors
{
    public class EnterBehavior : Behavior<Entry>
    {


        private ICommand EnterCommand
        {
            get => (ICommand)GetValue(EnterCommandProperty);
            set => SetValue(EnterCommandProperty, value);
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.Completed += RerurnPressed;
            entry.Unfocused += OnUnfocused;
            entry.ChildAdded += RerurnPressed;
            entry.Focused += Onfocused;
            base.OnAttachedTo(entry);
        }

        private void OnUnfocused(object sender, FocusEventArgs e)
        {
            ((Entry)sender).TextColor = Color.Orange;
        }

        private void Onfocused(object sender, FocusEventArgs e)
        {
            ((Entry)sender).TextColor = Color.Purple;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.Completed -= RerurnPressed;
            entry.Unfocused -= OnUnfocused;
            entry.ChildAdded -= RerurnPressed;
            entry.Focused -= Onfocused;
            base.OnDetachingFrom(entry);
        }

        private void RerurnPressed(object sender, EventArgs e)
        {

            if (EnterCommand == null)
            {
                ((Entry)sender).TextColor = Color.Blue;
            }
            else
            {
                EnterCommand.Execute(null);
            }
        }
        static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var x = bindable;
        }
        #region Bindable Properties
        public static readonly BindableProperty EnterCommandProperty = BindableProperty.Create(
           propertyName: nameof(EnterCommand),
           returnType: typeof(ICommand),
           declaringType: typeof(EnterBehavior),
           defaultValue: null,
           defaultBindingMode: BindingMode.TwoWay,
           propertyChanged: OnEnterChanged
           );


        private static void OnEnterChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }

        #endregion
    }
}
