using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace pnut
{
	static class ConsoleExt
	{
		public static void WriteError(string s) {
			AnsiConsole.MarkupLine("[red]Error: [/]" + s);
		}

		public static void WriteWarning(string s) {
			AnsiConsole.MarkupLine("[yellow]Warning: [/]" + s);
		}
	}
}
