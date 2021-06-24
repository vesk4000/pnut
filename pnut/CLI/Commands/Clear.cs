using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class Clear : Command
    {
        public Clear() :
            base("clear",
            "Clears the console",
            "")

        { }

        public override void Run(string[] args)
        {
            Console.Clear();
        }
    }
}