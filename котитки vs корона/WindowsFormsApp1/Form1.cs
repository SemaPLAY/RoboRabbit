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
		PictureBox[] zmei = new PictureBox[1025];
		bool up = false, down = false, right = false, left = false;
		PictureBox yabloko = new PictureBox();
		int kolv = -1;
		Random Random = new Random();
		SoundPlayer sound = new SoundPlayer(Properties.Resources.zvuk);
		int kl = 0;
		bool test = false;
		int raz = 0;
		int scet = 0;
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
			scet = 0;
			for (int j =0;j <= kolv; j++)
			{
				zmei[j].Visible = false;
				zmei[j] = null;
				components.Remove(zmei[j]);
			}
			kolv = -1;
			up = false;
			down = false;
			right = false;
			left = false;
			timer1.Interval = 300;
			this.FormBorderStyle = FormBorderStyle.None;
			for (int i = 0; i <= 2; i++)
			{
				zmei[i] = new PictureBox();
				zmei[i].Size = new Size(40, 40);
				zmei[i].Location = new Point(40, 40 + (i * 40));
				if (i == 0)
				{
					zmei[i].BackgroundImage = Properties.Resources.head;
				}
				else
				{
					zmei[i].BackgroundImage = Properties.Resources.telo;
				}
				Controls.Add(zmei[i]);
				kolv++;
			}
			yabloko.Size = new Size(40, 40);
			yabloko.BackgroundImage = Properties.Resources.virus;
			Controls.Add(yabloko);
			int x = Random.Next(0, (Width / 40) - 1);
			int y = Random.Next(0, (Height / 40) - 1);
			yabloko.Location = new Point(x * 40, y * 40);
			timer1.Enabled = true;
			timer2.Enabled = true;
			button1.Enabled = false;
			button1.Visible = false;
			button2.Enabled = false;
			button2.Visible = false;
			pictureBox1.Visible = false;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			start();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			textBox1.Text = Convert.ToString(scet);
			int dok = kolv - 1, ot = 0;
			int g = 2;
			if (up)
			{
				zmei[kolv].Location = zmei[kolv - 1].Location;
				for (int i = kolv -1; i >= 1; i--)
				{
					zmei[i].BackgroundImage = Properties.Resources.telo;
					zmei[i].Location = zmei[i - 1].Location;
				}

				zmei[0].BackgroundImage = Properties.Resources.head;
				zmei[0].Location = new Point(zmei[0].Location.X, zmei[0].Location.Y - 40);
				for (int i = kolv - 1; i >= 1; i--)
				{
					if ((zmei[i].Location.X == zmei[i - 1].Location.X) && (zmei[i].Location.Y == zmei[i + 1].Location.Y))
					{
						if (zmei[i].Location.X == zmei[i + 1].Location.X - 40)
						{
							zmei[i].BackgroundImage = Properties.Resources.telopol;
						}
						if (zmei[i].Location.X == zmei[i + 1].Location.X + 40)
						{
							zmei[i].BackgroundImage = Properties.Resources.telopod;
						}
						ot = i + 1;
						int ks;
						Math.DivRem(g,2,out ks);
						for (int k = ot; k <= dok; k++)
						{
							if (ks == 0)
							{
								zmei[k].BackgroundImage = Properties.Resources.telor;
							}
							else
							{
								zmei[k].BackgroundImage = Properties.Resources.telo;
							}
						}
						g++;
						dok = i - 1;
					}
				}
			}
			if (down)
			{
				zmei[kolv].Location = zmei[kolv - 1].Location;
				for (int i = kolv-1; i >= 1; i--)
				{
					zmei[i].BackgroundImage = Properties.Resources.telo;
					zmei[i].Location = zmei[i - 1].Location;
				}
				zmei[0].BackgroundImage = Properties.Resources.headdown;
				zmei[0].Location = new Point(zmei[0].Location.X, zmei[0].Location.Y + 40);
				for (int i = kolv - 1; i >= 1; i--)
				{
					if ((zmei[i].Location.X == zmei[i - 1].Location.X) && (zmei[i].Location.Y == zmei[i + 1].Location.Y))
					{
						if (zmei[i].Location.X == zmei[i + 1].Location.X - 40)
						{
							zmei[i].BackgroundImage = Properties.Resources.telopor;
						}
						if (zmei[i].Location.X == zmei[i + 1].Location.X + 40)
						{
							zmei[i].BackgroundImage = Properties.Resources.telopoup;
						}
						ot = i + 1;
						int ks;
						Math.DivRem(g, 2, out ks);
						for (int k = ot; k <= dok; k++)
						{
							if (ks == 0)
							{
								zmei[k].BackgroundImage = Properties.Resources.telor;
							}
							else
							{
								zmei[k].BackgroundImage = Properties.Resources.telo;
							}
						}
						g++;
						dok = i - 1;
					}
				}
			}
			if (right)
			{
				zmei[kolv].Location = zmei[kolv - 1].Location;
				for (int i = kolv-1; i >= 1; i--)
				{
					zmei[i].BackgroundImage = Properties.Resources.telor;
					zmei[i].Location = zmei[i - 1].Location;
				}
				zmei[0].BackgroundImage = Properties.Resources.headright;
				zmei[0].Location = new Point(zmei[0].Location.X + 40, zmei[0].Location.Y);
				for (int i = kolv - 1; i >= 1; i--)
				{
					if ((zmei[i].Location.Y == zmei[i-1].Location.Y) && (zmei[i].Location.X == zmei[i + 1].Location.X))
					{
						if (zmei[i].Location.Y == zmei[i + 1].Location.Y-40)
						{
							zmei[i].BackgroundImage = Properties.Resources.telopor;
						}
						if (zmei[i].Location.Y == zmei[i + 1].Location.Y + 40)
						{
							zmei[i].BackgroundImage = Properties.Resources.telopol;
						}
						ot = i + 1;
						int ks;
						Math.DivRem(g, 2, out ks);
						for (int k = ot; k <= dok; k++)
						{
							if (ks == 0)
							{
								zmei[k].BackgroundImage = Properties.Resources.telo;
							}
							else
							{
								zmei[k].BackgroundImage = Properties.Resources.telor;
							}
						}
						g++;
						dok = i - 1;
					}

				}
			}
			if (left)
			{
				zmei[kolv].Location = zmei[kolv - 1].Location;
				for (int i = kolv-1; i >= 1; i--)
				{
					zmei[i].BackgroundImage = Properties.Resources.telor;
					zmei[i].Location = zmei[i - 1].Location;
				}
				zmei[0].BackgroundImage = Properties.Resources.headleft;
				zmei[0].Location = new Point(zmei[0].Location.X - 40, zmei[0].Location.Y);
				for (int i = kolv - 1; i >= 1; i--)
				{
					if ((zmei[i].Location.Y == zmei[i - 1].Location.Y) && (zmei[i].Location.X == zmei[i + 1].Location.X))
					{
						if (zmei[i].Location.Y == zmei[i + 1].Location.Y - 40)
						{
							zmei[i].BackgroundImage = Properties.Resources.telopoup;
						}
						if (zmei[i].Location.Y == zmei[i + 1].Location.Y + 40)
						{
							zmei[i].BackgroundImage = Properties.Resources.telopod;
						}
						ot = i + 1;
						int ks;

						Math.DivRem(g, 2, out ks);
						for (int k = ot; k <= dok; k++)
						{
							if (ks == 0)
							{
								zmei[k].BackgroundImage = Properties.Resources.telo;
							}
							else
							{
								zmei[k].BackgroundImage = Properties.Resources.telor;
							}
						}
						g++;
						dok = i - 1;
					}
				}
			}
			for (int i = 1; i <= kolv; i++)
			{
				if (zmei[0].Location == zmei[i].Location)
				{
					pictureBox1.BackgroundImage = Properties.Resources.FINALC;
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
				kolv++;
				zmei[kolv] = new PictureBox();
				zmei[kolv].Location = new Point(-40, -40);
				zmei[kolv].Size = new Size(40, 40);
				Controls.Add(zmei[kolv]);
				scet++;
				if (timer1.Interval >= 50)
				{
					timer1.Interval = timer1.Interval - 10;
				}
				if (up)
				{
					zmei[0].BackgroundImage = Properties.Resources.kotopen;
				}
				if (down)
				{
					zmei[0].BackgroundImage = Properties.Resources.kotopend;
				}
				if (right)
				{
					zmei[0].BackgroundImage = Properties.Resources.kotopenr;
				}
				if (left)
				{
					zmei[0].BackgroundImage = Properties.Resources.kotopenl;
				}
			}
			if (zmei[0].Location.X == -40)
			{
				pictureBox1.BackgroundImage = Properties.Resources.FINALC;
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
				pictureBox1.BackgroundImage = Properties.Resources.FINALC;
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
				pictureBox1.BackgroundImage = Properties.Resources.FINALC;
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
				pictureBox1.BackgroundImage = Properties.Resources.FINALC;
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
			if (zmei[kolv].Location.Y - 40 == zmei[kolv - 1].Location.Y)
				{
					zmei[kolv].BackgroundImage = Properties.Resources.xvost;
				}
			if (zmei[kolv].Location.Y + 40 == zmei[kolv - 1].Location.Y)
				{
					zmei[kolv].BackgroundImage = Properties.Resources.xvostd;
				}
			if (zmei[kolv].Location.X + 40 == zmei[kolv - 1].Location.X)
				{
					zmei[kolv].BackgroundImage = Properties.Resources.xvostr;
				}
			if (zmei[kolv].Location.X - 40 == zmei[kolv - 1].Location.X)
				{
					zmei[kolv].BackgroundImage = Properties.Resources.xvostl;
				}
		}
		public Form1()
		{
			InitializeComponent();
			pictureBox1.BackgroundImage = Properties.Resources.CATSvsVirus;
			pictureBox1.Size = new Size(this.Size.Width, this.Size.Height);
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
