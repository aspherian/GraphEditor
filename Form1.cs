using System;
using System.Drawing;
using System.Windows.Forms;

namespace grapheditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Graphics formGraphics;
        bool isDown = false;
        int initialX;
        int initialY;
        bool Square = false;

        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            isDown = true;
            initialX = e.X;
            initialY = e.Y;
        }

        private void Form1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (Square)
            {
                if (isDown) {
                    Cursor.Current = Cursors.SizeNWSE;
                    Rectangle myRectangle = new Rectangle(Math.Min(e.X, initialX),
                                                   Math.Min(e.Y, initialY),
                                                   Math.Abs(e.X - initialX),
                                                   Math.Abs(e.Y - initialY));

                    formGraphics = CreateGraphics();
                    formGraphics.DrawRectangle(Pens.Black, myRectangle);
                    formGraphics.FillRectangle(Brushes.Black, myRectangle);
                }
            } else
            {
                if (isDown)
                {

                    formGraphics = CreateGraphics();
                    formGraphics.DrawEllipse(Pens.Black, e.X, e.Y, 10, 10);
                    formGraphics.FillEllipse(Brushes.Black, e.X, e.Y, 10, 10);
                }
            }
        }

        private void Form1_MouseUp_1(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();

            g.Clear(Color.White);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Square = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Square = false;
        }
    }
}
