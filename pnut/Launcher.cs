using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pnut;


namespace pnut
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Data.InitializeData();
            InputReader.StartReadingCommands();
        }
    }
}
