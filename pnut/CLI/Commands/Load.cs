using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class Load : Command
    {
        public Load() :
            base("load",
            "Loads a saved state of pnut",
            @"Arguments:
<file_name (string)> - file name to load")

        { }

        public override void Run(string[] args)
        {

        }
    }
}