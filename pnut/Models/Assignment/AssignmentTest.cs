using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
    class AssignmentTest
    {
        public TestResult Result { get; private set; }
        public Test Test { get; private set; }

        public AssignmentTest(TestResult result, Test test)
        {
            Result = result;
            Test = test;
        }
    }
}
