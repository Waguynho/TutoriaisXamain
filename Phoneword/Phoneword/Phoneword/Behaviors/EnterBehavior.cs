using System;
using Xamarin.Forms;

namespace Phoneword.Behaviors
{
    public class EnterBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.Completed += RerurnPressed;
            entry.Unfocused += OnUnfocused;
            base.OnAttachedTo(entry);
        }

        private void OnUnfocused(object sender, FocusEventArgs e)
        {
            ((Entry)sender).TextColor = Color.Default;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.Unfocused -= OnUnfocused;
            entry.Completed -= RerurnPressed;
            base.OnDetachingFrom(entry);
        }

        private void RerurnPressed(object sender, EventArgs e)
        {
            ((Entry)sender).TextColor = Color.Red;
        }
    }
}
