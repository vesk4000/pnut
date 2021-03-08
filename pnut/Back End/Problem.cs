using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pnut
{
	class Problem
	{
		public string name;
		public List<Test> tests;

		public Problem(string name, string test_folder_path) {
			this.name = name;

			if (!Directory.Exists(test_folder_path))
				throw new Exception("This folder doesn't exist");

			List<string> TestNames = new List<string>();
			DirectoryInfo test_folder = new DirectoryInfo(test_folder_path);
			FileInfo[] input_files_in_test_folder = test_folder.GetFiles("*.in");
			tests = new List<Test>();

			foreach (FileInfo input_file in input_files_in_test_folder) {
				string output_file_path = test_folder_path + @"\" + input_file.Name.Replace(".in", ".sol");
				if (File.Exists(output_file_path)) {
					FileInfo output_file = new FileInfo(output_file_path);
					tests.Add(new Test(input_file, output_file));
				}
			}
		}
	}
}
