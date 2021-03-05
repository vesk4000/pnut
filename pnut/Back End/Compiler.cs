using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace pnut
{
	class Compiler
	{
		// To Do: Everything...
		public static void Compile(string source_path, string gpp_path)
		{
			if (!File.Exists(source_path)) {
				Debug.WriteLine("Source file does not exist. Aborting compilation.");
				return;
			}

            if (!File.Exists(gpp_path))
            {
                Debug.WriteLine("G++ path is not correct. Aborting compilation.");
                return;
            }

            string exe_path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\Compiled.exe";
			if (File.Exists(exe_path))
				File.Delete(exe_path);

			Process cmd = new Process();
			cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.UseShellExecute = false; // Some shit the program needs to work

            // Hide the cmd window
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            // Redirect the input to write commands
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;

            // Start the program
            cmd.Start();

            //Change to the drive where g++ is
            string t;
            t = gpp_path.Substring(0, 2);
            t.ToLower();
            cmd.StandardInput.WriteLine(t);

            //Go to where g++ is
            gpp_path = gpp_path.Replace("\\g++.exe", "");
            cmd.StandardInput.WriteLine("cd " + gpp_path);

            //Compile
            cmd.StandardInput.WriteLine("g++ " + "\"" + source_path + "\"" + " -o " + "\"" + exe_path + "\"" + " -static-libgcc -static-libstdc++");

            Debug.WriteLine("Compiling...");

            //Close the cmd
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();

            Debug.WriteLine("Compiled");
        }
	}
}
