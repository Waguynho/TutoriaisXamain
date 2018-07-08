using Phoneword.Utils;
using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;


namespace Phoneword.ViewModels
{
    public class DataTemplateAdvancedViewModel : ViewModelBase, IDataTemplateAdvancedViewModel
    {
        private ObservableCollection<TodoItem> toDoItems;

        public ObservableCollection<TodoItem> ToDoItems
        {
            get { return toDoItems; }
            set { SetProperty(ref toDoItems, value); }
        }

        private ObservableCollection<GroupT<bool, TodoItem>> groups;

        public ObservableCollection<GroupT<bool, TodoItem>> Groups
        {
            get { return groups; }
            set { SetProperty(ref groups, value); }
        }

        private TodoItem selectedItem;

        public TodoItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                SetProperty(ref selectedItem, value);
            }
        }

        private string headerList = "Nada selecionado...";

        public string HeaderList
        {
            get { return headerList; }
            set
            {
                SetProperty(ref headerList, value);
            }
        }

        private Color backGroundCell = Color.PapayaWhip;

        public Color BackGroundCell
        {
            get { return backGroundCell; }
            set { SetProperty(ref backGroundCell, value); }
        }


        public DataTemplateAdvancedViewModel(IPageContext context)
            : base(context)
        {

        }

        private void ExecuteDetail(TodoItem todo)
        {
            PageContext.CurrentPage.DisplayAlert("", todo.Name, "Close");
        }

        public ICommand DetailCommand { get; set; }

        public override void BeforeBinding()
        {
            LoadList();
            DetailCommand = new Command<TodoItem>((item) => ExecuteDetail(item));
        }


        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(SelectedItem))
            {
                OnSelectedIemChanged();
            }
        }

        private void OnSelectedIemChanged()
        {
            if (SelectedItem != null)
            {
                HeaderList = SelectedItem.Name;
                BackGroundCell = Color.Pink;
            }
        }

        private void LoadList()
        {
            this.ToDoItems = new ObservableCollection<TodoItem>
          {
                new TodoItem { Name = "Comprar pêras", Done = false },
                new TodoItem { Name = "Comprar Laranjas", Done= true} ,
                new TodoItem { Name = "Lavar o carro"  , Done = false },
                new TodoItem { Name = "Retiar a mesa da garagem", Done= false },
                new TodoItem { Name = "Arrumar a cama", Done= true }
            };

            for (int i = 0; i < 20; i++)
            {
                this.ToDoItems.Add(new TodoItem { Name = "Comprar " + i, Done = (i % 2 == 0) });
            }

            var todosGrouped = ToDoItems.GroupBy(g => g.Done).Select(p => new GroupT<bool, TodoItem>(p.Key, p)).ToList();

            Groups = new ObservableCollection<GroupT<bool, TodoItem>>(todosGrouped);
        }
    }
}
