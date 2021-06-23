using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
    class Command
    {
        public readonly HashSet<string> Names;
        public readonly string Description;
        public readonly string ExtraDescription;

        public Command(string[] names, string desc, string extra_desc) {
            Names = new HashSet<string>(names);
            Description = desc;
            ExtraDescription = extra_desc;
        }

        public Command(string name, string desc, string extra_desc) {
            Names = new HashSet<string>();
            Names.Add(name);
            Description = desc;
            ExtraDescription = extra_desc;
        }

        public virtual void Run(string[] args) { }
    }
}
