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
            @"Adds a new problem or modifies an existing one
Problems can then be assigned to contestants so their solutions can be judged
Note: Problems created are not saved after you exit the program",
            @"Arguments:
<name (string)> - name of the problem
<tests_file_folder (path)> - path to the inputs and expected outputs for the problem
[time limit (decimal)] - time limit in seconds for the problem
If no time limit is specified the problem will not have a time limit
[memory limit (int)] - memory limit in MB for the problem
If no memory limit is specified the problem will not have a memory limit
[input_file_extension (string)] - file extension of all input files in the previously specified folder
[output_file_extension (string)] - file extension of all output files in the previously specified folder")

        { }

        public override void Run(string[] args)
        {
            if (args.Length > 6) {
                ConsoleExt.WriteError("Too many arguments!");
                return;
            }
            if (args.Length < 2) {
                ConsoleExt.WriteError("Too few arguments!");
                return;
            }

            decimal tl = 0;
            if (args.Length >= 3)
                if (!decimal.TryParse(args[2], out tl)) {
                    ConsoleExt.WriteError("Time limit not valid number!");
                    return;
                }

            int ml = 0;
            if (args.Length >= 4)
                if (!int.TryParse(args[3], out ml)) {
                    ConsoleExt.WriteError("Memory limit not valid!");
                    return;
                }

            string inputExt = "";
            if (args.Length >= 5)
                inputExt = args[4];

            string outputExt = "";
            if (args.Length == 6)
                outputExt = args[5];

            // file even exists bro?
            // just use try catch and cout some errors
        }
    }
}