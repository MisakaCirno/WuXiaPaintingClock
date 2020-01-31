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
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOpenWeb_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://xiage.yy.com/thread-196964-1-1.html");
        }
    }
}
