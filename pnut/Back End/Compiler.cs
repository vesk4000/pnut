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
	class Compiler
	{
		static string GppPath = @"C:\MinGW\bin\g++.exe";
		public static bool Compile(string source, string target = null) {
			Console.WriteLine("Compiler thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
			if (!File.Exists(source)) {
				AnsiConsole.MarkupLine("[red]Source file does not exist. Aborting compilation.[/]");
				return false;
			}

			if (!File.Exists(GppPath)) {
				AnsiConsole.MarkupLine("[red]G++ compiler path is not correct. Aborting compilation.[/]");
				return false;
			}

			if (target == null)
				target = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\Compiled.exe";

			Console.WriteLine("Will start sleepin");
			Thread.Sleep(2000);

			AnsiConsole.MarkupLine(target);

			if (File.Exists(target))
				File.Delete(target);

			Process gpp = new Process();
			gpp.StartInfo.FileName = GppPath;
			gpp.StartInfo.UseShellExecute = false;
			gpp.StartInfo.WorkingDirectory = Path.GetDirectoryName(source);
			gpp.StartInfo.Arguments = "\"" + Path.GetFileName(source) + "\"" + " -o " + "\"" + target + "\""/* + " -static-libgcc -static-libstdc++"*/;
			gpp.Start();
			gpp.WaitForExit();

			/*
			Process cmd = new Process();
			cmd.StartInfo.FileName = "cmd.exe";
			cmd.StartInfo.UseShellExecute = false; // Some shit the program needs to work

			// Hide the cmd window
			//cmd.StartInfo.CreateNoWindow = true;
			//cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

			// Redirect the input to write commands
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.RedirectStandardOutput = true;

			// Start the program
			cmd.Start();

			//Change to the drive where g++ is
			string t;
			t = GppPath.Substring(0, 2);
			t.ToLower();
			cmd.StandardInput.WriteLine(t);

			//Go to where g++ is
			GppPath = GppPath.Replace("\\g++.exe", "");
			cmd.StandardInput.WriteLine("cd " + GppPath);

			//Compile
			cmd.StandardInput.WriteLine("g++ " + "\"" + source + "\"" + " -o " + "\"" + target + "\"" + " -static-libgcc -static-libstdc++");

			AnsiConsole.MarkupLine("Compiling...");

			//Close the cmd
			cmd.StandardInput.Flush();
			cmd.StandardInput.Close();
			cmd.WaitForExit();*/

			AnsiConsole.MarkupLine("Compiled");
			return true;
		}
	}
}
