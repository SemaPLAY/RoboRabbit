using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		string path = "";
		public Form1()
		{
			InitializeComponent();
			panel1.BackColor = Color.Black;
			pictureBox1.BackColor = Color.FromArgb(255, 70, 70, 70);
			pictureBox2.BackColor = Color.Black;
			pictureBox3.BackgroundImage = Properties.Resources.CATSvsVirusleft;
			pictureBox6.BackColor = Color.FromArgb(255, 70, 70, 70);
			pictureBox5.BackColor = Color.Black;
			pictureBox4.BackgroundImage = Properties.Resources.CATSvsVirusleft;
			textBox1.BackColor = Color.FromArgb(255, 70, 70, 70);
			textBox2.BackColor = Color.FromArgb(255, 70, 70, 70);
			textBox3.BackColor = Color.FromArgb(255, 70, 70, 70);
			pictureBox9.BackColor = Color.FromArgb(255, 70, 70, 70);
			pictureBox8.BackColor = Color.Black;
			pictureBox7.BackgroundImage = Properties.Resources.CATSvsVirusleft;
			panel2.BackColor = Color.FromArgb(255, 70, 70, 70);
			panel2.Visible = false;

		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			panel2.Visible = true;
			path = @".\vs\cat.exe";
			button2.Visible = true;
			button1.Text = "играть за котика";
			pictureBox11.BackgroundImage = Properties.Resources.CATSvsVirusTOP;
			textBox4.Text = "Котики с дрвених времён защищали этот мир от вирусов. Все предыдущие атаки котики отбивали без с труда, но сейчас другой день.Котики из последних сил защищают наш мир от коронавируса . помоги им ,или примкнёшь к тёмной стороне?";
		}

		private void textBox1_Click(object sender, EventArgs e)
		{
			panel2.Visible = true;
			button2.Visible = true;
			path = @".\vs\cat.exe";
			pictureBox11.BackgroundImage = Properties.Resources.CATSvsVirusTOP;
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			panel2.Visible = true;
			button2.Visible = false;
			button1.Text = "играть";
		}

		private void textBox2_Click(object sender, EventArgs e)
		{
			panel2.Visible = true;
			button2.Visible = false;
			button1.Text = "играть";

		}

		private void pictureBox7_Click(object sender, EventArgs e)
		{
			panel2.Visible = true;
			button2.Visible = false;
			button1.Text = "играть";
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			if (button1.Text == "играть за котика")
			{
				System.Diagnostics.Process.Start(@".\vs\cat.exe");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(@".\vs\virus vs cat.exe");
		}

		private void textBox3_Click(object sender, EventArgs e)
		{
			panel2.Visible = true;
			button2.Visible = false;
			button1.Text = "играть";
		}
	}
}
