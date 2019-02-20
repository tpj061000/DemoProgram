using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProgram
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// Summary description for Form1.
    /// </summary> 
    public partial class Form1 : System.Windows.Forms.Form
    {
        public int[,] ballarray = new int[20, 20];
        public string[] colours = new string[16];
        public int g1 = 1;
        public int g2 = 200;
        public Bitmap bmp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem AnimateStart;
        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //colours[0]="Red";
            colours[1] = "Red";
            colours[2] = "Blue";
            colours[3] = "Black";
            colours[4] = "Yellow";
            colours[5] = "Crimson";
            colours[6] = "Gold";
            colours[7] = "Green";
            colours[8] = "Magenta";
            colours[9] = "Aquamarine";
            colours[10] = "Brown";
            colours[11] = "Red";
            colours[12] = "DarkBlue";
            colours[13] = "Brown";
            colours[14] = "Red";
            colours[15] = "DarkBlue";
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
       

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            for (int i = 1; i <= 13; i++)
            {
                //add direction vectors to coordinates
                ballarray[i, 1] = ballarray[i, 1] + ballarray[i, 3];
                ballarray[i, 2] = ballarray[i, 2] + ballarray[i, 4];
                //if ball goes of to right
                if ((ballarray[i, 1] + 50) >= ClientSize.Width)
                {
                    ballarray[i, 1] = ballarray[i, 1] - ballarray[i, 3];
                    ballarray[i, 3] = -ballarray[i, 3];
                }
                //if ball goes off bottom
                else if ((ballarray[i, 2] + 50) >= ClientSize.Height)
                {
                    ballarray[i, 2] = ballarray[i, 2] - ballarray[i, 4];
                    ballarray[i, 4] = -ballarray[i, 4];
                }
                //if ball goes off to left
                else if (ballarray[i, 1] <= 1)
                {
                    ballarray[i, 1] = ballarray[i, 1] - ballarray[i, 3];
                    ballarray[i, 3] = -ballarray[i, 3];
                }
                //if ball goes over top
                else if (ballarray[i, 2] <= 1)
                {
                    ballarray[i, 2] = ballarray[i, 2] - ballarray[i, 4];
                    ballarray[i, 4] = -ballarray[i, 4];
                }
            }
            this.Refresh(); //force repaint of window
        }
        //Called from timer event when window needs redrawing
        protected override void OnPaint(PaintEventArgs e)
        {
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height, e.Graphics);
            Graphics bmpGraphics = Graphics.FromImage(bmp);
            // draw here 
            for (int i = 1; i <= 13; i++)
            {
                bmpGraphics.DrawEllipse(new Pen(Color.FromName(colours[i]), 2), ballarray[i, 1], ballarray[i, 2], 50, 50);
            }
            e.Graphics.DrawImageUnscaled(bmp, 0, 0);
            //Draw ellipse acording to mouse coords.
            e.Graphics.DrawEllipse(new Pen(Color.Yellow, 4f), g1, g2, 50, 50);
            bmpGraphics.Dispose();
            bmp.Dispose();
        }
        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            Random r = new Random();
            //set ball coords and vectors x,y,xv,yv
            for (int i = 1; i <= 13; i++)
            {
                ballarray[i, 1] = +r.Next(10) + 1; //+1 means i lose zero values
                ballarray[i, 2] = +r.Next(10) + 1;
                ballarray[i, 3] = +r.Next(10) + 1;
                ballarray[i, 4] = +r.Next(10) + 1;
            }
            timer1.Start();
        }
        //Called when user moves the mouse
        protected override void OnMouseMove(MouseEventArgs m)
        {
            //Read the mouse x and y coords and use them to draw a circle in OnPaint method
            g1 = m.X;
            g2 = m.Y;
        }
        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            timer1.Stop();
        }
    }
}

