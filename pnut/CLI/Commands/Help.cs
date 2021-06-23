using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class Help : Command
    {
        public Help() :
            base("help",
            "Provides a description of pnut's commands",
            "extra description") { }

        public override void Run(string[] args) {
            Console.WriteLine(String.Join("/", Names.ToArray()) + " - " + Description);
            Console.WriteLine(ExtraDescription);
            Console.WriteLine();
        }
    }
}
