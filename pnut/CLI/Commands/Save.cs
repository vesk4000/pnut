using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class Save : Command
    {
        public Save() :
            base("save",
            "Saves the current state of pnut",
            @"Arguments:
<file_name (string)> - file name to save")

        { }

        public override void Run(string[] args)
        {

        }
    }
}