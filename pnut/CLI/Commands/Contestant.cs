using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pnut.Commands
{
	class Contestant : Command
	{
		/*public Contestant() :
			base("contestant",
"Adds a new contestant or modifies an existing one",
@"Contestants can then be assigned problems so their solutions can be judged.
Note: Created contestants are not saved after you exit the program.",
new Tuple<string, string>[] {
	new Tuple<string, string>("<name(string)>", "name of the contestant"),
	new Tuple<string, string>("<sources_directory(folder_path)>", "path to the directory with the contestant's solutions"),
	new Tuple<string, string>("{tag(string)}", "any other tags like group, country, city, etc."),
},
$@"{ConsoleExt.CommentPrefix}This creates a contestant John, with a source directory and his tags are B, Varna and Bulgaria[/]
{ConsoleExt.PnutPromt}contestant John ""C:/John's solutions"" B Varna Bulgaria

{ConsoleExt.PnutPromt}contestant Tom C:/Users/Tom/Desktop

{ConsoleExt.PnutPromt}contestant Ben D:/Solutions/Ben ""Anything can be a tag"" You can set as many tags as you want, this line has 14"
) { }*/

		public Contestant() : base(
"contestant",
"Add a new contestant or modify an existing one",
@"Contestants can then be assigned problems so their solutions can be judged.
Note: Created contestants are not saved after you exit the program.",
new Argument[] {
	new Argument("name", typeof(string), "name of the contestant"),
	new Argument("sources-directory", typeof(DirectoryInfo), "path to the directory with the contestant's solutions"),
	new Argument("tag", typeof(string), "any tags like group, country, city, etc.")
},
$@"{ConsoleExt.CommentPrefix}This creates a contestant John, with a source directory and his tags are B, Varna and Bulgaria[/]
{ConsoleExt.PnutPromt}contestant John ""C:/John's solutions"" B Varna Bulgaria

{ConsoleExt.PnutPromt}contestant Tom C:/Users/Tom/Desktop

{ConsoleExt.PnutPromt}contestant Ben D:/Solutions/Ben ""Anything can be a tag"" You can set as many tags as you want, this line has 14"
		) { }

		public override void Run(string[] args) {
			if (args.Length == 0) {
				ConsoleExt.WriteError("No contestant name provided");
				return;
			}
			string name = args[0];

			if (args.Length == 1) {
				ConsoleExt.WriteError("No directory with the source files of the contestant provided");
				return;
			}
			string sourceDirectory = args[1];

			if (!Directory.Exists(sourceDirectory)) {
				ConsoleExt.WriteError("Directory provided does not exist");
				return;
			}

			string[] tags = new string[args.Length - 2];
			for (int i = 2; i < args.Length; ++i)
				tags[i - 2] = args[i];

			pnut.Contestant contestant = new pnut.Contestant(name, sourceDirectory, tags);

			if(Data.Entities.ContainsKey(name)) {
				if(!(Data.Entities[name] is pnut.Contestant)) {
					ConsoleExt.WriteError("The name provided exists already, but it is not that of a contestant");
					return;
				}
				else
					ConsoleExt.WriteSuccess("Modified contestant");
			}
			else
				ConsoleExt.WriteSuccess("Added contestant");
			Data.Entities[name] = contestant;
		}
	}
}
