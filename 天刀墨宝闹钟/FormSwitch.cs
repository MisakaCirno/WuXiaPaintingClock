using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace 天刀墨宝闹钟
{
    public partial class FormSwitch : Form
    {
        bool isShowForm;//窗口是否显示

        public static FormReminder reminderForm;

        //获取窗口句柄
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();
        //获取窗口标题
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        public FormSwitch()
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

        private void FormSwitch_Load(object sender, EventArgs e)
        {
            var x = Screen.PrimaryScreen.Bounds.Width - Width;
            var y = Screen.PrimaryScreen.Bounds.Height - Height - 150;
            Location = new Point(x, y);

            pictureBox1.Image = Properties.Resources.ButtonON;

            reminderForm = new FormReminder();
            reminderForm.fatherFormXPos=Location.X;
            reminderForm.fatherFormYPos =Location.Y;
            reminderForm.UpdateForm(FormMain.reminderList);
            reminderForm.Show();
            isShowForm = true;

            timer1.Start();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.ButtonON;
        }

        private void FormSwitch_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.ButtonPoint;
        }

        private void FormSwitch_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.ButtonOFF;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (isShowForm==false)
            {
                pictureBox1.Image= Properties.Resources.ButtonPoint;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (isShowForm == false)
            {
                pictureBox1.Image = Properties.Resources.ButtonOFF;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (isShowForm)
            {
                isShowForm = false;
                pictureBox1.Image = Properties.Resources.ButtonOFF;
                reminderForm.Visible = false;
            }
            else
            {
                isShowForm = true;
                pictureBox1.Image = Properties.Resources.ButtonON;
                reminderForm.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("Timer is running!");
            /*
            //根据窗口标题判断是否隐藏
            StringBuilder s = new StringBuilder(512);
            GetWindowText(GetForegroundWindow(), s, s.Capacity);
            //Console.WriteLine(s.ToString());
            
            if (s.ToString()!= "天涯明月刀")
            {
                if (Visible==true)
                {
                    Visible = false;
                    reminderForm.Visible = false;
                }
            }
            else
            {
                if (Visible==false)
                {
                    Visible = true;
                    reminderForm.Visible = true;
                }
            }
            */
            
        }

        private void FormSwitch_FormClosing(object sender, FormClosingEventArgs e)
        {
            reminderForm.Close();
        }

        public void HideFormSwitch()
        {
            timer1.Stop();
            Visible = false;
            reminderForm.Visible = false;
        }

        public void ShowFormSwitch()
        {
            timer1.Start();
            Visible = true;
            reminderForm.Visible = true;
        }
    }
}
