using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace pnut
{
	public class Assignment
	{
		public Contestant Contestant { get; private set; }
		public Problem Problem { get; private set; }
		public string SourceFile { get; private set; }
		public string ExecutableFile;
		public List<AssignmentTest> Tests { get; private set; }
		public bool IsDone = false;
		public bool IsCompiled = false;

		public int GetPoints() => (int)((Tests.Count(e => e.Result == TestResult.OK) / (double)Tests.Count()) * 100);
		public int GetStatus() => (int)((Tests.Count(e => e.Result != TestResult.TBD) / (double)Tests.Count()) * 100);
		public void PrintProgressBar() {
			Console.Write("[");
			double OkResults = ((Tests.Count(e => e.Result == TestResult.OK) * 20 / Tests.Count));
			double WaResults = (Tests.Count(e => e.Result == TestResult.WA) * 20 / Tests.Count);
			double CeResults = (Tests.Count(e => e.Result == TestResult.CE) * 20 / Tests.Count);
			double ReResults = (Tests.Count(e => e.Result == TestResult.RE) * 20 / Tests.Count);
			double TlResults = (Tests.Count(e => e.Result == TestResult.TL) * 20 / Tests.Count);
			double MlResults = (Tests.Count(e => e.Result == TestResult.ML) * 20 / Tests.Count);
			double TBDResults = (20 - OkResults - WaResults - CeResults - ReResults - TlResults - MlResults);
			PrintProgressSegment(ConsoleColor.Green, OkResults);
			PrintProgressSegment(ConsoleColor.Red, WaResults);
			PrintProgressSegment(ConsoleColor.DarkMagenta, CeResults);
			PrintProgressSegment(ConsoleColor.Blue, ReResults);
			PrintProgressSegment(ConsoleColor.DarkYellow, TlResults);
			PrintProgressSegment(ConsoleColor.Yellow, MlResults);
			PrintProgressSegment(ConsoleColor.Gray, TBDResults);
			Console.WriteLine("]");
		}
		public void PrintProgressSegment(ConsoleColor color, double count) {
			Console.ForegroundColor = color;
			Console.Write(new string('-', (int)Math.Floor(count)));
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public Assignment(Contestant contestant, Problem problem)
		{
			Contestant = contestant;
			Problem = problem;
			SourceFile = contestant.SourcesDirectory + "\\" + problem.Name + ".cpp";
			Tests = new List<AssignmentTest>();
			if (!File.Exists(SourceFile)) {
				ConsoleExt.WriteWarning($"Contestant {contestant.Name} does not have a source file for {problem.Name}");
				IsDone = true;
				return;
			}
			foreach (Test test in problem.Tests)
			{
				Tests.Add(new AssignmentTest(TestResult.TBD, test));
			}


		}


	}
}
