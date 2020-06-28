using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_asyns_await_Demo
{
    public partial class Form3 : Form
    {
        private int sayac = 0;
        private int sayac2 = 0;
        private int sayac3 = 0;
        private int sayac4 = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = $"{DateTime.Now.Minute}:{DateTime.Now.Second}  --> {sayac++}";
            listBox1.Items.Insert(0, str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FillList2(500);
            FillList3(1000);
            FillList4(2000);
        }

        void FillList2(int delay)
        {
            listBox2.Items.Insert(0, $"Delay :{delay}");
            for (int i = 0; i < 10; i++)
            {
                string str = $"{DateTime.Now.Minute}:{DateTime.Now.Second}  --> {sayac2++}";
                listBox2.Items.Insert(0, str);
                Thread.Sleep(delay);
            }

        }
        void FillList3(int delay)
        {
            listBox3.Items.Insert(0, $"Delay :{delay}");

            for (int i = 0; i < 10; i++)
            {
                string str = $"{DateTime.Now.Minute}:{DateTime.Now.Second}  --> {sayac3++}";
                listBox3.Items.Insert(0, str);
                Thread.Sleep(delay);
            }

        }
        void FillList4(int delay)
        {
            listBox4.Items.Insert(0, $"Delay :{delay}");

            for (int i = 0; i < 10; i++)
            {
                string str = $"{DateTime.Now.Minute}:{DateTime.Now.Second}  --> {sayac4++}";
                listBox4.Items.Insert(0, str);
                Thread.Sleep(delay);
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
