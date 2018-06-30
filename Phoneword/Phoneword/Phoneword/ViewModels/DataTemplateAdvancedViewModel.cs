using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;

namespace Phoneword.ViewModels
{
    public class DataTemplateAdvancedViewModel : ViewModelBase, IDataTemplateAdvancedViewModel
    {
        private TodoItem[] toDoItems;

        public TodoItem[] ToDoItems
        {
            get { return toDoItems; }
            set { SetProperty(ref toDoItems, value); }
        }


        public DataTemplateAdvancedViewModel(IPageContext context)
            : base(context)
        {
            LoadList();
        }

        private void LoadList()
        {
          this.ToDoItems =  new TodoItem[] {
                new TodoItem { Name = "Comprar pêras", Done = false },
                new TodoItem { Name = "Comprar Laranjas", Done= true} ,
                new TodoItem { Name = "Lavar o carro"  , Done = false },
                new TodoItem { Name = "Retiar a mesa da garagem", Done= true },
                new TodoItem { Name = "Arrumar a cama", Done= true }
            };
        }
    }
}
