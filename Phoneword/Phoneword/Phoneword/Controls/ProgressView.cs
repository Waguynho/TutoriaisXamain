using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Phoneword.Controls
{
    public class ProgressView : ContentPage
    {
        private ProgressBar progressBar = new ProgressBar();
        private StackLayout stackMain = new StackLayout();
        private Label labelMenssage = new Label();
        private string successMenssage;
        private float totalToProcess;

        private Action rrocessOriginAction { get; set; }

        public ProgressView(string successMenssage, float totalToProcess, Action processOriginAction)
        {
            this.successMenssage = successMenssage;
            this.totalToProcess = totalToProcess;
            this.rrocessOriginAction = processOriginAction;

            ConfigureProgressBar();
            ConfigureLabelMenssage();
            ConfigureStackMain();
        }

        public async Task<bool> ReportProgress(double currentlyValue)
        {
            double decimalPercentage = currentlyValue / totalToProcess;
            SetMenssagePercentage(decimalPercentage);
            return await progressBar.ProgressTo(decimalPercentage, 150, Easing.Linear);
        }

        private void SetMenssagePercentage(double decimalPercentage)
        {
            double realPercentage = decimalPercentage * 100;

            if (realPercentage == 100 && !string.IsNullOrEmpty(successMenssage))
            {
                labelMenssage.Text = successMenssage;
            }
            else
            {
                labelMenssage.Text = realPercentage.ToString();
            }
        }

        private void ConfigureLabelMenssage()
        {
            if (!string.IsNullOrEmpty(successMenssage))
            {
                labelMenssage.Text = successMenssage;
                labelMenssage.HorizontalOptions = LayoutOptions.Center;
                labelMenssage.TextColor = Color.Default;
            }
        }

        private void ConfigureProgressBar()
        {
            progressBar.ProgressColor = Color.GreenYellow;
            progressBar.BackgroundColor = Color.Gray;
            progressBar.Margin = new Thickness(5, 5);
        }

        private void ConfigureStackMain()
        {
            stackMain.BackgroundColor = Color.Transparent;
            stackMain.VerticalOptions = LayoutOptions.Center;
            stackMain.Spacing = 3;
            stackMain.Padding = new Thickness(5, 5);

            stackMain.Children.Add(progressBar);
            stackMain.Children.Add(labelMenssage);

            Content = stackMain;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadProgressBar();
        }

        private void LoadProgressBar()
        {
            if (rrocessOriginAction != null)
            {
                rrocessOriginAction.Invoke();
            }
        }

        protected override bool OnBackButtonPressed()
        {
            if (progressBar.Progress == 1)
            {
                return base.OnBackButtonPressed();
            }

            return true;
        }
    }
}
