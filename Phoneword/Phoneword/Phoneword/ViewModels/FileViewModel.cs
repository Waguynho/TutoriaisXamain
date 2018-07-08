using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.IO;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Phoneword.ViewModels
{
    public class FileViewModel : ViewModelBase, IFileViewModel
    {
        public FileViewModel(IPageContext context) : base(context)
        {

        }

        public ICommand WriteFileCommand { private set; get; }
        public ICommand ReadFileCommand { private set; get; }

        private string fileName = "Texto.txt";

        private string appPath = "";

        public string AppPath
        {
            get { return appPath; }
            set
            {
                SetProperty(ref appPath, value);
            }
        }
        private string appCachePath = "";

        public string AppCachePath
        {
            get { return appCachePath; }
            set
            {
                SetProperty(ref appCachePath, value);
            }
        }

        private string fileContent;

        public string FileContent
        {
            get { return fileContent; }
            set
            {
                SetProperty(ref fileContent, value);
            }
        }
        private string textInput;

        public string TextInput
        {
            get { return textInput; }
            set
            {
                SetProperty(ref textInput, value);
            }
        }

        private string GetAppPath()
        {
            return FileSystem.AppDataDirectory;
        }
        private string GetAppPathCache()
        {
            return FileSystem.CacheDirectory;
        }

        private void FillContentFile()
        {
            try
            {
                string fileContents = string.Empty;

                using (var stream = File.OpenRead(fileName))
                {
                    using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
                    {
                        FileContent = reader.ReadToEndAsync().Result;
                    }
                }
            }
            catch (Exception e)
            {
                FileContent = e.Message;
            }
        }

        public override void BeforeBinding()
        {
            try
            {
                WriteFileCommand = new Command(ExecuteWrite);
                ReadFileCommand = new Command(FillContentFile);
                AppPath = GetAppPath();
                AppCachePath = GetAppPathCache();
                fileName = string.Concat(AppPath, Path.DirectorySeparatorChar, fileName);
            }
            catch (System.Exception e)
            {
                FileContent = e.Message;
            }
        }

        private void ExecuteWrite()
        {
            string fileContents = string.Empty;

            File.WriteAllText(fileName, TextInput);

            PageContext.CurrentPage.DisplayAlert("AVISO!", "Escreveu" + Environment.NewLine + TextInput, "CLOSE");
        }
    }
}
