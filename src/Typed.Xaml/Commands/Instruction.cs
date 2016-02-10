using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Typed.Xaml.Commands
{
    public class Instruction : ICommand
    {
        private readonly Action execute;

        public event EventHandler CanExecuteChanged;

        public Instruction(Action execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => execute();
    }

    public class Instruction<T> : Command<T>
    {
        private readonly Action<T> execute;

        public Instruction(Action<T> execute)
        {
            this.execute = execute;
        }

        public sealed override bool CanExecute(T parameter) => true;

        public sealed override void Execute(T parameter) => 
            execute(parameter);
    }
}
