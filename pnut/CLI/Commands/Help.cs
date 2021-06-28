using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace pnut.Commands
{
	class Help : Command
	{
		public Help() :
			base("help",
"Provides descriptions for pnut's commands",
"You can specify one or even several commands at one time.",
new Tuple<string, string>[] {
	new Tuple<string, string>("{command(string)}", "name of the command(s) that you want the description of"),
},
$@"{ConsoleExt.CommentPrefix}This will display this descripton of help as well as the list of avaliable commands[/]
{ConsoleExt.PnutPromt}help

{ConsoleExt.PnutPromt}help contestant

{ConsoleExt.PnutPromt}help problem judge exit

{ConsoleExt.CommentPrefix}This displays the descriptions of all commands in pnut[/]
{ConsoleExt.PnutPromt}help all

{ConsoleExt.CommentPrefix}As does this[/]
{ConsoleExt.PnutPromt}help *"
) { }

		public override void Run(string[] args) {
			HashSet<Command> commandsList = new HashSet<Command>();
			HashSet<string> wrongCommands = new HashSet<string>();

			Console.WriteLine();
			if (args.Length == 0)
				commandsList.Add(CommandLineInterface.GetCommandByName("help"));

			foreach (string arg in args)
			{
				if (arg == "*" || arg == "all")
				{
					foreach (Command comm in CommandLineInterface.commands)
						commandsList.Add(comm);
					continue;
				}

				Command command = CommandLineInterface.GetCommandByName(arg);

				if (command != null)
					commandsList.Add(command);
				else
					wrongCommands.Add(arg);
			}

			foreach (Command actualCommand in commandsList)
			{
				ConsoleExt.WriteGradientHeader(string.Join("/", actualCommand.Names));
				Console.WriteLine();

				AnsiConsole.MarkupLine("  " + actualCommand.Description + ".");
				if(actualCommand.ExtraDescription != "") {
					Table table = new Table();
					table.AddColumn(" ");
					table.AddColumn(actualCommand.ExtraDescription);
					table.Border(TableBorder.None);
					AnsiConsole.Render(table);
				}
				Console.WriteLine();

				if (actualCommand.Arguments.Length > 0) {
					AnsiConsole.MarkupLine("[bold underline]Arguments:[/]");
					Console.WriteLine();
					/*Table table = new Table();
					table.AddColumns(" ", $"[bold {ConsoleExt.GreenAccent}]" + actualCommand.Arguments[0].Item1 + "[/]",
						"- " + actualCommand.Arguments[0].Item2);
					for (int i = 1; i < actualCommand.Arguments.Length; ++i) {
						table.AddRow(" ", $"[bold {ConsoleExt.GreenAccent}]" + actualCommand.Arguments[i].Item1 + "[/]",
						"- " + actualCommand.Arguments[i].Item2);
					}
					table.Border(TableBorder.None);
					AnsiConsole.Render(table);*/
					ConsoleExt.WriteTupleTable(actualCommand.Arguments);
					Console.WriteLine();
				}

				if (actualCommand.Examples != "") {
					AnsiConsole.MarkupLine("[bold underline]Examples:[/]");
					Console.WriteLine();
					Table table = new Table();
					table.AddColumn(" ");
					table.AddColumn(actualCommand.Examples);
					table.Border(TableBorder.None);
					AnsiConsole.Render(table);
					Console.WriteLine();
				}

				if(actualCommand.Names.Contains("help")) {
					ConsoleExt.WriteGradientHeader("List of avaliable commands:");
					List<Tuple<string, string>> tuples = new List<Tuple<string, string>>();
					foreach(Command command in CommandLineInterface.commands)
						tuples.Add(new Tuple<string, string>(string.Join("/", command.Names), command.Description));
					ConsoleExt.WriteTupleTable(tuples.ToArray());
					Console.WriteLine();
				}
			}

			foreach (string wrongCommand in wrongCommands)
			{
				ConsoleExt.WriteWarning(wrongCommand + " is not a valid command!");
			}

		}
	}
}
