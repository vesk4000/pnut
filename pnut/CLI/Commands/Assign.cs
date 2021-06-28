using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
	class Assign : Command
	{
		public Assign() :
			base("assign",
			"Assigns an existing problem to a contestant",
			@"Arguments:
<problem_name (string)> - problem to assign to the contestant
{contestant_name (string)} - name of the contestant") { }

		public override void Run(string[] args) {
			if (args.Length < 2) {
				ConsoleExt.WriteError("Assign command requires at least 2 arguments!");
				return;
			}

			HashSet<string> wrongContestants = new HashSet<string>();

			bool hasFound = false;
			int problemIndex = 0;
			lock (pnut.Judge.EntitiesLock)
				for (int i = 0; i < pnut.Judge.Entities.Count; ++i) {
					if (pnut.Judge.Entities[i].Name == args[0] && pnut.Judge.Entities[i] is pnut.Problem) {
						hasFound = true;
						problemIndex = i;
						break;
					}
				}


			if (!hasFound) {
				ConsoleExt.WriteError(string.Format("Problem {0} does not exist!", args[0]));
				return;
			}

			for (int i = 1; i < args.Length; i++)
				wrongContestants.Add(args[i]);

			List<pnut.Contestant> validContestants = new List<pnut.Contestant>();
			lock (pnut.Judge.EntitiesLock)
				for (int i = 0; i < pnut.Judge.Entities.Count; ++i) {
					if (pnut.Judge.Entities[i] is pnut.Contestant)
						if (wrongContestants.Remove(pnut.Judge.Entities[i].Name))
							validContestants.Add(pnut.Judge.Entities[i] as pnut.Contestant);
				}

			foreach (string wrongContestant in wrongContestants)
				ConsoleExt.WriteWarning(string.Format("{0} is not a valid contestant!", wrongContestant));

			lock (pnut.Judge.AssignmentsLock) {
				lock (pnut.Judge.EntitiesLock) {
					foreach (pnut.Contestant contestant in validContestants) {
						pnut.Judge.Assignments.Add(new Assignment(contestant, pnut.Judge.Entities[problemIndex] as pnut.Problem));
					}
				}
			}

			if (validContestants.Count != 0) 
				ConsoleExt.WriteSuccess(string.Format("Problem {0} was successfully assigned!", args[0]));
			else
				ConsoleExt.WriteError("Problem was not assigned! No valid contestants were provided!");
		}
	}
}