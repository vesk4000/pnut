using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			new Commands.Save(),
			new Commands.Load(),
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
				if (command.Names.Contains(name))
				{
					ans = command;
					break;
				}
			return ans;
		}

		public static void RunMainLoop() {
			while (true) {
				Console.Write($"pnut> ");
				string command_line = Console.ReadLine().ToLower();
				Command command = GetCommandByName(GetCommand(command_line));
				if (command != null) { command.Run(GetArguments(command_line)); Console.WriteLine(); }
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
