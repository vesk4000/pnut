using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace pnut
{
	static class CommandLineInterface
	{
		public static Command[] commands = new Command[] { 
			new Commands.Help(),
			new Commands.Exit(),
			new Commands.Problem(),
			new Commands.Contestant(),
			new Commands.Delete(),
			new Commands.Judge(),
			new Commands.Assign(),
			new Commands.Status(),
			new Commands.Monitor(),
			new Commands.Export(),
			new Commands.Clear(),
			new Commands.List()
		};

		public static Command GetCommandByName(string name) {
			Command ans = null;
			foreach (Command command in commands)
				if (command.Names.Contains(name.ToLower()))
				{
					ans = command;
					break;
				}
			return ans;
		}

		public static void RunMainLoop() {
			AnsiConsole.MarkupLine($"Welcome to [bold {ConsoleExt.GreenAccent}]pnut[/], type [bold {ConsoleExt.GreenAccent}]help[/] for more information.");
			Console.WriteLine();
			//█─────────────────────────────────  ▬▬▬▬▬▬
			/*Console.WriteLine();
			ConsoleExt.WriteGradientHeader("contestant");
			//AnsiConsole.MarkupLine("[bold underline]contestant[/]");
			Console.WriteLine();
			AnsiConsole.MarkupLine(@"  Adds a new contestant or modifies an existing one.
  Contestants can then be assigned problems so their solutions can be judged.
  Created contestants are not saved after you exit the program.");
			Console.WriteLine();
			AnsiConsole.MarkupLine("[bold underline]Arguments:[/]");
			Console.WriteLine();
			Table tableArgs = new Table();
			tableArgs.AddColumn(new TableColumn(new Markup(" ")));
			// gold1
			// yellow
			// lightgoldenrod3
			// lightgreen
			// lightgreen_1
			// springgreen1 - green
			// mediumspringgreen - teal
			// seagreen1
			// seagreen1_1
			// palegreen1
			tableArgs.AddColumn(new TableColumn(new Markup("[springgreen1]<name(string)>[/]")));
			tableArgs.AddColumn(new TableColumn(new Markup("- name of the contestant")));
			tableArgs.AddRow(new Markup(" "), new Markup("[springgreen1]<sources_directory(folder_path)>[/]"), new Markup("- path to the directory with the contestant's solutions"));
			tableArgs.AddRow(new Markup(" "), new Markup("[springgreen1]{tag(string)}[/]"), new Markup("- any other tags like group, country, city, etc."));
			tableArgs.Border(TableBorder.None);
			AnsiConsole.Render(tableArgs);

			Console.WriteLine();

			AnsiConsole.MarkupLine("[bold underline]Examples:[/]");
			AnsiConsole.MarkupLine(@"
  [grey58]// This creates a contestant John, with a source directory and his tags are B, Varna and Bulgaria[/]
  [bold springgreen1]pnut>[/] contestant John ""C:/John's solutions"" B Varna Bulgaria

  [bold springgreen1]pnut>[/] contestant Tom C:/Users/Tom/Desktop

  [bold springgreen1]pnut>[/] contestant Ben D:/Solutions/Ben ""Anything can be a tag"" You can set as many tags as you want, this line has 14");

			Console.WriteLine();*/

			while (true) {
				AnsiConsole.Markup($"[bold springgreen1]pnut> [/]");
				string command_line = ConsoleExt.ReadHintedLine(commands, cmd => cmd.Names.ToArray()[0]);
				/*string command_line = "help contestant problem";
				Console.ReadLine();*/
				Command command = GetCommandByName(GetCommand(command_line));
				if (command != null) { command.Run(GetArguments(command_line));}
				else ConsoleExt.WriteError("Invalid command!");
			}
		}

		public static string GetCommand(string command_line) {
			string[] words = command_line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (words.Length == 0)
				return "";
			return words[0];
		}

		public static string[] GetArguments(string command_line) {
			List<string> words = new List<string>();
			bool inBrackets = false;
			string currentArg = "";
			for (int i = 0; i < command_line.Length; i++) {
				if (inBrackets) {
					if (command_line[i] == '"') {
						inBrackets = false;
						if (currentArg != "") { words.Add(currentArg); currentArg = ""; }
					}

					else currentArg += command_line[i];
				}

				else {
					if (command_line[i] == '"') {
						inBrackets = true;
						if (currentArg != "") { words.Add(currentArg); currentArg = ""; }
						currentArg = "";
					}

					else {
						if (command_line[i] == ' ') {
							if (currentArg != "") { words.Add(currentArg); currentArg = ""; }
						}
						else currentArg += command_line[i];
					}
				}
			}

			if (currentArg != "") words.Add(currentArg);

			string[] args = new string[words.Count - 1];
			for (int i = 1; i < words.Count; i++)
				args[i - 1] = words[i];

			return args;
		}
	}
}
