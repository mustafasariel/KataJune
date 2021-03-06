﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net.Http;

namespace task_asyns_await_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            richTextBox1.Text = GetRead();

        }
        private async void btnReadAsync_Click(object sender, EventArgs e)
        {

            Task<string> okuma = GetReadAsync();

            Task<string> hurriyet = GetUrl("https://www.hurriyet.com");

            richTextBox1.Text = await okuma;

            richTextBox2.Text = await hurriyet;
           
        }
        string GetRead()
        {
            using (StreamReader streamReader = new StreamReader("readme.txt"))
            {
                var s = streamReader.ReadToEnd();
                Thread.Sleep(5000);
                // Task.Delay(5000);
                return s;
            }
        }
        int counter = 0;
        private void btnCounter_Click(object sender, EventArgs e)
        {
            txtCounter.Text = counter++.ToString();
        }

        async Task<string> GetUrl(string url)
        {
            await Task.Delay(12000);
            return await new HttpClient().GetStringAsync("https://www.google.com");
        }
        async Task<string> GetReadAsync()
        {
            using (StreamReader streamReader = new StreamReader("readme.txt"))
            {
                Task<string> mytask = streamReader.ReadToEndAsync();

                for (int i = 0; i < 100; i++)
                {
                    listBox1.Items.Insert(0, i);
                    await Task.Delay(50);
                    //Thread.Sleep(50);
                }
                await Task.Delay(500);
                return await mytask;
            }
        }


    }
}
