using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Spectre.Console;
using System.Diagnostics;
using System.Threading;

namespace pnut
{
	class Compiler {
		static string GppPath = @"C:\MinGW\bin\g++.exe";
		public static bool Compile(string source, string target) {
			if (target == null) {
				AnsiConsole.MarkupLine("[red]PNUT Compiler: Target (executable) file path is not valid. Aborting compilation.[/]");
				return false;
			}
			if (Utilities.HasNonASCIIChars(target)) {
				AnsiConsole.MarkupLine("[red]PNUT Compiler: The target (executable) file path contains non-ASCII characters. Aborting compilation.[/]");
				return false;
			}
			if (source == null || !File.Exists(source)) {
				AnsiConsole.MarkupLine("[red]PNUT Compiler: Source file does not exist. Aborting compilation.[/]");
				return false;
			}
			if (GppPath == null || !File.Exists(GppPath)) {
				AnsiConsole.MarkupLine("[red]PNUT Compiler: Path to the G++ compiler is not correct. Aborting compilation.[/]");
				return false;
			}

			if (File.Exists(target))
				File.Delete(target);

			Process gpp = new Process();
			gpp.StartInfo.FileName = GppPath;
			gpp.StartInfo.UseShellExecute = false;
			gpp.StartInfo.WorkingDirectory = Path.GetDirectoryName(source);
			gpp.StartInfo.Arguments = $@"""{Path.GetFileName(source)}"" -o ""{target}"" -O3";
			gpp.Start();
			gpp.WaitForExit();

			if (!File.Exists(target))
				return false;
			return true;
		}
	}
}
