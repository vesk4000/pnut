using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class List : Command
    {
        public List() :
            base("list",
            "List all problems or contestants",
            @"Arguments:
[problems|contestants]
Examples:
pnut> list contestants
*This will list all of the contestants*
pnut> list problems - This lists all problems
*This will list all of the problems") { }

        public override void Run(string[] args) {
            if (args.Length > 1) {
                ConsoleExt.WriteError("Too many arguments!");
                return;
            }

            if (args.Length == 0) {
                Console.WriteLine("Contestants:");
                lock (pnut.Judge.EntitiesLock)
                    foreach (Entity entity in pnut.Judge.Entities) {
                        if (entity is pnut.Contestant) Console.WriteLine(entity.Name);
                    }

                Console.WriteLine("Problems:");
                lock (pnut.Judge.EntitiesLock)
                    foreach (Entity entity in pnut.Judge.Entities) {
                        if (entity is pnut.Problem) Console.WriteLine(entity.Name);
                    }

                return;
            }

            if (args[0] == "contestants") {
                Console.WriteLine("Contestants:");
                lock (pnut.Judge.EntitiesLock)
                    foreach (Entity entity in pnut.Judge.Entities) {
                        if (entity is pnut.Contestant) Console.WriteLine(entity.Name);
                    }
            }

            else if (args[0] == "problems") {
                Console.WriteLine("Problems:");
                lock (pnut.Judge.EntitiesLock)
                    foreach (Entity entity in pnut.Judge.Entities) {
                        if (entity is pnut.Problem) Console.WriteLine(entity.Name);
                    }
            }

            else ConsoleExt.WriteError("Invalid argument!");
        }
    }
}