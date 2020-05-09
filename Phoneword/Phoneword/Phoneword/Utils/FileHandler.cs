using Phoneword.Utils;
using System;
using System.Collections;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHandler))]
namespace Phoneword.Utils
{
    public class FileHandler: IAssetHandler
    {
        public string ReadAssetContent(string assetName)
        {
            FindFoldersPath();

            string fileName = Path.Combine(Environment.CurrentDirectory, assetName);

            if (File.Exists(fileName))
            {
                return File.ReadAllText(fileName);
            }
            return "FILE DO NOT EXISTS!";
        }

        private void FindFoldersPath()
        {
            string CurrentDirectory = Environment.CurrentDirectory;
            string SystemDirectory = Environment.SystemDirectory;
            string UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string Templates = Environment.GetFolderPath(Environment.SpecialFolder.Templates);
            string System = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string LocalApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string Startup = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string Resources = Environment.GetFolderPath(Environment.SpecialFolder.Resources);
            string Personal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string CommonProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
            string CommonDocuments = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            string CommonApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            IDictionary variables = Environment.GetEnvironmentVariables();
        }
    }
}
