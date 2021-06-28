using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pnut.Commands
{
    class Judge : Command
    {
        public Judge() :
            base("judge",
            "Judges all of the contestants' solutions",
            @"Arguments:
<path to the g++ compiler(file path)> - A file path to your g++ compiler which is to be used to compile the contestants' solution")

        { }

        public override void Run(string[] args)
        {
            if (args.Length == 0 || args.Length > 1)
            {
                ConsoleExt.WriteError("The judge command only requires that you enter the path to the g++ compiler");
                return;
            }

            if(!File.Exists(args[0]) || ( new FileInfo(args[0]) ).Name != "g++.exe" )
            {
                ConsoleExt.WriteError("The path specified for the g++ compiler is not valid");
                return;
            }

            Settings.GppPath = args[0];
            Task.Run(() => pnut.Judge.Run());
        }
    }
}