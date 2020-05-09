using Phoneword.Android.DependencyService;
using Phoneword.Droid;
using Phoneword.Utils;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrlAsset))]
namespace Phoneword.Android.DependencyService
{
    public class BaseUrlAsset : IBaseUrlAsset
    {
        public string GetAssetBase()
        {
            var assetManager = MainActivity.Instance.Assets;
            
            return "file:///android_asset/";
        }
    }
}
