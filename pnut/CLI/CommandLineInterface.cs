using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
	static class CommandLineInterface {
		public static void Run() {
			while(true) {
				Console.Write($"pnut> ");
				string input = Console.ReadLine().Trim();
				if (input == "exit")
					return;
				Commands._RunCommandLine(input);
			}
		}
	}
}
