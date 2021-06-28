//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace pnut.Commands
//{
//	public class Monitor : Command
//	{
//		public bool isInMonitor = false;
//		private bool endMonitor = false;
//		private static List<pnut.Contestant> tempContestants;

//		public Monitor() :
//			base("monitor",
//			"Continuously displays and updates the status of the judge",
//			@"Notes:
//The user will not be able to write any commands while in monitor mode
//Pressing enter will return the user to the standard console") {

//		}

//		public override void Run(string[] args) {

//			Console.CursorVisible = false;
//			isInMonitor = true;
//			UpdateConsole();
//			Console.ReadLine();
//			endMonitor = true;
//			Console.CursorVisible = true;
//			endMonitor = false;
//			isInMonitor = false;
//		}

//		public void UpdateConsole() {
//			/*while (!endMonitor) {*/
//				Console.Clear();
//				Console.SetCursorPosition(0, 0);
//				Console.WriteLine($"|     Contestant     |    Problem    | Points | Status |      Progress      |");
//				lock(pnut.Judge.Assignments) {
//					lock(pnut.Judge.Entities) {
//						foreach (var entity in pnut.Judge.Entities) {
//							if(!(entity is pnut.Contestant)) {
//								continue;
//							}
//							pnut.Contestant contestant = entity as pnut.Contestant;
//							Console.Write($"|{contestant.Name,-20}|");
//							foreach (var assignment in contestant.GetAssignments()) {
//								if (Console.CursorLeft >= 20)
//									Console.Write($"{assignment.Problem.Name,-15}|{assignment.GetPoints(),-8}|{assignment.GetStatus() + "%",-8}|");
//								else
//									Console.Write($"{' ',20}|{assignment.Problem.Name,-15}|{assignment.GetPoints(),-8}|{assignment.GetStatus() + "%",-8}|");

//								assignment.PrintProgressBar();
//							}
//							Console.WriteLine(new string('-', 85));
//						}
//						Thread.Sleep(200);
//					}
//				}
//			//}
//		}
//	}
//}

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
        private bool endMonitor = false;
        private static List<pnut.Contestant> tempContestants;
        //TODO
        public Monitor() :
            base("monitor",
            "Continuously displays and updates the status of the judge",
            @"Notes:
The user will not be able to write any commands while in monitor mode
Pressing enter will return the user to the standard console")

        {

        }

        public override void Run(string[] args)
        {
            InitializeTempData();
            int index = 0;
            Console.CursorVisible = false;
            var task = Task.Run(() => UpdateConsole());
            Console.ReadLine();
            endMonitor = true;
            task.Wait();
            Console.CursorVisible = true;
            endMonitor = false;
        }

        public void UpdateConsole()
        {
            Console.Clear();
            while (!endMonitor)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"|     Contestant     |    Problem    | Points | Status |      Progress      |");
                lock (pnut.Judge.Assignments)
                {
                    lock (pnut.Judge.Entities)
                    {
                        foreach (var entity in pnut.Judge.Entities)
                        {
                            if (!(entity is pnut.Contestant))
                            {
                                continue;
                            }

                            pnut.Contestant contestant = entity as pnut.Contestant;
                            Console.Write($"|{contestant.Name,-20}|");
                            foreach (var assignment in contestant.GetAssignments())
                            {
                                if (Console.CursorLeft >= 20)
                                    Console.Write(
                                        $"{assignment.Problem.Name,-15}|{assignment.GetPoints(),-8}|{assignment.GetStatus() + "%",-8}|");
                                else
                                    Console.Write(
                                        $"{' ',21}|{assignment.Problem.Name,-15}|{assignment.GetPoints(),-8}|{assignment.GetStatus() + "%",-8}|");

                                assignment.PrintProgressBar();
                            }

                            Console.WriteLine(new string('-', 85));
                        }

                        Thread.Sleep(200);
                    }
                }
            }
        }

        private void InitializeTempData()
        {
            tempContestants = new List<pnut.Contestant>();
            tempContestants.Add(new pnut.Contestant(
                "John Doe",
                "rndDirectory"
            ));
            tempContestants.Add(new pnut.Contestant(
                "John Doen",
                "rndDirectory"
            ));
            tempContestants.Add(new pnut.Contestant(
                "Jane Doe",
                "rndDirectory"
            ));
        }
    }
}
