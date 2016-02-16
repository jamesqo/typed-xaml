using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Typed.Xaml
{
    public abstract class Command<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(T parameter) => true;

        public abstract void Execute(T parameter);

        bool ICommand.CanExecute(object parameter) =>
            parameter is T && CanExecute((T)parameter);

        void ICommand.Execute(object parameter) =>
            Execute((T)parameter);

        protected void OnCanExecuteChanged(EventArgs args = null) =>
            CanExecuteChanged?.Invoke(this, args ?? EventArgs.Empty);
    }
}
