using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 天刀墨宝闹钟
{
    public partial class FormHelp : Form
    {
        private static FormHelp formHelp;
        private static bool isShowThisForm = false;

        private FormHelp()
        {
            InitializeComponent();
        }

        public static FormHelp GetInstance()
        {
            if (isShowThisForm == false)
            {
                formHelp = new FormHelp();
                return formHelp;
            }
            else
            {
                return formHelp;
            }
        }

        public void SingleShow()
        {
            if (isShowThisForm)
            {
                formHelp.Focus();
            }
            else
            {
                formHelp.Show();
                isShowThisForm = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOpenWeb_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("https://www.lofter.com/lpost/1eed0c5c_1c7c91c22");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

            string webResult = reader.ReadToEnd();

            int downloadFeature = webResult.IndexOf("工具下载地址：");
            int startIndexD = webResult.IndexOf("【", downloadFeature);
            int endIndexD = webResult.IndexOf("】", downloadFeature);
            string latestDownload = webResult.Substring(startIndexD + 1, endIndexD - startIndexD - 1);
            System.Diagnostics.Process.Start(latestDownload);
        }

        private void FormHelp_FormClosing(object sender, FormClosingEventArgs e)
        {
            isShowThisForm = false;
        }
    }
}
