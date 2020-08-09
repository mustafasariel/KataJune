using System;
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

namespace cancelationToken2Demos
{
    public partial class Form1 : Form
    {
        CancellationTokenSource ct;
        public Form1()
        {

            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ct = new CancellationTokenSource();
            List<string> urls = new List<string>
            {
                "https://www.google.com",
                "https://ntv.com.tr",
                 "https://amazon.com.tr",
                  "https://ntv.com.tr",
                   "https://star.com.tr",
                    "https://hurriyet.com.tr",
                     "https://sozcu.com.tr",
                      "https://takvim.com.tr",
                       "https://sabah.com.tr",
                        "https://aksam.com.tr",
                         "https://cumhuriyet.com.tr"

            };
            HttpClient httpClient = new HttpClient();

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = ct.Token;

            Task.Run(() =>
            {
                try
                {
                    Parallel.ForEach<string>(urls, parallelOptions, (url) =>
                      {
                          string content = httpClient.GetStringAsync(url).Result;

                          string data = $"{url} : {content.Length}";

                          ct.Token.ThrowIfCancellationRequested();
                          listBox1.Invoke((MethodInvoker)delegate
                          {
                              listBox1.Items.Add(data);
                          });
                      });
                    Text = $"işlem bitti :{DateTime.Now.ToString()}";
                }
                catch (OperationCanceledException ex)
                {
                    MessageBox.Show($"işlem iptal edildi :{ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Başka bir hata:{ex.Message}");
                }
            });
        }

        int counter = 0;
        private void btnPlus_Click(object sender, EventArgs e)
        {
            counter++;
            btnPlus.Text = counter.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }
    }
}
