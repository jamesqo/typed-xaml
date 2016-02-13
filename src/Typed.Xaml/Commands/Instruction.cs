using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Typed.Xaml.Commands
{
    public class Instruction : Command
    {
        private readonly Action execute;

        public Instruction(Action execute)
        {
            this.execute = execute;
        }

        public override void Execute() => execute();
    }
}
