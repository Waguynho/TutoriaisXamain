using Phoneword.Controls;
using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class StudentsViewModel : ViewModelBase, IStudentsViewModel
    {
        private ProgressView progressView;
        private byte maxStudents = 20;

        private ICommand createStudentesCommand;

        public ICommand CreateStudentesCommand
        {
            get { return createStudentesCommand; }
            set
            {
                SetProperty(ref createStudentesCommand, value);
            }
        }

        private IList<string> students;

        public IList<string> Students
        {
            get { return students; }
            set
            {
                SetProperty(ref students, value);
            }
        }

        public StudentsViewModel(IPageContext context) : base(context)
        {

        }

        public override void BeforeBinding()
        {
            base.BeforeBinding();
        }
        public override void AfterBinding()
        {
            base.AfterBinding();
            SetCommands();
        }
 
        private void SetCommands()
        {
            CreateStudentesCommand = new Command(CreateStudents);
        }

        public async void CreateStudents()
        {
            try
            {
                progressView = new ProgressView("Students Created", maxStudents, AddStudents);

                await ((Page)PageContext.CurrentPage).Navigation.PushModalAsync(progressView, true);
            }
            catch (Exception ex)
            {
                await PageContext.CurrentPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private async void AddStudents()
        {
            List<string> newStudents = new List<string>(maxStudents);

            for (int i = 0; i < newStudents.Capacity; i++)
            {
                newStudents.Add("Student_" + i);
                await progressView.ReportProgress(newStudents.Count);
            }

            Students = newStudents;
        }
    }
}

