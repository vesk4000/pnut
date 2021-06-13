using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
    public static class InputReader
    {
        private const string endCommand = "quit";
        public static void StartReadingCommands()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                OutputWriter.WriteMessage($"> ");
                string input = Console.ReadLine();
                input = input.Trim();
                CommandInterpreter.InterpredCommand(input);

            }
        }
    }
}