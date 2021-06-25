using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class List : Command
    {
        public List() :
            base("list",
            "List all problems or contestants",
            @"Arguments:
pnut> list contestants - This lists all contestants
pnut> list problems - This lists all problems")

        { }

        public override void Run(string[] args)
        {
            if (args.Length != 1) ConsoleExt.WriteError("List command requires an argument!");
            //if (args[0] == "contestants") lists all contestants
            //if (args[0] == "problems") lists all problems
        }
    }
}