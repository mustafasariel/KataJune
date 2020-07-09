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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setReader(lbl1);
            setReader(lbl2);
            setReader(lbl3);
            setReader(lbl4);
        }

        private void setReader(Label lbl)
        {

            lbl.Size = new Size(50, 23);
            lbl.BackColor = Color.White;

            lbl.BorderStyle = BorderStyle.Fixed3D;
        }



        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = e.Location.ToString();

            setText(lbl1, e.Location);
            setText(lbl2, e.Location);
            setText(lbl3, e.Location);
            setText(lbl4, e.Location);
        }
        void setText(Label lbl, Point p)
        {
            lbl.Text = $"{GetTwoPointLen(p, lbl.Location)}";
        }


        double GetTwoPointLen(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow((p2.Y - p1.Y), 2) + Math.Pow((p2.X - p1.X), 2));
        }
    }
}
