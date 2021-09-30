using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pnut.Commands
{
	class Problem : Command
	{
		//this should be commited
		public Problem() :
			base("problem",
"Adds a new problem or modifies an existing one",
@"Problems can then be assigned to contestants so their solutions can be judged.
Note: Problems created are not saved after you exit the program.
Arguments:
<name(string)> - name of the problem
<tests_file_directory(folder_path)> - path to the text files, containing the inputs and expected outputs for every test of the problem
[[time_limit(decimal)]] - time limit for the problem in seconds (default is 100 000 seconds)
[[memory limit (int)]] - memory limit for the problem in MegaBytes (default is 256 MB)
[[input_file_extension(string)]] - file extension of all input files in the previously specified folder (default is .in)
[[output_file_extension(string)]] - file extension of all output files in the previously specified folder (default is .sol)
"
) { }

		public override void Run(string[] args)
		{
			if (args.Length > 6) {
				ConsoleExt.WriteWarning("Too many arguments!");
			}
			if (args.Length < 2) {
				ConsoleExt.WriteError("Too few arguments!");
				return;
			}

			string name = args[0];
			string tests_directory = args[1];

			if(!Directory.Exists(tests_directory)) {
				ConsoleExt.WriteError("The directory provided does not exist!");
				return;
			}

			double tl = -1;
			if (args.Length >= 3)
				if (!double.TryParse(args[2], out tl)) {
					ConsoleExt.WriteError("Time limit not valid decimal number!");
					return;
				}

			int ml = -1;
			if (args.Length >= 4)
				if (!int.TryParse(args[3], out ml)) {
					ConsoleExt.WriteError("Memory limit not a valid number!");
					return;
				}

			string inputExt = "in";
			if (args.Length >= 5) {
				inputExt = args[4];
				if(inputExt[0] == '.') {
					if (inputExt.Length == 1) {
						ConsoleExt.WriteError("Invalid file extension!");
						return;
					}
					inputExt = inputExt.Substring(1, inputExt.Length - 1);
				}	
			}

			string outputExt = "sol";
			if (args.Length == 6) {
				outputExt = args[5];
				if (outputExt[0] == '.') {
					if (outputExt.Length == 1) {
						ConsoleExt.WriteError("Invalid file extension!");
						return;
					}
					outputExt = outputExt.Substring(1, outputExt.Length - 1);
				}
			}

			lock(pnut.Judge.EntitiesLock) {
				pnut.Problem problem = new pnut.Problem(name, tests_directory, tl, ml, inputExt, outputExt);
				bool hasFound = false;
				for (int i = 0; i < pnut.Judge.Entities.Count; ++i) {
					if(pnut.Judge.Entities[i].Name == name) {
						hasFound = true;
						if(!(pnut.Judge.Entities[i] is pnut.Problem)) {
							ConsoleExt.WriteError("The name is that of a contestant, not a problem!");
							return;
						}
						pnut.Judge.Entities[i] = problem;
					}
				}
				if (!hasFound)
					pnut.Judge.Entities.Add(problem);
				
			}

			ConsoleExt.WriteSuccess("Problem " + name + " was successfully created");
		}
	}
}