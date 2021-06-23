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
            @"Arguments:
[command (string)]
[command (string)]
[command (string)]
...
Examples and notes:
pnut> help contestant
*pastes the help description of contestant*
pnut> help *
this gives you the descriptions of all commands

List of available commands:
help - Provides a description and usage of punt's commands
exit/quit - terminates this pnut process
clear - clears the console
contestant - adds a new contestant or modifies an existing one
problem - adds a new problem or modifies an existing one
delete - deletes an existing problem or contestant
save - saves the current state of pnut
load - loads a pnut state
judge - starts judging a set of problems or contestants
assign - assigns a problem to contestants
status - prints the current status of the judge
monitor - continuously prints the status
export - exports the results of the judge
") { }

        public override void Run(string[] args) {
            Console.WriteLine();
            if (args.Length == 0)
            {
                Console.WriteLine(String.Join("/", Names.ToArray()) + " - " + Description);
                Console.WriteLine(ExtraDescription);
                return;
            }

            foreach (string arg in args)
            {
                Command command = CommandLineInterface.GetCommandByName(arg);
                if(command != null)
                {
                    Console.WriteLine(string.Join("/", command.Names.ToArray()) + " - " + command.Description);
                    Console.WriteLine(command.ExtraDescription);
                }
            }

        }
    }
}
