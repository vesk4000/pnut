using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
	static class Judge
	{
		public static List<Entity> Entities = new List<Entity>();
		public static readonly object EntitiesLock = new object();

		public static List<Assignment> Assignments = new List<Assignment>();
		public static readonly object AssignmentsLock = new object();

		private static bool stop = false;

		public static void Run() {
			/*while (true) {
				Commands.Monitor monitor = CommandLineInterface.commands[8] as Commands.Monitor;
				if (monitor.isInMonitor == true)
					monitor.UpdateConsole();
				*/RunNext();/*
				if(stop) {
					stop = false;
					Console.Clear();
					break;
				}
			}*/
		}

		public static void RunNext() {
			lock (AssignmentsLock) {
				bool executed = false;
				foreach (Assignment assignment in Assignments) {
					if (!assignment.IsDone) {
						executed = true;
						if(!assignment.IsCompiled) {
							bool compiled = Compiler.Compile( assignment.SourceFile, assignment.SourceFile.Replace(".cpp", ".exe") );
							if(compiled) {
								assignment.IsCompiled = true;
								assignment.ExecutableFile = assignment.SourceFile.Replace(".cpp", ".exe");
							}
							else {
								assignment.IsDone = false;
								foreach(AssignmentTest test in assignment.Tests) {
									test.Result = TestResult.CE;
								}
								return;
							}
						}
						foreach(AssignmentTest aTest in assignment.Tests) {
							if (aTest.Result == TestResult.TBD) {
								aTest.Result = Executor.Execute(assignment.ExecutableFile, aTest.Test, assignment.Problem);
							}
						}
						bool hasDoneAll = true;
						foreach (AssignmentTest aTest in assignment.Tests) {
							if (aTest.Result == TestResult.TBD) {
								hasDoneAll = false;
								break;
							}
						}
						if (hasDoneAll)
							assignment.IsDone = true;
					}
				}
				if (executed == false) {
					stop = true;
				}
			}
		}
	}
}
