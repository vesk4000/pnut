using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class Contestant : Command
    {
        public Contestant() :
            base("contestant",
            "Adds a new contestant or modifies an existing one",
            @"Arguments:
<name (string)> - name of the contestant")

        { }

        public override void Run(string[] args)
        {
            
        }
    }
}