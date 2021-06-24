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
            "Assigns a problem to a contestant",
            @"Arguments:
<contestant_name> - name of the contestant
<solution_file_path> - file path to the solution to assign")

        { }

        public override void Run(string[] args)
        {
            
        }
    }
}