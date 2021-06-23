using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
	static class CommandLineInterface
	{
		private static Command[] commands = new Command[] {
			new Commands.Help()
		};

		public static void RunMainLoop() {
			while (true) {
				Console.Write($"pnut> ");
				string command_line = Console.ReadLine();
				foreach(Command command in commands)
					if(command.Names.Contains(GetCommand(command_line))) {
						command.Run(GetArguments(command_line));
						break;
					}
			}
		}

		public static string GetCommand(string command_line) {
			string[] words = command_line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (words.Length == 0)
				return "";
			return words[0];
		}

		public static string[] GetArguments(string command_line) {
			List<string> args = new List<string>();
			bool inBrackets = false;
			string currentArg = "";
			for (int i = 0; i < command_line.Length; i++) {
				if (inBrackets) {
					if (command_line[i] == '"') {
						inBrackets = false;
						if (currentArg != "") { args.Add(currentArg); currentArg = ""; }
					}

					else currentArg += command_line[i];
				}

				else {
					if (command_line[i] == '"') {
						inBrackets = true;
						if (currentArg != "") { args.Add(currentArg); currentArg = ""; }
						currentArg = "";
					}

					else {
						if (command_line[i] == ' ') {
							if (currentArg != "") { args.Add(currentArg); currentArg = ""; }
						}
						else currentArg += command_line[i];
					}
				}
			}

			if (currentArg != "") args.Add(currentArg);
			return args.ToArray();
		}
	}
}
