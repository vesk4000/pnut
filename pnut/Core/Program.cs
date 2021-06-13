using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using System.Xml.Linq;

namespace pnut
{
	class Program
	{
		static void FormerMain(string[] args) {
			// Vesk's debug adventures
			// Asynchronous programming in C# is simply retarded
			// Тез не можаха по-малоумно да ги измислят
			// Да го бях правил директно с thread-ове, сиг по-лесно щеше да стане
			
			/*Settings.GppPath = @"C:\MinGW\bin\g++.exe";
			Console.WriteLine(Settings.GppPath);
			/*XDocument xdoc = new XDocument();
			/*xdoc.Add(new XElement("key", "value"));
			xdoc.Save(@"C:\Users\Vesk\Desktop\xdoc.xml");*/
			/*xdoc = XDocument.Load(@"C:\Users\Vesk\Desktop\xdoc.xml");
			Console.WriteLine(((XElement)xdoc.Root.Descendants().Where(s => s.Name == "key").ToArray()[0]).Value);
			/*AnsiConsole.MarkupLine("[lightseagreen]Hello World![/]");
			while(true) {
				string s = Console.ReadLine();
				if (s == "end")
					break;
				if (s == "compile") {
					//Console.WriteLine("Main thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
					Task.Run(() => Compiler.Compile(@"C:\Users\Vesk\Desktop\Информатика\Hello World.cpp", @"C:\Users\Vesk\Desktop\Hello World.exe"));
					Console.WriteLine("Main continues");
				}
					
			}
			/*
			string z = Console.ReadLine();
			Console.WriteLine(Utilities.HasNonASCIIChars(z));
			*/
		}
	}
}
