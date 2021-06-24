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
            "Adds a new problem or modifies an existing one",
            @"Arguments:
<name (string)> - name of the problem
<tests file location> - where on the computer the tests are
<time limit (decimal)> - time limit of the problem
[memory limit (int)] - memory limit of the problem
// default memory limit is 256 MB")

        { }

        public override void Run(string[] args)
        {
            if (args.Length > 4) { Console.WriteLine("Too many arguments!"); return; }
            if (args.Length < 3) { Console.WriteLine("Too few arguments!"); return; }

            decimal tl;
            if (!decimal.TryParse(args[2], out tl)) { Console.WriteLine("Time limit not valid!"); return; }

            int ml = 256;
            if (args.Length == 4)
                if (!int.TryParse(args[3], out ml)) { Console.WriteLine("Memory limit not valid!"); return; }
            
            // file even exists bro?
            // just use try catch and cout some errors
        }
    }
}