using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class Export : Command
    {
        public Export() :
            base("export",
            "Exports the results of the judge",
            @"Arguments:
<file_name (string)> - file name to save")

        { }

        public override void Run(string[] args)
        {

        }
    }
}