using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pnut.Commands
{
	public class Monitor : Command
	{
		private static List<pnut.Contestant> tempContestants;
		//TODO
		public Monitor() : base("monitor", "needsDescr", "needsExtDescr")
		{

		}

		public override void Run(string[] args)
		{
			InitializeTempData();
			StringBuilder output = new StringBuilder();
			while (true)
			{
				StringBuilder current = new StringBuilder();
				current.AppendLine($"|     Contestant     | Group |    Problem    | Points | Status |      Progress      |");
				foreach (var contestant in tempContestants)
				{
					current.Append($"|{contestant.Name,-20}|{contestant.Tags[0],-7}|");
					foreach (var assignment in contestant.GetAssignments())
					{
						if(Console.CursorLeft >= 25) current.Append($"{assignment.Problem.Name,-15}|{assignment.GetPoints(),-8}|{assignment.GetStatus(),-8}|");
						else current.Append($"{' ', 29}|{assignment.Problem.Name,-15}|{assignment.GetPoints(),-8}|{assignment.GetStatus(),-8}|");

						assignment.PrintProgressBar();
					}

					current.AppendLine(new string('-', 85));
				}
				Thread.Sleep(1000);
				Console.Clear();
			}


		}

		private void InitializeTempData()
		{
			tempContestants = new List<pnut.Contestant>();
			/*tempContestants.Add(new pnut.Contestant(
				"John Doe",
				'B',
				"rndDirectory",
				"Varna",
				"Bulgaria"
			));
			tempContestants.Add(new pnut.Contestant(
				"John Doen",
				'A',
				"rndDirectory",
				"Burgas",
				"Bulgaria"
			));*/
			tempContestants.Add(new pnut.Contestant(
				"Jane Doe",
				"rndDirectory",
				new string[]{
					"D",
				"Vratsa",
				"Bulgaria" }
			));
		}
	}
}
