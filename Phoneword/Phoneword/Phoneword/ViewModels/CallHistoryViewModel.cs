using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;

namespace Phoneword.ViewModels
{
    public class CallHistoryViewModel: ViewModelBase, ICallHistoryViewModel
    {
        public CallHistoryViewModel(IPageContext context) : base(context)
        {

        }
    }
}
