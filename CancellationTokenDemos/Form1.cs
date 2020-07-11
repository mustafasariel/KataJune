﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CancellationTokenDemos
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cancellationToken=new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
        }

        private  void btnCancel_Click(object sender, EventArgs e)
        {
            cancellationToken.Cancel();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {

                Task<HttpResponseMessage> myTask;
                 myTask = new HttpClient().GetAsync("https://localhost:44370/api/home", cancellationToken.Token);
                //  myTask = new HttpClient().GetAsync("https://hurriyet.com", cancellationToken.Token);

                await myTask;

                var content = await myTask.Result.Content.ReadAsStringAsync();
                richTextBox1.Text = content;
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show(ex.GetType().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
