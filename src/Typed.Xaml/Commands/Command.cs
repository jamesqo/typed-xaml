using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Typed.Xaml.Commands
{
    public abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute => true;

        public abstract void Execute();

        bool ICommand.CanExecute(object parameter) => CanExecute;

        void ICommand.Execute(object parameter) => Execute();

        protected void OnCanExecuteChanged(EventArgs args = null) =>
            CanExecuteChanged?.Invoke(this, args ?? EventArgs.Empty);
    }
}
