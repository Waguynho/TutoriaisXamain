using System.Collections.Generic;

namespace Phoneword.ViewModels.Interfaces
{
    public interface ICallHistoryViewModel
    {
        IList<string> Numbers { get; set; }
    }
}
