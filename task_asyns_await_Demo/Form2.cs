using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_asyns_await_Demo
{
    public partial class Form2 : Form
    {
        private int sayac = 0;
        private int sayac2 = 0;
        private int sayac3 = 0;
        private int sayac4 = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = $"{DateTime.Now.Minute}:{DateTime.Now.Second}  --> {sayac++} Thread :{Thread.CurrentThread.ManagedThreadId}";
            listBox1.Items.Insert(0, str);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
             FillList2(1); // "Birinci işlem");  //5 sn

             FillList3(1);// "ikinci işlem"); //10 sn

            FillList4(1); //, "üçüncü işlem");  //20 sn
        }

        void MetotOlcumu(Action action, string name)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            action.Invoke();
            listBox5.Items.Add($"{name}: {stopwatch.Elapsed.TotalSeconds.ToString() } ");
        }
        async Task FillList2(int delay)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                string str = $"{DateTime.Now.Minute}:{DateTime.Now.Second}  --> {sayac2++} Thread :{Thread.CurrentThread.ManagedThreadId}";
                listBox2.Items.Add(str);
                await Task.Delay(delay);
            }
            listBox5.Items.Add($"{"Birinci :"}: {stopwatch.Elapsed.TotalSeconds.ToString() } ");

        }
        async Task FillList3(int delay)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                string str = $"{DateTime.Now.Minute}:{DateTime.Now.Second}  --> {sayac3++} Thread :{Thread.CurrentThread.ManagedThreadId}";
                listBox3.Items.Add(str);
                await Task.Delay(delay);
            }
            listBox5.Items.Add($"{"ikinci :"}: {stopwatch.Elapsed.TotalSeconds.ToString() } ");
        }
        async Task FillList4(int delay)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                string str = $"{DateTime.Now.Minute}:{DateTime.Now.Second}  --> {sayac4++} Thread :{Thread.CurrentThread.ManagedThreadId}";
                listBox4.Items.Add(str);
               await Task.Delay(delay);
            }
            listBox5.Items.Add($"{"üçüncü :"}: {stopwatch.Elapsed.TotalSeconds.ToString() } ");

        }
    }
}
