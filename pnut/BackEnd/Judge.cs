using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
	static class Judge
	{
		public static List<Entity> Entities = new List<Entity>();
		public static readonly object EntitiesLock = new object();

		public static void Run() {
			while (true) {
				string s = Console.ReadLine();
				//Console.OutputEncoding = Encoding.Unicode;
				Console.WriteLine(s);
				//Console.WriteLine(Console.OutputEncoding);
			}
		}
	}
}
