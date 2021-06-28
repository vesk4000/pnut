using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace pnut
{
	static class ConsoleExt
	{
		public static readonly string GreenAccent = "springgreen1";
		public static readonly string GreyAccent = "grey58";
		public static readonly string PnutPromt = $"[bold {GreenAccent}]pnut> [/]";
		public static readonly string CommentPrefix = $"[{GreyAccent}]// ";

		public static void WriteError(string s) {
			AnsiConsole.MarkupLine("[red]Error: [/]" + s);
			Console.WriteLine();
		}

		public static void WriteWarning(string s) {
			AnsiConsole.MarkupLine("[yellow]Warning: [/]" + s);
		}

		public static void WriteSuccess(string s) {
			AnsiConsole.MarkupLine("[green]Success: [/]" + s);
			Console.WriteLine();
		}

		public static void WriteGradientHeader(string s) {
			AnsiConsole.MarkupLine("[invert]" + s + "[/][invert grey78] [/][invert grey74] [/][invert grey70] [/][invert grey66] [/][invert grey62] [/][invert grey58] [/][invert grey54] [/][invert grey50] [/][invert grey46] [/][invert grey42] [/][invert grey39] [/][invert grey35] [/][invert grey30] [/][invert grey27] [/][invert grey23] [/][invert grey19] [/][invert grey15] [/][invert grey11] [/][invert grey7] [/]");
		}

		public static void WriteTupleTable(Tuple<string, string>[] args) {
			Table table = new Table();
			table.AddColumns(" ", $"[bold {ConsoleExt.GreenAccent}]" + args[0].Item1 + "[/]",
				"- " + args[0].Item2);
			for (int i = 1; i < args.Length; ++i) {
				table.AddRow(" ", $"[bold {ConsoleExt.GreenAccent}]" + args[i].Item1 + "[/]",
				"- " + args[i].Item2);
			}
			table.Border(TableBorder.None);
			AnsiConsole.Render(table);
		}

		public static string ReadHintedLine<T, TResult>(IEnumerable<T> hintSource, Func<T, TResult> hintField, string inputRegex = ".*", ConsoleColor hintColor = ConsoleColor.DarkGray) {
			ConsoleKeyInfo input;

			var suggestion = string.Empty;
			var userInput = string.Empty;
			var readLine = string.Empty;

			while (ConsoleKey.Enter != (input = Console.ReadKey()).Key) {
				if (input.Key == ConsoleKey.Backspace)
					userInput = userInput.Any() ? userInput.Remove(userInput.Length - 1, 1) : string.Empty;

				else if (input.Key == ConsoleKey.Tab)
					userInput = suggestion ?? userInput;

				else if (input != null && Regex.IsMatch(input.KeyChar.ToString(), inputRegex))
					userInput += input.KeyChar;

				suggestion = hintSource.Select(item => hintField(item).ToString())
					.FirstOrDefault(item => item.Length > userInput.Length && item.Substring(0, userInput.Length) == userInput);

				readLine = suggestion == null ? userInput : suggestion;

				ClearCurrentConsoleLine(6);

				Console.Write(userInput);
				Tuple<int, int> pos = GetPosition();

				var originalColor = Console.ForegroundColor;

				Console.ForegroundColor = hintColor;

				if (userInput.Any()) Console.Write(readLine.Substring(userInput.Length, readLine.Length - userInput.Length));

				Console.ForegroundColor = originalColor;

				SetPosition(pos);
			}

			//Console.WriteLine(readLine);
			Console.WriteLine();
			return userInput.Any() ? readLine : string.Empty;
		}

		private static void ClearCurrentConsoleLine(int leftPos) {
			int currentLineCursor = Console.CursorTop;
			Console.SetCursorPosition(leftPos, Console.CursorTop);
			Console.Write(new string(' ', Console.WindowWidth - leftPos));
			Console.SetCursorPosition(leftPos, currentLineCursor);
		}

		public static Tuple<int, int> GetPosition() {
			return new Tuple<int, int>(Console.CursorLeft, Console.CursorTop);
		}

		public static void SetPosition(Tuple<int, int> pos) {
			Console.CursorLeft = pos.Item1;
			Console.CursorTop = pos.Item2;
		}

		public static void SetPosition(int x, int y) {
			SetPosition(new Tuple<int, int>(x, y));
		}
	}
}
