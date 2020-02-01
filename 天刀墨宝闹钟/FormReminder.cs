using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace 天刀墨宝闹钟
{
    public partial class FormReminder : Form
    {
        public int fatherFormXPos;
        public int fatherFormYPos;
        public FormReminder()
        {
            InitializeComponent();
        }

        //隐藏Alt+Tab显示
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private void FormReminder_Load(object sender, EventArgs e)
        {
            var x = fatherFormXPos-Width;
            var y = fatherFormYPos-Height+63;
            Location = new Point(x, y);
        }

        public void UpdateForm(List<string[]> list)
        {
            Visible = false;
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel1.Controls.Clear();
            if (list.Count==0)
            {
                Label newLaber = new Label();
                newLaber.Margin = new Padding(3, 5, 3, 5);
                newLaber.Text = "目前没有可绘制的书画";
                newLaber.Font = flowLayoutPanel1.Font;
                newLaber.AutoSize = true;
                flowLayoutPanel1.Controls.Add(newLaber);

                Height = 24;

                var x = Screen.PrimaryScreen.Bounds.Width - Width - 20;
                var y =  Height - 150;
                Location = new Point(x, y);

                Visible = true;
                flowLayoutPanel1.Visible = true;
            }
            else
            {
                //24*数量
                int count = 0;
                foreach (var item in list)
                {
                    Label newLaber = new Label();
                    newLaber.Margin = new Padding(3, 5, 3, 5);
                    newLaber.Text = $"【{item[0]}】【{item[1]}】";
                    newLaber.Font = flowLayoutPanel1.Font;
                    newLaber.AutoSize = true;
                    newLaber.ForeColor = Color.FromArgb(0, 254, 0);
                    //Console.WriteLine(newLaber.ForeColor.ToString());
                    flowLayoutPanel1.Controls.Add(newLaber);
                    count++;
                }
                Height = 24 * count;

                var x = fatherFormXPos - Width;
                var y = fatherFormYPos - Height + 63;
                Location = new Point(x, y);

                Visible = true;
                flowLayoutPanel1.Visible = true;
            }
        }
    }
}
