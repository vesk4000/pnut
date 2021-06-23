using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class Problem : Command
    {
        public Problem() :
            base("problem",
            "                        ",
            @"Arguments:
              <name (string)> - name of the problem")

        { }

        public override void Run(string[] args)
        {
            // check for # of args
            // check for validity of entered shits    tryparse or some shit
            // file even exists bro?
            // ml int?
            // just use try catch and cout some errors
        }
    }
}