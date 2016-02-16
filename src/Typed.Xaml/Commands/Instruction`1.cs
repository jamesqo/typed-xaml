using System;
using System.Collections.Generic;

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
