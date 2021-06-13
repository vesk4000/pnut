using System;
using System.Collections.Generic;

namespace pnut
{
    class Assignment
    {
        public Contestant Contestant { get; private set; }
        public Problem Problem { get; private set; }
        public string SourceDirectory { get; private set; }
        public string ExecutableDirectory { get; private set; }
        public List<AssignmentTest> Tests { get; private set; }
        public bool ToJudge { get; private set; }
        public bool ToDelete { get; private set; }

        public void JudgeNext()
        {
            throw new NotImplementedException();
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
        }

    }
}
