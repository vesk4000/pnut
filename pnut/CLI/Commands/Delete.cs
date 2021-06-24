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

        }
    }
}