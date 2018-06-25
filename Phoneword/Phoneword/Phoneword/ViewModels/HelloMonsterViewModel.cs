using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;

namespace Phoneword.ViewModels
{
    public class HelloMonsterViewModel : ViewModelBase, IHelloMonsterViewModel
    {
        public HelloMonsterViewModel(IPageContext context)
            : base(context)
        {

        }
    }
}
