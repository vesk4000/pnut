using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
    public static class CommandInterpreter
    {
        /*public static void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string command = data[0];
            switch (command)
            {
                case "quit":
                    //Data.SaveData();
                    Environment.Exit(0);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                case "problem":
                    TryGetProblem(input, data);
                    break;
                case "judge":
                    TryJudge();
                    break;
                default:
                    DisplayInvalidCommandMessage(input);
                    break;
            }

        }

        private static void TryJudge()
        {
            throw new NotImplementedException();
        }

        private static void TryGetProblem(string input, string[] data)
        {
                //TODO extract tests into tests list
                string problemName = data[1];
                string testDirectory = data[2];
                string timeLimit = data[3];
                string memoryLimit = data[4];
                var tests = new List<Test>();
                var problem = new Problem(problemName, int.Parse(memoryLimit), double.Parse(timeLimit), 100, tests);
                //Data.Problems.Add(problem);
        }

        private static void TryGetProblemHelp()
        {
            throw new NotImplementedException();
        }

        private static void TryGetHelp(string input, string[] data)
        {
            if (string.IsNullOrEmpty(data[1]))
            {
                OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
                OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
                OutputWriter.WriteEmptyLine();
            }

            else if (data[1] == "problem")
            {
                TryGetProblemHelp();
            }

            else
            {
                DisplayInvalidCommandMessage(input);
            }


        }

        private static void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command '{input}' is invalid");
        }*/
    }
}