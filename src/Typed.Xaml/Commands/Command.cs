using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Typed.Xaml
{
    public class Command : ICommand
    {
        private readonly Action execute;

        public event EventHandler CanExecuteChanged;

        public Command(Action execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => execute();
    }

    public class Command<T> : ICommand
    {
        private readonly Action<T> execute;

        public event EventHandler CanExecuteChanged;

        public Command(Action<T> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter) =>
            parameter is T;

        public void Execute(object parameter) =>
            execute((T)parameter);
    }
}
