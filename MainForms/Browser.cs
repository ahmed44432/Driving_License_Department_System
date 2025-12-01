using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string url = $"https://www.google.com/";

            await webView21.EnsureCoreWebView2Async(null);
            webView21.Source = new Uri(url);

        }

     
    }
}
