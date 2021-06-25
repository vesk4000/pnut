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

Examples and notes:
pnut> help contestant
This displays the help description of contestant
pnut> help *
This displays the descriptions of all commands

List of available commands:
help - Provides a description and usage of punt's commands
exit/quit - Terminates this pnut process
clear - Clears the console
contestant - Adds a new contestant or modifies an existing one
problem - Adds a new problem or modifies an existing one
delete - Deletes an existing problem or contestant
save - Saves the current state of pnut
load - Loads a pnut state
judge - Starts judging a set of problems or contestants
assign - Assigns a problem to contestants
status - Prints the current status of the judge
monitor - Continuously prints the status
export - Exports the results of the judge
") { }

        public override void Run(string[] args) {
            Console.WriteLine();
            if (args.Length == 0)
            {
                Console.WriteLine(String.Join("/", Names.ToArray()) + " - " + Description);
                Console.WriteLine(ExtraDescription);
                return;
            }

            HashSet<Command> commandsList = new HashSet<Command>();
            HashSet<string> wrongCommands = new HashSet<string>();

            foreach (string arg in args)
            {
                /*Command command = CommandLineInterface.GetCommandByName(arg);
                if (command != null)
                {
                    Console.WriteLine(string.Join("/", command.Names.ToArray()) + " - " + command.Description);
                    if(command.ExtraDescription != "") Console.WriteLine(command.ExtraDescription);
                    Console.WriteLine();
                }*/

                if (arg == "*" || arg == "all")
                {
                    foreach (Command comm in CommandLineInterface.commands)
                        commandsList.Add(comm);
                    continue;
                }

                Command command = CommandLineInterface.GetCommandByName(arg);

                if (command != null) commandsList.Add(command);
                else wrongCommands.Add(arg);
            }

            foreach (Command actualCommand in commandsList)
            {
                Console.WriteLine(string.Join("/", actualCommand.Names.ToArray()) + " - " + actualCommand.Description);
                if (actualCommand.ExtraDescription != "") Console.WriteLine(actualCommand.ExtraDescription);
                Console.WriteLine();
            }

            foreach (string wrongCommand in wrongCommands)
            {
                ConsoleExt.WriteWarning(wrongCommand + " is not a valid command!");
            }

        }
    }
}
