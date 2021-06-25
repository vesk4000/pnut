using System;
using System.Collections.Generic;

namespace pnut
{
	public class Contestant : Entity
	{
		//public char Group { get; private set; }
		public string SourcesDirectory { get; private set; }
		//public string city { get; private set; }
		//public string country { get; private set; }
		//public string tag { get; private set; }

		public Contestant(string name, string sources_directory, string[] tags = null) :
			base(name, tags) {
			SourcesDirectory = sources_directory;
		}

		public Assignment[] GetAssignments()
		{
			//TODO
			var result = new Assignment[2];
			var assTests = new List<AssignmentTest>();
			assTests.Add(new AssignmentTest(TestResult.OK, new Test("123", "123")));
			assTests.Add(new AssignmentTest(TestResult.TBD, new Test("123", "123")));
			assTests.Add(new AssignmentTest(TestResult.TL, new Test("123", "123")));
			assTests.Add(new AssignmentTest(TestResult.OK, new Test("123", "123")));
			assTests.Add(new AssignmentTest(TestResult.WA, new Test("123", "123")));
			assTests.Add(new AssignmentTest(TestResult.WA, new Test("123", "123")));
			assTests.Add(new AssignmentTest(TestResult.ML, new Test("123", "123")));
			assTests.Add(new AssignmentTest(TestResult.CE, new Test("123", "123")));
			assTests.Add(new AssignmentTest(TestResult.RE, new Test("123", "123")));

			result[0] = new Assignment(this, new Problem("bananaProb", 5,  0.6, 50, new List<Test>()), 
				SourcesDirectory, "rndDir", assTests, false, false);
			result[1] = new Assignment(this, new Problem("testProb", 5, 0.6, 75, new List<Test>()),
				SourcesDirectory, "rndDir", assTests, false, false);
			return result;

		}
		//public Contestant(string name, char group, string sourcesDirectory, string city, string country) : base(name)
		//{
		//    Group = group;
		//    SourcesDirectory = sourcesDirectory;
		//    City = city;
		//    Country = country;
			
		//}
	}
}
