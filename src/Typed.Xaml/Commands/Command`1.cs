using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Typed.Xaml
{
    public abstract class Command<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(T parameter);

        public abstract void Execute(T parameter);

        public bool CanExecute(object parameter) =>
            parameter is T && CanExecute((T)parameter);

        public void Execute(object parameter) =>
            Execute((T)parameter);

        protected void OnCanExecuteChanged(EventArgs args = null) =>
            CanExecuteChanged?.Invoke(this, args ?? EventArgs.Empty);
    }
}
