using Phoneword.Utils;
using Phoneword.UWP.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrlAsset))]
namespace Phoneword.UWP.DependencyService
{
    public class BaseUrlAsset : IBaseUrlAsset
    {
        public string GetAssetBase()
        {
            return "ms-appx-web:///";
        }
    }
}
