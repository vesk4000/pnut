using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pnut
{
	class Test
	{
		public FileInfo input;
		public FileInfo output;

		public Test(FileInfo input, FileInfo output) {
			this.input = input;
			this.output = output;
		}
	}
}
