using System;
using System.Collections.Generic;
using System.Linq;

namespace pnut
{
    public class Assignment
    {
        public Contestant Contestant { get; private set; }
        public Problem Problem { get; private set; }
        public string SourceDirectory { get; private set; }
        public string ExecutableDirectory { get; private set; }
        public List<AssignmentTest> Tests { get; private set; }
        public bool ToJudge { get; private set; }
        public bool ToDelete { get; private set; }
        public List<TestResult> Results { get; private set; }

        public void JudgeNext()
        {
            throw new NotImplementedException();
        }

        public int GetPoints() => Results.Count(e => e == TestResult.OK) / Results.Count();
        public int GetStatus() => Results.Count(e => e != TestResult.TBD) / Results.Count();
        public void PrintProgressBar()
        {
            Console.Write("[");
            foreach (var result in Results)
            {
                switch (result)
                {
                    case TestResult.OK:
                        PrintProgressSegment(ConsoleColor.Green);
                        break;
                    case TestResult.WA:
                        PrintProgressSegment(ConsoleColor.Red);
                        break;
                    case TestResult.CE:
                        PrintProgressSegment(ConsoleColor.DarkMagenta);
                        break;
                    case TestResult.RE:
                        PrintProgressSegment(ConsoleColor.Blue);
                        break;
                    case TestResult.TL:
                        PrintProgressSegment(ConsoleColor.DarkYellow);
                        break;
                    case TestResult.ML:
                        PrintProgressSegment(ConsoleColor.Yellow);
                        break;
                    case TestResult.TBD:
                        PrintProgressSegment(ConsoleColor.Gray);
                        break;
                }
            }
            Console.WriteLine("]");
        }
        public void PrintProgressSegment(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write('-');
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public Assignment(Contestant contestant, Problem problem, string sourceDirectory, string executableDirectory, List<AssignmentTest> tests, bool toJudge, bool toDelete)
        {
            Contestant = contestant;
            Problem = problem;
            SourceDirectory = sourceDirectory;
            ExecutableDirectory = executableDirectory;
            Tests = tests;
            ToJudge = toJudge;
            ToDelete = toDelete;
            Results = new List<TestResult>();
            foreach (var test in tests)
            {
                Results.Add(test.Result);
            }
        }


    }
}
