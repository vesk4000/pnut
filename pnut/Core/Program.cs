using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace pnut
{
	class Program
	{
		static void Main(string[] args) {
			// Vesk's debug adventures
			// Asynchronous programming in C# is simply retarded
			// Тез не можаха по-малоумно да ги измислят
			// Да го бях правил директно с thread-ове, сиг по-лесно щеше да стане
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;
			AnsiConsole.MarkupLine("[lightseagreen]Hello World![/]");
			while(true) {
				string s = Console.ReadLine();
				if (s == "end")
					break;
				if (s == "compile") {
					Console.WriteLine("Main thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
					Task<bool> tsk = Task.Run(() => Compiler.Compile(@"C:\Users\Vesk\Desktop\Информатика\Hello World.cpp", @"C:\Users\Vesk\Desktop\Hello World.exe"));
					Console.WriteLine("Main continues");
				}
					
			}
			Console.ReadKey();
		}
	}
}
