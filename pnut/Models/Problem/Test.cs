using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
    public class Test
    {
        public string InputFileDirectory { get; private set; }
        public string OutputFileDirectory { get; private set; }

        public Test(string inputFileDirectory, string outputFileDirectory)
        {
            InputFileDirectory = inputFileDirectory;
            OutputFileDirectory = outputFileDirectory;
        }
    }
}
