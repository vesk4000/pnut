using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut.Commands
{
    class Delete : Command
    {
        public Delete() :
            base("delete",
            "Deletes an existing problem or contestant",
            @"Arguments:
<name (string)> - name of the problem/contestant") { }

        public override void Run(string[] args) {
            HashSet<string> wrongNames = new HashSet<string>();
            List<string> deletedNames = new List<string>();

            for (int i = 0; i < args.Length; i++)
                wrongNames.Add(args[i]);

            lock (pnut.Judge.EntitiesLock)
                for (int i = 0; i < pnut.Judge.Entities.Count; ++i) {
                    if (wrongNames.Remove(pnut.Judge.Entities[i].Name)) {
                        deletedNames.Add(pnut.Judge.Entities[i].Name);
                        pnut.Judge.Entities.RemoveAt(i);
                        i--;
                    }
                }

            foreach (string wrongName in wrongNames)
                ConsoleExt.WriteWarning(string.Format("{0} is not a valid contestant / problem name!", wrongName));

            if (deletedNames.Count != 0) ConsoleExt.WriteSuccess(string.Format("Deleted problems / contestants: {0}", string.Join(", ", deletedNames)));

        }
    }
}