
namespace pnut
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textbox_gpp_location = new System.Windows.Forms.TextBox();
			this.Browse = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textbox_new_problem_name = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textbox_folder_tests = new System.Windows.Forms.TextBox();
			this.button_browse_folder_tests = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(90, 26);
			this.button1.TabIndex = 0;
			this.button1.Text = "Compile";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(420, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(155, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Settings (Not Working):";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(423, 47);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(174, 21);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "I have g++ in my PATH";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(420, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Location of g++ exe:";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// textbox_gpp_location
			// 
			this.textbox_gpp_location.Location = new System.Drawing.Point(563, 82);
			this.textbox_gpp_location.Name = "textbox_gpp_location";
			this.textbox_gpp_location.Size = new System.Drawing.Size(399, 22);
			this.textbox_gpp_location.TabIndex = 4;
			// 
			// Browse
			// 
			this.Browse.Location = new System.Drawing.Point(969, 72);
			this.Browse.Name = "Browse";
			this.Browse.Size = new System.Drawing.Size(115, 32);
			this.Browse.TabIndex = 5;
			this.Browse.Text = "button2";
			this.Browse.UseVisualStyleBackColor = true;
			this.Browse.Click += new System.EventHandler(this.Browse_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(421, 178);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(139, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Create new Problem:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(420, 204);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "Name:";
			// 
			// textbox_new_problem_name
			// 
			this.textbox_new_problem_name.Location = new System.Drawing.Point(476, 204);
			this.textbox_new_problem_name.Name = "textbox_new_problem_name";
			this.textbox_new_problem_name.Size = new System.Drawing.Size(174, 22);
			this.textbox_new_problem_name.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(423, 238);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(114, 17);
			this.label5.TabIndex = 9;
			this.label5.Text = "Folder with tests:";
			// 
			// textbox_folder_tests
			// 
			this.textbox_folder_tests.Location = new System.Drawing.Point(544, 232);
			this.textbox_folder_tests.Name = "textbox_folder_tests";
			this.textbox_folder_tests.Size = new System.Drawing.Size(418, 22);
			this.textbox_folder_tests.TabIndex = 10;
			// 
			// button_browse_folder_tests
			// 
			this.button_browse_folder_tests.Location = new System.Drawing.Point(969, 232);
			this.button_browse_folder_tests.Name = "button_browse_folder_tests";
			this.button_browse_folder_tests.Size = new System.Drawing.Size(75, 23);
			this.button_browse_folder_tests.TabIndex = 11;
			this.button_browse_folder_tests.Text = "Browse";
			this.button_browse_folder_tests.UseVisualStyleBackColor = true;
			this.button_browse_folder_tests.Click += new System.EventHandler(this.button_browse_folder_tests_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(423, 272);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(114, 27);
			this.button2.TabIndex = 12;
			this.button2.Text = "Create Problem";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1096, 567);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button_browse_folder_tests);
			this.Controls.Add(this.textbox_folder_tests);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textbox_new_problem_name);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Browse);
			this.Controls.Add(this.textbox_gpp_location);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textbox_gpp_location;
		private System.Windows.Forms.Button Browse;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textbox_new_problem_name;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textbox_folder_tests;
		private System.Windows.Forms.Button button_browse_folder_tests;
		private System.Windows.Forms.Button button2;
	}
}

