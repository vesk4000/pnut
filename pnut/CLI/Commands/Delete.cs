using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class Delete : Command
    {
        public Delete() :
            base("delete",
            "Deletes an existing problem or contestant",
            @"Arguments:
<name (string)> - name of the problem/contestant")

        { }

        public override void Run(string[] args)
        {
            HashSet<string> wrongNames = new HashSet<string>();


            /*for (int i = 0; i < args.Length; i++)
            {
                // if ( args[i] is not a contestant / problem) wrongNames.Add(args[i]);
                // else if ( args[i] is contestant ) delete contestant
                // else delete problem
            }*/

            foreach (string wrongName in wrongNames)
            {
                ConsoleExt.WriteWarning(wrongName + " is not an existing problem / contestant name");
            }

        }
    }
}