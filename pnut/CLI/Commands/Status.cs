using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pnut.Commands
{
    public class Status : Command
    {
        private static List<pnut.Contestant> tempContestants;
        //TODO
        public Status() : base("status", "needsDescr", "needsExtDescr")
        {

        }

        public override void Run(string[] args)
        {
            InitializeTempData();
            Console.WriteLine($"|     Contestant     | Group |    Problem    | Points | Status |      Progress      |");
            foreach (var contestant in tempContestants)
            {
                Console.Write($"|{contestant.Name,-20}|{contestant.Group,-7}|");
                foreach (var assignment in contestant.GetAssignments())
                {
                    if (Console.CursorLeft >= 25) Console.Write($"{assignment.Problem.Name,-15}|{assignment.GetPoints(),-8}|{assignment.GetStatus(),-8}|");
                    else Console.Write($"{' ',29}|{assignment.Problem.Name,-15}|{assignment.GetPoints(),-8}|{assignment.GetStatus(),-8}|");

                    assignment.PrintProgressBar();
                }

                Console.WriteLine(new string('-', 85));
            }
        }

        private void InitializeTempData()
        {
            tempContestants = new List<pnut.Contestant>();
            tempContestants.Add(new pnut.Contestant(
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
            ));
            tempContestants.Add(new pnut.Contestant(
                "Jane Doe",
                'D',
                "rndDirectory",
                "Vratsa",
                "Bulgaria"
            ));
        }
    }
}
