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
    public partial class FormAbout : Form
    {
        private readonly string localVersion = FormMain.localVersion;
        private static FormAbout formAbout;
        private static bool isShowThisForm=false;

        private FormAbout()
        {
            InitializeComponent();
            labelNowVersion.Text = localVersion;
        }

        public static FormAbout GetInstance()
        {
            if (isShowThisForm==false)
            {
                formAbout = new FormAbout();
                return formAbout;
            }
            else
            {
                return formAbout;
            }
        }
        public void SingleShow()
        {
            if (isShowThisForm)
            {
                formAbout.Focus();
            }
            else
            {
                formAbout.Show();
                isShowThisForm = true;
            }
        }

        private void labelYQYR_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://xiage.yy.com/space-uid-818569.html");
        }

        private void labelDD_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.wuxiatools.com/");
        }

        private void labelLR_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.zhihu.com/people/lu-ren-25-37/");
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelUpdateLog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.lofter.com/lpost/1eed0c5c_1c7c91c22");
        }

        private void buttonCheckVersion_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("https://www.lofter.com/lpost/1eed0c5c_1c7c91c22");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

            string webResult = reader.ReadToEnd();
            int versionFeature = webResult.IndexOf("工具最新版本：");
            int startIndexV = webResult.IndexOf("【", versionFeature);
            int endIndexV = webResult.IndexOf("】", versionFeature);
            string websiteVersion = webResult.Substring(startIndexV + 1, endIndexV - startIndexV - 1);

            if (localVersion!=websiteVersion)
            {
                DialogResult dialogResult = MessageBox.Show($"已有新版本：{websiteVersion}发布，是否前往下载？", "检查更新",MessageBoxButtons.YesNo);
                if (dialogResult==DialogResult.Yes)
                {
                    int downloadFeature = webResult.IndexOf("工具下载地址：");
                    int startIndexD = webResult.IndexOf("【", downloadFeature);
                    int endIndexD = webResult.IndexOf("】", downloadFeature);
                    string latestDownload = webResult.Substring(startIndexD + 1, endIndexD - startIndexD-1);
                    System.Diagnostics.Process.Start(latestDownload);
                }
            }
            else
            {
                MessageBox.Show("当前已是最新版本！","检查更新");
            }
        }

        private void FormAbout_FormClosing(object sender, FormClosingEventArgs e)
        {
            isShowThisForm = false;
        }
    }
}
