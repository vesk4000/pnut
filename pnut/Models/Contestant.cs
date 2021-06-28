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
			List<Assignment> assignments = new List<Assignment>();
			foreach(Assignment assignment in Judge.Assignments) {
				if (assignment.Contestant == this)
					assignments.Add(assignment);
			}
			return assignments.ToArray();

		}
	}
}
