using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		PictureBox[] zmei = new PictureBox[326];
		bool up = false, down = false, right = false, left = false;
		PictureBox yabloko = new PictureBox();
		int kolv = -1;
		Random Random = new Random();
		SoundPlayer sound = new SoundPlayer(Properties.Resources.zvuk);
		int kl = 0;
		bool test = false;
		int scet = 0;
		int raz = 0;
		Button rest = new Button();
		private void timer2_Tick(object sender, EventArgs e)
		{
			if ((kl < 150) && (test == false))
			{
				kl += 10;
			}
			else
			{
				kl = 0;
				test = true;
			}
		}
		public void start()
		{
			button2.Enabled = false;
			scet = 0;
			up = false;
			down = false;
			right = false;
			left = false;
			kolv = -1;
			this.FormBorderStyle = FormBorderStyle.None;
			pictureBox1.Size = new Size(this.Size.Width, this.Size.Height);
			for (int i = 0; i <= 2; i++)
			{
				zmei[i] = new PictureBox();
				zmei[i].Size = new Size(40, 40);
				zmei[i].Location = new Point(240, 240 + (i * 40));
				zmei[i].BackgroundImage = Properties.Resources.virus;
				Controls.Add(zmei[i]);
				kolv++;
			}
			yabloko.Size = new Size(40, 40);
			yabloko.BackgroundImage = Properties.Resources.kot;
			Controls.Add(yabloko);
			int x = Random.Next(0, (Width / 40) - 1);
			int y = Random.Next(0, (Height / 40) - 1);
			yabloko.Location = new Point(x * 40, y * 40);
			timer1.Enabled = true;
			timer2.Enabled = true;
			button1.Enabled = false;
			button1.Visible = false;
			pictureBox1.Visible = false;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			for (int j = 0; j <= kolv; j++)
			{
				zmei[j].Visible = false;
				zmei[j] = null;
				components.Remove(zmei[j]);
			}
			start();
			textBox1.Visible = true;
			textBox1.Text = Convert.ToString(scet);
			button1.Visible = false;
			timer1.Interval = 300;
			button2.Visible = false; 
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (scet == 30)
			{
				this.Size = new Size(560,300);
				pictureBox1.BackgroundImage = Properties.Resources.CATSvsVirusTOP2;
				pictureBox1.Visible = true;
			}
			textBox1.Text = Convert.ToString(scet);
			if (up)
			{
				zmei[kolv].Location = zmei[kolv - 1].Location;
				for (int i = kolv -1; i >= 1; i--)
				{
					zmei[i].BackgroundImage = Properties.Resources.virus;
					zmei[i].Location = zmei[i - 1].Location;
				}
				zmei[0].BackgroundImage = Properties.Resources.virusface;
				zmei[0].Location = new Point(zmei[0].Location.X, zmei[0].Location.Y - 40);
			}
			if (down)
			{
				zmei[kolv].Location = zmei[kolv - 1].Location;
				for (int i = kolv-1; i >= 1; i--)
				{
					zmei[i].Location = zmei[i - 1].Location;
				}
				zmei[0].BackgroundImage = Properties.Resources.virusfaced;
				zmei[0].Location = new Point(zmei[0].Location.X, zmei[0].Location.Y + 40);
			}
			if (right)
			{
				zmei[kolv].Location = zmei[kolv - 1].Location;
				for (int i = kolv-1; i >= 1; i--)
				{
					zmei[i].Location = zmei[i - 1].Location;
				}
				zmei[0].BackgroundImage = Properties.Resources.virusfacer;
				zmei[0].Location = new Point(zmei[0].Location.X + 40, zmei[0].Location.Y);
			}
			if (left)
			{
				zmei[kolv].Location = zmei[kolv - 1].Location;
				for (int i = kolv-1; i >= 1; i--)
				{
					zmei[i].Location = zmei[i - 1].Location;
				}
				zmei[0].BackgroundImage = Properties.Resources.virusfacel;
				zmei[0].Location = new Point(zmei[0].Location.X - 40, zmei[0].Location.Y);
			}
			for (int i = 1; i <= kolv; i++)
			{
				if (zmei[0].Location == zmei[i].Location)
				{
					pictureBox1.BackgroundImage = Properties.Resources.lose;
					pictureBox1.Visible = true;
					button2.Enabled = true;
					button2.Visible = true;
					button1.Visible = true;
					button1.Text = "новая игра";
					button1.Enabled = true;
					raz++;
					timer1.Stop();
					timer1.Stop();
				}
			}
			if (zmei[0].Location == yabloko.Location)
			{

			h:
				int x = Random.Next(0, (Width / 40)-1);
				int y = Random.Next(0, (Height / 40)-1);
				yabloko.Location = new Point(x * 40, y * 40);
				for (int i = 0; i <= kolv; i++)
				{
						if (yabloko.Location == zmei[i].Location)
						{
							goto h;
						}
				}
				sound.Play();
				if (left) 
				{
					zmei[0].BackgroundImage = Properties.Resources.virusfaceopenl;
				}
				if (right) 
				{
					zmei[0].BackgroundImage = Properties.Resources.virusfaceopenr;
				}
				if (up)
				{
					zmei[0].BackgroundImage = Properties.Resources.virusfaceopen;
				}
				if (down)
				{
					zmei[0].BackgroundImage = Properties.Resources.virusfaceopend;
				}

				kolv++;
				zmei[kolv] = new PictureBox();
				zmei[kolv].Location = new Point(-40, -40);
				zmei[kolv].Size = new Size(40, 40);
				Controls.Add(zmei[kolv]);
				scet++;
				zmei[kolv].BackgroundImage = Properties.Resources.virus;
				if (timer1.Interval > 50)
				{
					timer1.Interval = timer1.Interval - 10;
				}
			}
			if (zmei[0].Location.X == -40)
			{
				pictureBox1.BackgroundImage = Properties.Resources.lose;
				pictureBox1.Visible = true;
				button2.Enabled = true;
				button2.Visible = true;
				button1.Visible = true;
				button1.Text = "новая игра";
				button1.Enabled = true;
				raz++;
				timer1.Stop();
				timer1.Stop();
			}
			if (zmei[0].Location.Y == -40)
			{
				pictureBox1.BackgroundImage = Properties.Resources.lose;
				pictureBox1.Visible = true;
				button2.Enabled = true;
				button2.Visible = true;
				button1.Visible = true;
				button1.Text = "новая игра";
				button1.Enabled = true;
				raz++;
				timer1.Stop();
				timer1.Stop();

			}
			if (zmei[0].Location.X >= this.Width)
			{
				pictureBox1.BackgroundImage = Properties.Resources.lose;
				pictureBox1.Visible = true;
				button2.Enabled = true;
				button2.Visible = true;
				button1.Visible = true;
				button1.Text = "новая игра";
				button1.Enabled = true;
				raz++;
				timer1.Stop();
				timer1.Stop();
			}
			if (zmei[0].Location.Y >= this.Height)
			{
				pictureBox1.BackgroundImage = Properties.Resources.lose;
				pictureBox1.Visible = true;
				button2.Enabled = true;
				button2.Visible = true;
				button1.Visible = true;
				button1.Text = "новая игра";
				button1.Enabled = true;
				raz++;
				timer1.Stop();
				timer1.Stop();
			}
		}
		public Form1()
		{
			InitializeComponent();
			textBox1.Visible = false;
			textBox1.Enabled = false;
			pictureBox1.BackgroundImage = Properties.Resources.CATSvsVirus;
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (test) {
			if (down == false)
			{
				if (e.KeyCode == Keys.W)
				{
					up = true;
					down = false;
					right = false;
					left = false;
					test = false;
				}
			}
			if (up == false)
			{
				if (e.KeyCode == Keys.S)
				{
					down = true;
					up = false;
					right = false;
					left = false;
					test = false;
				}
			}
			if (right == false)
			{
				if (e.KeyCode == Keys.A)
				{
					left = true;
					down = false;
					up = false;
					right = false;
					test = false;
				}
			}
				if (left == false)
				{
					if (e.KeyCode == Keys.D)
					{
						right = true;
						left = false;
						down = false;
						up = false;
						test = false;
					}
				}
			}
		}
	}
}
