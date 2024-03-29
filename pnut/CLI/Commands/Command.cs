﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
	public class Command
	{
		public readonly HashSet<string> Names;
		public readonly string Description;
		public readonly string ExtraDescription;
		public readonly Tuple<string, string>[] Arguments;
		public readonly string Examples;
		public readonly Argument[] Arguments1;

		public class Argument
        {
			public readonly string Name;
			public readonly Type Type;
			public readonly bool Optional;
			public readonly bool Repeatable;
			public readonly string Description;

			public Argument(string name, Type type, string description, bool optional = false, bool repeatable = false)
            {
				Name = name;
				Type = type;
				Description = description;
				Optional = optional;
				Repeatable = repeatable;
            }
        }

		public Command(string name, string desc, string extraDesc = "", Tuple<string, string>[] args = null, string examples = "") {
			Names = new HashSet<string>();
			Names.Add(name);
			Description = desc;
			ExtraDescription = extraDesc;
			if (args != null)
				Arguments = args;
			else
				Arguments = new Tuple<string, string>[0];
			Examples = examples;
		}

		public Command(string name, string desc, string extraDesc = "", Argument[] args = null, string examples = "")
		{
			Names = new HashSet<string>();
			Names.Add(name);
			Description = desc;
			ExtraDescription = extraDesc;
			if (args != null)
				Arguments1 = args;
			else
				Arguments1 = new Argument[0];
			Examples = examples;
		}

		public Command(string[] names, string desc, string extraDesc) {
			Names = new HashSet<string>(names);
			Description = desc;
			ExtraDescription = extraDesc;
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
