using Phoneword.Droid;
using Phoneword.Utils;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrlAsset))]
namespace Phoneword.Droid
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
