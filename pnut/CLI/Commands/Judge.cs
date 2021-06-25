using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class Judge : Command
    {
        public Judge() :
            base("judge",
            "Judges a set of problems or contestants",
            @"Arguments:
pnut> judge <problem_name>
This judges all the solutions to a specific problem
pnut> judge <contestant_name>
This judges all of a specific contestant's solutions")

        { }

        public override void Run(string[] args)
        {

        }
    }
}