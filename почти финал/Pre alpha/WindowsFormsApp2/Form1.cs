using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
	public partial class Form1 : Form
	{
		public static System.Drawing.Drawing2D.GraphicsPath BuildTransparencyPath(Image im)
		{
			int x;
			int y;
			Bitmap bmp = new Bitmap(im);
			System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
			Color mask = bmp.GetPixel(0, 0);

			for (x = 0; x <= bmp.Width - 1; x++)
			{
				for (y = 0; y <= bmp.Height - 1; y++)
				{
					if (!bmp.GetPixel(x, y).Equals(mask))
					{
						gp.AddRectangle(new Rectangle(x, y, 1, 1));
					}
				}
			}
			bmp.Dispose();
			return gp;
		}
		int money = 200;
		PictureBox box = new PictureBox();
		bool c = false;			
		PictureBox[,] pictureBox = new PictureBox[4,10];
		PictureBox[] eat = new PictureBox[4];
		static PictureBox[] cats = new PictureBox[40];
		static PictureBox[] vrag = new PictureBox[40];
		int cshet = 0;
		int mon = 0;


		int prox = 0;
		int kr = 5;
		PictureBox[] bull = new PictureBox[140];
		Timer j = new Timer();
		Timer k = new Timer();
		public Form1()
		{
			InitializeComponent();
			pictureBox4.BackgroundImage = Properties.Resources.CATSvsVirusTOP2;
		}

		public void pos(object sender, EventArgs e)
		{
			if ((c) && (money >= mon))
			{
				System.Drawing.Drawing2D.GraphicsPath gp = BuildTransparencyPath(box.BackgroundImage);
				money -= mon;
				mon = 0;
				textBox1.Text = Convert.ToString(money);
				cats[cshet] = new PictureBox();
				cats[cshet].BackgroundImage = box.BackgroundImage;
				PictureBox picture = sender as PictureBox;
				cats[cshet].Location = picture.Location;
				cats[cshet].Size = new Size(100, 95);
				cats[cshet].Region = new Region(gp);
				Controls.Add(cats[cshet]);
				cats[cshet].BringToFront();
				c = false;
				k = new Timer();
				j.Interval = 10;
				j.Tick += new EventHandler(vist);
				k.Tick += new EventHandler(timer2_Tick);
				k.Interval = 4000;
				cshet++;

			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			mon = 50;
			box.BackgroundImage = Properties.Resources.kat;
			pictureBox1.BackColor = Color.LightBlue;
			pictureBox2.BackColor = Color.White;
			pictureBox3.BackColor = Color.White;
			c = true;
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			mon = 100;
			box.BackgroundImage = Properties.Resources.kat2;
			pictureBox2.BackColor = Color.LightBlue;
			pictureBox1.BackColor = Color.White;
			pictureBox3.BackColor = Color.White;
			c = true;
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			mon = 75;
			box.BackgroundImage = Properties.Resources.kat3;
			pictureBox3.BackColor = Color.LightBlue;
			pictureBox1.BackColor = Color.White;
			pictureBox2.BackColor = Color.White;
			c = true;
		}

		public void generatevrag()
		{
			for (int g = 0; g < 4; g++)
			{
				vrag[g] = new PictureBox();
				vrag[g].Location = new Point(920,100 * g);
				vrag[g].Size = new Size(100,100);
				vrag[g].BackgroundImage = Properties.Resources.virusfull100;
				Controls.Add(vrag[g]);
				vrag[g].BringToFront();
				System.Drawing.Drawing2D.GraphicsPath gp = BuildTransparencyPath(Properties.Resources.virusfull100);
				vrag[g].Region = new Region(gp);
			}

		}

		private void button1_Click(object sender, EventArgs e)
		{
			generatevrag();
			j.Enabled = true;
			timer1.Enabled = true;
			k.Start();
			j.Start();
		}
		public void vist(object sender, EventArgs e)
		{

			for (int b = 0; b < 140; b++)
			{
				if (bull[b] != null)
				{
					bull[b].Location = new Point(bull[b].Location.X + 1, bull[b].Location.Y);
					for (int k = 4; k >= 0; k--)
					{
						if ((bull[b] != null) && (vrag[k] != null))
						{
							if ((bull[b].Location.X == vrag[k].Location.X) && (bull[b].Location.Y == vrag[k].Location.Y))
							{
								bull[b].BackgroundImage = null;
								vrag[k].Dispose();
								vrag[k] = null;
								bull[b].Dispose();
								bull[b] = null;
								money += 25;
								textBox1.Text = Convert.ToString(money);
							}
						}
					}
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < 40; i++)
			{
				if (vrag[i] != null)
				{
					vrag[i].Location = new Point(vrag[i].Location.X - 1, vrag[i].Location.Y);
				}
			}
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			for (int j = 0; j < cshet; j++) {
				bull[j + (prox *7)] = new PictureBox();
				bull[j + (prox * 7)].Location = new Point(cats[j].Location.X, cats[j].Location.Y);
				bull[j + (prox * 7)].Size = new Size(100, 100);
				Controls.Add(bull[j + (prox * 7)]);
				bull[j + (prox * 7)].BringToFront();
				bull[j + (prox * 7)].BackgroundImage = Properties.Resources.sherst;
			}
			prox++;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button1.Text = "следующая волна";
			this.Size = new Size(1020, 550);
			pictureBox4.Visible = false;
			button2.Visible = false;
			button2.Enabled = false;
			textBox1.Text = Convert.ToString(money);
			for (int l = 0; l <= 3; l++)
			{
				eat[l] = new PictureBox();
				eat[l].Location = new Point(0, l * 100);
				eat[l].BackgroundImage = Properties.Resources.milk;
				eat[l].Size = new Size(100, 100);
				Controls.Add(eat[l]);
				for (int j = 0; j <= 9; j++)
				{
					pictureBox[l, j] = new PictureBox();
					pictureBox[l, j].Click += new EventHandler(pos);
					pictureBox[l, j].Size = new Size(100, 100);
					pictureBox[l, j].Location = new Point(100 * j, 100 * l);
					if (l % 2 == 0)
					{
						if (j % 2 == 0)
						{
							pictureBox[l, j].BackgroundImage = Properties.Resources.gazon;
						}
						else
						{
							pictureBox[l, j].BackgroundImage = Properties.Resources.gazon2;
						}
					}
					else
					{
						if (j % 2 == 0)
						{
							pictureBox[l, j].BackgroundImage = Properties.Resources.gazon2;
						}
						else
						{
							pictureBox[l, j].BackgroundImage = Properties.Resources.gazon;
						}
					}
					Controls.Add(pictureBox[l, j]);
				}
			}
			pictureBox1.BackgroundImage = Properties.Resources.kat;
			pictureBox2.BackgroundImage = Properties.Resources.kat2;
			pictureBox3.BackgroundImage = Properties.Resources.kat3;
		}
	}
}

