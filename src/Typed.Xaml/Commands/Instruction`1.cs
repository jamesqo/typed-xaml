using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Typed.Xaml.Commands
{
    public class Instruction<T> : Command<T>
    {
        private readonly Action<T> execute;

        public Instruction(Action<T> execute)
        {
            this.execute = execute;
        }

        public override void Execute(T parameter) =>
            execute(parameter);
    }
}
