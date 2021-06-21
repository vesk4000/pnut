using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
    public class Problem : Entity
    {
        public int MemoryLimit { get; private set; }

        public double TimeLimit { get; private set; }

        public double Points { get; private set; }

        public List<Test> Tests { get; private set; }

        public Problem(string name, int memoryLimit, double timeLimit, double points, List<Test> tests) : base(name)
        {
            MemoryLimit = memoryLimit;
            TimeLimit = timeLimit;
            Points = points;
            Tests = new List<Test>(tests);
        }
    }
}
