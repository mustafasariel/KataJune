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

namespace WinTaskRunDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        async Task Go(ProgressBar pb,int delay)
        {
            await Task.Run(() =>
            {
                Enumerable.Range(1, 20).ToList().ForEach(x =>
                 {
                     pb.Invoke((MethodInvoker)delegate
                     {
                         pb.Value = x;
                     });
                     Thread.Sleep(delay);

                     listBox1.Invoke((MethodInvoker)delegate
                     {
                         string msg = $"Name :{pb.Name} ManagedThreadId :{Thread.CurrentThread.ManagedThreadId}";
                         listBox1.Items.Add(msg);
                     }
                     );
                 }
                );
            }
            );
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
         await   Go(progressBar1,100);
            Go(progressBar2,150);
        }
        int counter = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = counter++.ToString();
        }
    }
}
