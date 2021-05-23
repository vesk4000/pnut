using System;
using System.Collections.Generic;
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
	}
}
