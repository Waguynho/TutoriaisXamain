using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Phoneword.Utils
{
    public class GroupT<Key, TElement> : ObservableCollection<TElement>
    {
        public Key KeyGroup { get; set; }

        public GroupT(Key keyParam, IEnumerable<TElement> elements)
        {
            this.KeyGroup = keyParam;

            foreach (var item in elements)
            {
                this.Items.Add(item);
            }
        }
    }
}
