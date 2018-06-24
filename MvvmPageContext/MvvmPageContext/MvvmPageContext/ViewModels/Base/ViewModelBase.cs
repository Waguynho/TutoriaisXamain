using MvvmPageContext.Pages.Interfaces;
using MvvmPageContext.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace MvvmPageContext.ViewModels.Base
{
    public abstract class ViewModelBase : IViewModel
    {
        #region Properties

        /// <summary>
        /// Contexto de navegação e mensagens pop-up.
        /// </summary>
        public IPageContext Context { get; private set; }

        #endregion

        #region Constructor

        public ViewModelBase(IPageContext context)
        {
            Context = context;
        }

        #endregion

        #region INotifyPropertyChanged members

        /// <summary>
        // Ocorre quando há mudanças em propriedades.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifica às modificações.
        /// </summary>
        /// <typeparam name="T">Tipo da Propriedade.</typeparam>
        /// <param name="expression">Propriedade</param>
        protected void RaisedPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null) return;

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null) return;

            RaisedPropertyChanged(propertyInfo.Name);
        }

        /// <summary>
        /// Notifica às modificações.
        /// </summary>
        /// <param name="propertyName">Nome da Propriedade</param>
        protected void RaisedPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
