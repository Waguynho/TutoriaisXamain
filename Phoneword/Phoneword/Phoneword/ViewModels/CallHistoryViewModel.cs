using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System.Collections.Generic;

namespace Phoneword.ViewModels
{
    public class CallHistoryViewModel : ViewModelBase, ICallHistoryViewModel
    {

        private IList<string> numbers = null;

        public IList<string> Numbers
    {
            get { return numbers; }
            set
            {
                SetProperty(ref numbers, value);
            }
        }

        public CallHistoryViewModel(IPageContext context) : base(context)
        {

        }
    }
}
