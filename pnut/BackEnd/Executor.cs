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
	class Executor
	{
		public static int MonitorInterval = 50;

		static TestResult Monitor(Process process, Problem problem) {
			while(!process.HasExited) {
				if(problem.TimeLimit != -1 && !process.HasExited && process.TotalProcessorTime.TotalMilliseconds > problem.TimeLimit) {
					process.Kill();
					return TestResult.TL;
				}
				if (problem.MemoryLimit != -1 && !process.HasExited && process.PrivateMemorySize64 > Utilities.MB2Bytes(problem.MemoryLimit)) {
					process.Kill();
					return TestResult.ML;
				}
				Thread.Sleep(MonitorInterval);
			}
			return TestResult.OK;
		}

		public static TestResult Execute(string executable, Test test, Problem problem) {
			if(executable == null || !File.Exists(executable)) {
				AnsiConsole.MarkupLine("[red]PNUT Executor: Executable file is not valid. Aborting execution.[/]");
				return TestResult.RE;
			}

			Process solution = new Process();
			solution.StartInfo.FileName = executable;
			solution.StartInfo.UseShellExecute = false;
			solution.StartInfo.CreateNoWindow = true;
			solution.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			solution.StartInfo.RedirectStandardInput = true;
			solution.StartInfo.RedirectStandardOutput = true;

			string[] input = Utilities.ConvertToCRLF(File.ReadAllText(test.input))
				.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
			string output = Utilities.ConvertToCRLF(File.ReadAllText(test.output));

			/*Console.InputEncoding = Encoding.Default;
			Console.OutputEncoding = Encoding.Default;*/
			solution.Start();
			/*Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;*/

			Task<TestResult> monitor = Task.Run(() => Monitor(solution, problem));

			foreach (string line in input)
				solution.StandardInput.WriteLine(line);

			string solutionOutput = solution.StandardOutput.ReadToEnd();
			solution.WaitForExit();

			if (monitor.Result != TestResult.OK)
				return monitor.Result;

			/*Console.WriteLine(Console.InputEncoding);
			Console.WriteLine(Console.OutputEncoding);*/
			//Console.WriteLine(solution.PeakWorkingSet64);
			if (solutionOutput != output) {
				//Console.WriteLine(solutio);
				return TestResult.WA;
			}
				
			return TestResult.OK;
		}
	}
}
