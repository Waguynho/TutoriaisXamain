using Android.Content.Res;
using Android.Util;
using Phoneword.Android.DependencyService;
using Phoneword.Droid;
using Phoneword.Utils;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(AssetHandler))]
namespace Phoneword.Android.DependencyService
{
    public class AssetHandler : IAssetHandler
    {
        public string ReadAssetContent(string assetName)
        {
            try
            {
                AssetManager assets = MainActivity.Instance.Assets;
                using (StreamReader sr = new StreamReader(assets.Open(assetName)))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Java.IO.FileNotFoundException fe)
            {
                Log.Error("WS-ERROR", fe.Message);
                return "FILE NOT EXIST! " + fe.Message;
            }
            catch (Java.Lang.Exception je)
            {
                Log.Error("WS-ERROR", je.Message);
                return "FILE NOT EXIST! " + je.Message;
            }
            catch (System.Exception e)
            {
                Log.Error("WS-ERROR", e.Message);
                return "FILE NOT EXIST! " + e.Message;
            }
        }
    }
}