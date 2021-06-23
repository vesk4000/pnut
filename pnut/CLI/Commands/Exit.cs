using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class Exit : Command
    {
        public Exit() :
            base(new string[] { "exit", "close", "quit" },
            "Closes pnut",
            "")
        { }

        public override void Run(string[] args)
        {
            Environment.Exit(0);
        }
    }
}
