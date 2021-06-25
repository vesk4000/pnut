using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class Assign : Command
    {
        public Assign() :
            base("assign",
            "Assigns an existing problem to a contestant",
            @"Arguments:
<problem_name (string)> - problem to assign to the contestant
<contestant_name (string)> - name of the contestant
<solution_file_path (path)> - path to the solution file")

        { }

        public override void Run(string[] args)
        {
            if (args.Length != 3) ConsoleExt.WriteError("Assign command requires 3 arguments!");
            // if( problem doesn't exist ) ConsoleExt.WriteError("Problem {0} does not exist!", problem name );
            // if( contestant doesn't exist ) ConsoleExt.WriteError("Contestant {0} does not exist!", contestant name );
            // if( solution file path doesn't exist ) ConsoleExt.WriteError("Invalid file path!");

            // assigns
        }
    }
}