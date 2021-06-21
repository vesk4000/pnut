using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
	static class Commands
	{
		static public void _RunCommandLine(string command_line) {
			switch(command_line) {
				case "help":
					Help(_GetArguments(command_line));
					break;
			}
		}

		static public string _GetCommand(string command_line) {
			return command_line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
		}

		static public string[] _GetArguments(string command_line) {
			string[] words = command_line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			string[] args = new string[words.Length - 1];
			for(int i = 1; i <= words.Length - 1; ++i)
				args[i - 1] = words[i];
			return args;
		}

		static public void Help(string[] args) {
			Console.WriteLine("You called hlep");
		}
	}
}
