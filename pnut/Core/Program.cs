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
		static void Main(string[] args)
		{
		    Settings.GppPath = @"C:\MinGW\bin\g++.exe";
            CommandLineInterface.RunMainLoop();

            //contestant dragan_cankov "C:\Users\ETO 1302\Desktop\pn\Tests\dragan_cankov" tag
            //contestant go6o "C:\Users\ETO 1302\Desktop\pn\Tests\go6o" tag
            //contestant pepo "C:\Users\ETO 1302\Desktop\pn\Tests\pepo" tag
            //problem CoutN "C:\Users\ETO 1302\Desktop\pn\Tests\CoutN"
            //problem CoutN2 "C:\Users\ETO 1302\Desktop\pn\Tests\CoutN2"
            //assign CoutN go6o
            //assign CoutN dragan_cankov
            //assign CoutN2 dragan_cankov
            //assign CoutN2 go6o
            //assign CoutN pepo
            //judge
            //monitor
        }
    }
}
