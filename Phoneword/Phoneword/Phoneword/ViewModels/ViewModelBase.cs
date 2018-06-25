using Phoneword.ViewModels.Interfaces;
using Phoneword.Views.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Phoneword.ViewModels
{
    public class ViewModelBase:   INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IPageContext PageContext { get; set; }

        public ViewModelBase(IPageContext PageContext)
        {
            this.PageContext = PageContext;
        }

        protected bool SetProperty<T>(ref T storage, T value,  [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected  void OnPropertyChanged( string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
