using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
	static class Utilities
	{
        public static bool HasNonASCIIChars(string str) {
			return System.Text.Encoding.UTF8.GetByteCount(str) != str.Length;
		}

		public static string ConvertToCRLF(string str) {
			return str.Replace("\r", "").Replace("\n", Environment.NewLine);
		}

		public static int MB2Bytes(int MegaBytes) {
			return MegaBytes * 1024 * 1024;
		}
	}
}
