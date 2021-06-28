using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pnut
{
	public class Problem : Entity
	{
		public int MemoryLimit { get; private set; }

		public double TimeLimit { get; private set; }

		public string TestsDirectory { get; private set; }

		public List<Test> Tests { get; private set; }

		public Problem(string name, string testsDirectory, double timeLimit, int memoryLimit, string inputExt, string outputExt) :
			base(name)
		{
			MemoryLimit = memoryLimit;
			TimeLimit = timeLimit;
			TestsDirectory = testsDirectory;
			Tests = new List<Test>();

			bool hasFound = false;
			foreach(FileInfo file in (new DirectoryInfo(testsDirectory)).GetFiles()) {
				if(file.Extension == "." + inputExt && File.Exists(testsDirectory + "\\" + file.Name.Replace(inputExt, outputExt)) ) {
					Tests.Add(new Test(file.Name.Replace("." + inputExt, ""),
						File.ReadAllText(file.FullName), File.ReadAllText(testsDirectory + "\\" + file.Name.Replace(inputExt, outputExt))) );
					hasFound = true;
				}
			}
			if (!hasFound)
				ConsoleExt.WriteWarning("No tests with such extensions were found!");
		}
	}
}
