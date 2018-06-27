using System.Collections.Generic;

namespace Phoneword.ViewModels.Interfaces
{
    public interface ICallHistoryViewModel: IViewModel
    {
        IList<string> Numbers { get; set; }
    }
}
