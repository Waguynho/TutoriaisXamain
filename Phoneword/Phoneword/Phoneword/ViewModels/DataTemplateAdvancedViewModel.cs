using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System.Collections.ObjectModel;

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
         

        public DataTemplateAdvancedViewModel(IPageContext context)
            : base(context)
        {
        }

        public override void BeforeBinding()
        {
            LoadList();
        }

        private void LoadList()
        {
            this.ToDoItems = new ObservableCollection<TodoItem>
          {
                new TodoItem { Name = "Comprar pêras", Done = false },
                new TodoItem { Name = "Comprar Laranjas", Done= true} ,
                new TodoItem { Name = "Lavar o carro"  , Done = false },
                new TodoItem { Name = "Retiar a mesa da garagem", Done= true },
                new TodoItem { Name = "Arrumar a cama", Done= true }
            };

            for (int i = 0; i < 20; i++)
            {
                this.ToDoItems.Add( new TodoItem { Name = "Comprar " + i, Done = true });
            }
        }
    }
}
