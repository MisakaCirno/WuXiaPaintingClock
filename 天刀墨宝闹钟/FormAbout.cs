using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 天刀墨宝闹钟
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://xiage.yy.com/space-uid-818569.html");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.wuxiatools.com/");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.zhihu.com/people/lu-ren-25-37/");
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://xiage.yy.com/thread-196964-1-1.html");
        }
    }
}
