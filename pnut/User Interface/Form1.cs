using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace pnut
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Compiler.Compile(@"C:\Vesk\Informatics\test.cpp");
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void Browse_Click(object sender, EventArgs e)
		{
			
		}

		private void button_browse_folder_tests_Click(object sender, EventArgs e)
		{
			browse_folder(textbox_folder_tests);
		}

		private void browse(string filter, TextBox textbox) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = filter;
			if (ofd.ShowDialog() == DialogResult.OK)
				textbox.Text = ofd.FileName;
		}

		private void browse_folder(TextBox textbox) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.ValidateNames = false;
			ofd.CheckFileExists = false;
			ofd.CheckPathExists = true;
			ofd.FileName = "Folder Selection";
			if (ofd.ShowDialog() == DialogResult.OK)
				textbox.Text = ofd.FileName.Substring(0, ofd.FileName.LastIndexOf(@"\"));
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Global.problems.Add(new Problem(textbox_new_problem_name.Text, textbox_folder_tests.Text));
		}
	}
}
