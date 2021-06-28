using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using Spectre.Console;

namespace pnut
{
	static class Settings
	{
		static string xPath; // the path to the settings file
		static XDocument xDoc; // the settings file
	    public static string GppPath = @"C:\MinGW\bin";

        /*public static string GppPath {
			get {
				return xGet("GppPath");
			}
			set {
				if(!File.Exists(value) || Path.GetFileName(value) != "g++.exe")
					AnsiConsole.MarkupLine("[red]Invalid G++ compiler path.[/]");
				else
					xSet("GppPath", value);
			}
		}*/

        static Settings() {
			string[] paths = new string[] {
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\pnut\Settings.xml",
				Directory.GetCurrentDirectory() + @"\Settings.xml"
			};
			foreach(string path in paths)
				if(File.Exists(path)) {
					xPath = path;
					break;
				}
			if(xPath == null)
				xPath = paths[0];
			if(!File.Exists(xPath) || (xDoc = XDocument.Load(xPath)).Root.Name != "Settings") {
				xDoc = new XDocument(
					new XElement("Settings")
				);
				Directory.CreateDirectory(Path.GetDirectoryName(xPath));
				xDoc.Save(xPath);
			}
		}

		static string xGet(string key) {
			XElement[] elements = (XElement[])xDoc.Root.Descendants().Where(x => x.Name == key).ToArray();
			if (elements.Length == 0)
				return null;
			return elements[0].Value; // You shouldn't have more than one value with the same key, so...
		}

		static void xSet(string key, string value) {
			XElement[] elements = (XElement[])xDoc.Root.Descendants().Where(x => x.Name == key).ToArray();
			if (elements.Length == 0)
				xDoc.Root.Add(new XElement(key, value));
			else
				elements[0].Value = value;
			xDoc.Save(xPath);
		}
	}
}
