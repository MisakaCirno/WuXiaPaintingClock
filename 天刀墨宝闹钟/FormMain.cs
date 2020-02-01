using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaintingDate;
using Newtonsoft.Json;
using System.IO;

namespace 天刀墨宝闹钟
{
    public partial class FormMain : Form
    {
        Dictionary<string, QueueElement> paintingQueue = new Dictionary<string, QueueElement>(); //监测的队列
        Dictionary<string, TimeAndMapName> paintingData = new Dictionary<string, TimeAndMapName>
        {
            //杭州低级
       /*1*/{ "画卷：杭州城",new TimeAndMapName(new string[]{"白昼"},"杭州") },
       /*2*/{ "画卷：一醉轩",new TimeAndMapName(new string[]{ "戌时", "亥时" },"杭州") },
       /*3*/{ "画卷：三潭印月",new TimeAndMapName(new string[]{ "丑时", "寅时" },"杭州") },
       /*4*/{ "画卷：问道台",new TimeAndMapName(new string[]{ "未时", "申时" },"杭州") },
       /*5*/{ "画卷：天绝禅院",new TimeAndMapName(new string[]{ "辰时", "巳时" },"杭州") },
            //江南
       /*1*/{ "画卷：龙井茶园",new TimeAndMapName(new string[]{ "辰时", "巳时" },"江南") },
       /*2*/{ "画卷：四明书院",new TimeAndMapName(new string[]{ "未时", "申时" },"江南") },
       /*3*/{ "画卷：连环坞",new TimeAndMapName(new string[]{ "戌时", "亥时" },"江南") },
       /*4*/{ "画卷：长风林",new TimeAndMapName(new string[]{ "酉时" },"江南") },
       /*5*/{ "画卷：天泉日出",new TimeAndMapName(new string[]{ "卯时" },"江南") },
       /*6*/{ "画卷：飞雪滩",new TimeAndMapName(new string[]{ "辰时", "巳时" },"江南") },
       /*7*/{ "画卷：霹雳堂旧址",new TimeAndMapName(new string[]{ "未时", "申时" },"江南") },
       /*8*/{ "画卷：铸神谷",new TimeAndMapName(new string[]{ "午时" },"江南") },
       /*9*/{ "画卷：枫桥夜泊",new TimeAndMapName(new string[]{ "子时" },"江南") },
            //东越
       /*1*/{ "画卷：桃源道观",new TimeAndMapName(new string[]{ "未时", "申时" },"东越") },
       /*2*/{ "画卷：云泥梯田",new TimeAndMapName(new string[]{ "辰时", "巳时" },"东越") },
       /*3*/{ "画卷：宁海镇",new TimeAndMapName(new string[]{ "戌时", "亥时" },"东越") },
       /*4*/{ "画卷：长乐滩",new TimeAndMapName(new string[]{ "丑时", "寅时" },"东越") },
       /*5*/{ "画卷：桑楚山庄",new TimeAndMapName(new string[]{ "丑时", "寅时" },"东越") },
       /*6*/{ "画卷：万象门",new TimeAndMapName(new string[]{ "白昼" },"东越") },
       /*7*/{ "画卷：清永民居",new TimeAndMapName(new string[]{ "卯时" },"东越") },
       /*8*/{ "画卷：天香谷",new TimeAndMapName(new string[]{ "子时" },"东越") },
       /*9*/{ "画卷：乌金汊",new TimeAndMapName(new string[]{ "午时" },"东越") },
      /*10*/{ "画卷：野鹤湫",new TimeAndMapName(new string[]{ "酉时" },"东越") },
      /*11*/{ "画卷：闽越旧城",new TimeAndMapName(new string[]{ "子时" },"东越") },
            //杭州(高级)
       /*1*/{ "画卷：淬剑清谷",new TimeAndMapName(new string[]{ "卯时" },"杭州") },
       /*2*/{ "画卷：风雨钱塘",new TimeAndMapName(new string[]{ "黑夜" },"杭州") },
       /*3*/{ "画卷：吴王陵",new TimeAndMapName(new string[]{ "子时" },"杭州") },
       /*4*/{ "画卷：百里荡",new TimeAndMapName(new string[]{ "午时" },"杭州") },
       /*5*/{ "画卷：东平郡王府",new TimeAndMapName(new string[]{ "子时" },"杭州") },
       /*6*/{ "画卷：雷峰夕照",new TimeAndMapName(new string[]{ "酉时" },"杭州") },
            //九华
       /*1*/{ "画卷：藏锋谷",new TimeAndMapName(new string[]{ "辰时", "巳时" },"九华") },
       /*2*/{ "画卷：燕来镇",new TimeAndMapName(new string[]{ "未时", "申时" },"九华") },
       /*3*/{ "画卷：送君廊",new TimeAndMapName(new string[]{ "戌时", "亥时" },"九华") },
       /*4*/{ "画卷：得意坊",new TimeAndMapName(new string[]{ "子时" },"九华") },
       /*5*/{ "画卷：化清古佛",new TimeAndMapName(new string[]{ "卯时" },"九华") },
       /*6*/{ "画卷：离魂峡",new TimeAndMapName(new string[]{ "酉时" },"九华") },
       /*7*/{ "画卷：孔雀山庄",new TimeAndMapName(new string[]{ "午时" },"九华") },
       /*8*/{ "画卷：芳华谷",new TimeAndMapName(new string[]{ "辰时", "巳时" },"九华") },
       /*9*/{ "画卷：血衣楼",new TimeAndMapName(new string[]{ "未时", "申时" },"九华") },
      /*10*/{ "画卷：血衣禁地",new TimeAndMapName(new string[]{ "丑时", "寅时" },"九华") },
            //徐海
       /*1*/{ "画卷：平阳驿站",new TimeAndMapName(new string[]{ "戌时", "亥时" },"徐海") },
       /*2*/{ "画卷：藏月客栈",new TimeAndMapName(new string[]{ "辰时", "巳时" },"徐海") },
       /*3*/{ "画卷：古陶镇",new TimeAndMapName(new string[]{ "丑时", "寅时" },"徐海") },
       /*4*/{ "画卷：骅阳林",new TimeAndMapName(new string[]{ "未时", "申时" },"徐海") },
       /*5*/{ "画卷：天龙古刹",new TimeAndMapName(new string[]{ "酉时" },"徐海") },
       /*6*/{ "画卷：剑绝轩",new TimeAndMapName(new string[]{ "子时" },"徐海") },
       /*7*/{ "画卷：玄刀断剑",new TimeAndMapName(new string[]{ "卯时" },"徐海") },
       /*8*/{ "画卷：望断斜阳",new TimeAndMapName(new string[]{ "午时" },"徐海") },
            //开封
       /*1*/{ "画卷：开封城门",new TimeAndMapName(new string[]{ "丑时", "寅时" },"开封") },
       /*2*/{ "画卷：护龙河",new TimeAndMapName(new string[]{ "辰时", "巳时" },"开封") },
       /*3*/{ "画卷：朱仙镇",new TimeAndMapName(new string[]{ "酉时" },"开封") },
       /*4*/{ "画卷：相国寺",new TimeAndMapName(new string[]{ "卯时" },"开封") },
       /*5*/{ "画卷：开封城",new TimeAndMapName(new string[]{ "子时" },"开封") },
       /*6*/{ "画卷：居士林",new TimeAndMapName(new string[]{ "戌时", "亥时" },"开封") },
       /*7*/{ "画卷：飞霞渡",new TimeAndMapName(new string[]{ "午时" },"开封") },
       /*8*/{ "画卷：百鬼夜哭",new TimeAndMapName(new string[]{ "子时" },"开封") },
            //秦川
       /*1*/{ "画卷：论剑峰",new TimeAndMapName(new string[]{ "丑时", "寅时" },"秦川") },
       /*2*/{ "画卷：药王谷",new TimeAndMapName(new string[]{ "未时", "申时" },"秦川") },
       /*3*/{ "画卷：论剑坪",new TimeAndMapName(new string[]{ "辰时", "巳时" },"秦川") },
       /*4*/{ "画卷：鹦哥镇",new TimeAndMapName(new string[]{ "未时", "申时" },"秦川") },
       /*5*/{ "画卷：太白山门",new TimeAndMapName(new string[]{ "卯时" },"秦川") },
       /*6*/{ "画卷：玉泉院",new TimeAndMapName(new string[]{ "午时" },"秦川") },
       /*7*/{ "画卷：秦川云海",new TimeAndMapName(new string[]{ "酉时" },"秦川") },
       /*8*/{ "画卷：万剑沉浮",new TimeAndMapName(new string[]{ "子时" },"秦川") },
            //燕云
       /*1*/{ "画卷：瀚海戈壁",new TimeAndMapName(new string[]{ "辰时", "巳时" },"燕云") },
       /*2*/{ "画卷：神木谷",new TimeAndMapName(new string[]{ "戌时", "亥时" },"燕云") },
       /*3*/{ "画卷：苍梧城",new TimeAndMapName(new string[]{ "丑时", "寅时" },"燕云") },
       /*4*/{ "画卷：风飞谷",new TimeAndMapName(new string[]{ "未时", "申时" },"燕云") },
       /*5*/{ "画卷：月下饮马",new TimeAndMapName(new string[]{ "子时" },"燕云") },
       /*6*/{ "画卷：策马坡",new TimeAndMapName(new string[]{ "酉时" },"燕云") },
       /*7*/{ "画卷：绝尘马场",new TimeAndMapName(new string[]{ "卯时" },"燕云") },
       /*8*/{ "画卷：燕云神威",new TimeAndMapName(new string[]{ "子时" },"燕云") },
       /*9*/{ "画卷：怪石黑风",new TimeAndMapName(new string[]{ "午时" },"燕云") },
            //巴蜀
       /*1*/{ "画卷：云来镇",new TimeAndMapName(new string[]{ "未时", "申时" },"巴蜀") },
       /*2*/{ "画卷：逢捷镇",new TimeAndMapName(new string[]{ "戌时", "亥时" },"巴蜀") },
       /*3*/{ "画卷：凌云壁",new TimeAndMapName(new string[]{ "卯时" },"巴蜀") },
       /*4*/{ "画卷：醉月居",new TimeAndMapName(new string[]{ "戌时", "亥时" },"巴蜀") },
       /*5*/{ "画卷：御风堂",new TimeAndMapName(new string[]{ "辰时", "巳时" },"巴蜀") },
       /*6*/{ "画卷：万青竹海",new TimeAndMapName(new string[]{ "丑时", "寅时" },"巴蜀") },
       /*7*/{ "画卷：翠海",new TimeAndMapName(new string[]{ "午时" },"巴蜀") },
       /*8*/{ "画卷：忘忧谷",new TimeAndMapName(new string[]{ "子时" },"巴蜀") },
        }; //地图对应时辰

        List<Button> buttonList; //存储展开合并按钮
        public static List<string[]> reminderList=new List<string[]>();//存储要提醒的书画给提示窗口用

        string prevChinaTime = "";
        string prevChinaTimeDayAndNight = "";
        string nowChinaTime = "";
        string nowChinaTimeDayAndNight = "";
        
        bool isNodeChecked; //用于判断是否选中
        bool isUseBalloon; //是否开启右下角弹窗提醒
        bool isUseReminderForm; //是否开启单独窗口提醒
        bool isTimerRunning; //是否开启时钟
        bool isUseMultiSelect; //是否使用了多选

        FormSwitch formSwitch;//开关窗口


        private void AddPaintingToQueue (string name) //添加墨宝到监测的队列
        {
            paintingQueue.Add(name, new QueueElement { paintingName = name, timeArray = paintingData[name].timeList, isUsable = false,mapName= paintingData[name].mapName });
        }

        private void RemovePaintingFromQueue(string name) //从检测队列中删除墨宝
        {
            paintingQueue.Remove(name);
        }

        private void Inform(string name) //监测到后提醒
        {
            //Console.WriteLine($"墨宝：【{name}】现在已可以绘制");
            if (isUseBalloon==true)
            {
                notifyIcon1.ShowBalloonTip(2000, "墨宝闹钟提示", $"【{name}】现在已可以绘制", ToolTipIcon.None);
            }
        }

        private void WriteDefaultConfig(string path) //生成默认配置文件
        {
            File.WriteAllText(path,JsonConvert.SerializeObject(SettingsJsondefault.defaultJson));
        }

        private void ReadConfig() //读取配置文件
        {
            string jsonPath = Application.StartupPath;
            jsonPath = Path.Combine(jsonPath, "Settings.json");
            if (File.Exists(jsonPath)==false) //如果不存在就生成个默认配置文件
            {
                MessageBox.Show("未读取到用户配置文件，已自动生成！","提示");
                WriteDefaultConfig(jsonPath);
                return;
            }

            SettingsJson settings = JsonConvert.DeserializeObject<SettingsJson>(File.ReadAllText(jsonPath));

            //遍历每块板子
            foreach (var panel in flowLayoutPanelSetting.Controls)
            {
                //找到每块板子里的TreeView
                foreach (var treeView in ((Panel)panel).Controls)
                {
                    if (treeView is TreeView)
                    {
                        //遍历每个TreeView的节点，依此根据字典设定
                        foreach (var node in ((TreeView)treeView).Nodes)
                        {
                            var tNode = (TreeNode)node;
                            tNode.Checked = settings.treeViewDic[tNode.Text];
                        }
                    }
                }
            }

            isTimerRunning = settings.isTimerRunning;
            checkBoxTimer.Checked = isTimerRunning;

            isUseBalloon = settings.isUseBalloon;
            checkBoxRemind.Checked = isUseBalloon;

            isUseReminderForm = settings.isUseReminderForm;
            checkBoxGame.Checked = isUseReminderForm;
        }

        private void SaveConfig()
        {
            string jsonPath = Application.StartupPath;
            jsonPath = Path.Combine(jsonPath, "Settings.json");
            var saveJson = SettingsJsondefault.defaultJson;

            saveJson.isTimerRunning = isTimerRunning;
            saveJson.isUseBalloon = isUseBalloon;
            saveJson.isUseReminderForm = isUseReminderForm;
            
            //遍历每块板子
            foreach (var panel in flowLayoutPanelSetting.Controls)
            {
                //找到每块板子里的TreeView
                foreach (var treeView in ((Panel)panel).Controls)
                {
                    if (treeView is TreeView)
                    {
                        //遍历每个TreeView的节点，依此设定字典
                        foreach (var node in ((TreeView)treeView).Nodes)
                        {
                            var tNode = (TreeNode)node;
                            saveJson.treeViewDic[tNode.Text] = tNode.Checked;
                        }
                    }
                }
            }

            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(saveJson));
        }

        
        public FormMain()
        {
            InitializeComponent();
            Icon = Properties.Resources.myIcon;

            //把按钮装到一个list里头，方便后面操作折叠展开
            buttonList = new List<Button>
            {
                buttonHZLSwitch,
                buttonJNSwitch,
                buttonDYSwitch,
                buttonHZHSwitch,
                buttonJHSwitch,
                buttonXHSwitch,
                buttonKFSwitch,
                buttonQCSwitch,
                buttonYYSwitch,
                buttonBSSwitch
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "正在读取配置中... 请稍等";
            ReadConfig();
            Text = "天刀墨宝闹钟 v1.1.0";

            notifyIcon1.Text = "天刀墨宝闹钟";
            notifyIcon1.Icon = Properties.Resources.myIcon;
            notifyIcon1.Visible = true;

        }

        
        private void timer1_Tick(object sender, EventArgs e) //时钟周期事件
        {
            if (isTimerRunning==false)
            {
                //关闭timer
                timer1.Stop();
                return;
            }

            //修改标签内容
            //labelNowTime.Text = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
            labelNowTime.Text = DateTime.Now.ToString("HH:mm:ss"); 

            TimeHMS nowTimeSame = new TimeHMS(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            TimeResult chinaTime = ChinaTime.GetChinaTime(nowTimeSame.hour, nowTimeSame.minute, nowTimeSame.second);
            nowChinaTime = chinaTime.timeName;
            nowChinaTimeDayAndNight= ChinaTime.GetChinaTimeDayOrNight(nowTimeSame.hour, nowTimeSame.minute, nowTimeSame.second);

            labelGameTime.Text = chinaTime.timeName;
            labelEndTime.Text = chinaTime.endTime;

            if (nowChinaTime!=prevChinaTime|| nowChinaTimeDayAndNight != prevChinaTimeDayAndNight) //当时辰或昼夜发生变化的时候
            {
                prevChinaTime = nowChinaTime;
                prevChinaTimeDayAndNight = nowChinaTimeDayAndNight;

                if (paintingQueue.Count == 0)
                {
                    listViewShowQueue.Items.Clear();
                    return;
                }

                CheckQueue();
                UpdateList();

                if (isUseReminderForm)
                {
                    FormSwitch.reminderForm.UpdateForm(reminderList);
                }
            }
        }

        private void CheckQueue() //检测并修改队列
        {
            reminderList.Clear();

            foreach (var item in paintingQueue) //遍历队列中的每一项
            {
                foreach (var time in item.Value.timeArray) //遍历每个墨宝的时间段
                {

                    //如果是白昼或黑夜，就去调用对应的方法
                    if (time == "白昼" || time == "黑夜")
                    {
                        if (time == nowChinaTimeDayAndNight)
                        {
                            item.Value.isUsable = true;
                            Inform(item.Value.paintingName);
                            //如果开启了窗口提示功能，那么就添加队列
                            if (isUseReminderForm)
                            {
                                reminderList.Add(new string[] { item.Value.mapName, item.Value.paintingName });
                            }
                            break;
                        }
                        //如果不符合就重置一下状态
                        else
                        {
                            item.Value.isUsable = false;
                        }
                    }
                    //否则就去调用十二时辰的方法
                    else
                    {
                        if (time == nowChinaTime) //如果现在时辰和书画时辰一致
                        {
                            item.Value.isUsable = true;
                            Inform(item.Value.paintingName);

                            //如果开启了窗口提示功能，那么就添加队列
                            if (isUseReminderForm)
                            {
                                reminderList.Add(new string[] { item.Value.mapName, item.Value.paintingName });
                            }
                            break;
                        }
                        else //如果现在时辰和书画时辰不一致
                        {
                            if (time == item.Value.timeArray.Last()) //如果是最后一个元素，说明都不符合
                            {
                                //那么就重设一下状态
                                item.Value.isUsable = false;
                            }
                        }
                    }
                }
            }
        }

        private void UpdateList() //更新ListView的内容
        {
            listViewShowQueue.BeginUpdate();
            listViewShowQueue.Items.Clear();

            foreach (var item in paintingQueue)
            {
                var row = new string[] { item.Value.mapName, item.Value.paintingName, "default" };
                ListViewItem listViewItem= new ListViewItem(row);

                if (item.Value.isUsable)
                {
                    listViewItem.SubItems[0].Text = "时辰已到";
                    listViewItem.ForeColor = Color.Green;
                    listViewItem.Font = new Font(listViewShowQueue.Font, FontStyle.Bold);
                }
                else
                {
                    listViewItem.SubItems[0].Text = "时辰未到";
                }

                listViewShowQueue.Items.Add(listViewItem);
            }

            listViewShowQueue.EndUpdate();
        }


        private void hideButton_Click(object sender, EventArgs e) //隐藏按钮
        {
            Button button = sender as Button;
            if (button.Text=="+")
            {
                foreach (var item in button.Parent.Controls)
                {
                    if (item is TreeView)
                    {
                        button.Parent.Height = ((TreeView)item).Height + 36;
                        ((TreeView)item).Visible = true;
                    }
                    if (item is Button && ((Button)item).Text == "全选")
                    {
                        ((Button)item).Visible = true;
                    }
                    if (item is Button && ((Button)item).Text == "清除")
                    {
                        ((Button)item).Visible = true;
                    }
                }
                button.Text = "-";

            }
            else
            {
                foreach (var item in button.Parent.Controls)
                {
                    if (item is TreeView)
                    {
                        ((TreeView)item).Visible = false;
                        button.Parent.Height = 32;
                    }
                    if (item is Button && ((Button)item).Text == "全选")
                    {
                        ((Button)item).Visible = false;
                    }
                    if (item is Button && ((Button)item).Text == "清除")
                    {
                        ((Button)item).Visible = false;
                    }
                }
                button.Text = "+";
            }
            
        }

        private void buttonUnfoldAll_Click(object sender, EventArgs e) //展开全部
        {
            foreach (var button in buttonList)
            {
                if (button.Text=="+")
                {
                    foreach (var item in button.Parent.Controls)
                    {
                        if (item is TreeView)
                        {
                            button.Parent.Height = ((TreeView)item).Height + 36;
                            ((TreeView)item).Visible = true;
                        }
                        if (item is Button && ((Button)item).Text == "全选")
                        {
                            ((Button)item).Visible = true;
                        }
                        if (item is Button && ((Button)item).Text == "清除")
                        {
                            ((Button)item).Visible = true;
                        }
                    }
                    button.Text = "-";
                }
            }
            
        }

        private void buttonFoldAll_Click(object sender, EventArgs e) //折叠全部
        {
            foreach (var button in buttonList)
            {
                foreach (var item in button.Parent.Controls)
                {
                    if (item is TreeView)
                    {
                        ((TreeView)item).Visible = false;
                        button.Parent.Height = 32;
                    }
                    if (item is Button && ((Button)item).Text == "全选")
                    {
                        ((Button)item).Visible = false;
                    }
                    if (item is Button && ((Button)item).Text == "清除")
                    {
                        ((Button)item).Visible = false;
                    }
                }
                button.Text = "+";
            }
        }

        private void button_SelectAll(object sender, EventArgs e) //选择全部
        {
            isUseMultiSelect = true;

            Button button = sender as Button;
            foreach (var control in button.Parent.Controls)
            {
                if (control is TreeView)
                {
                    foreach (var node in ((TreeView)control).Nodes)
                    {
                        ((TreeNode)node).Checked = true;
                        /*
                        if (((TreeNode)node).Checked ==false)
                        {
                            ((TreeNode)node).Checked = true;
                        }
                        */
                    }
                }
            }

            CheckQueue();
            UpdateList();
            if (isUseReminderForm)
            {
                FormSwitch.reminderForm.UpdateForm(reminderList);
            }
            isUseMultiSelect = false;
        }

        private void button_ClearAll(object sender, EventArgs e) //取消选择全部
        {
            isUseMultiSelect = true;

            Button button = sender as Button;
            foreach (var control in button.Parent.Controls)
            {
                if (control is TreeView)
                {
                    foreach (var node in ((TreeView)control).Nodes)
                    {
                        ((TreeNode)node).Checked = false;
                        /*
                        if (((TreeNode)node).Checked == true)
                        {
                            ((TreeNode)node).Checked = false;
                        }
                        */
                    }
                }
            }

            CheckQueue();
            UpdateList();
            if (isUseReminderForm)
            {
                FormSwitch.reminderForm.UpdateForm(reminderList);
            }
            isUseMultiSelect = false;
        }

        private void treeView_DoubleClick(object sender, EventArgs e) //双击选中节点
        {
            
            TreeView treeView = sender as TreeView;
            if (treeView.SelectedNode != null)
            {
                if (treeView.SelectedNode.Checked == true)
                {
                    treeView.SelectedNode.Checked = false;
                }
                else
                {
                    treeView.SelectedNode.Checked = true;
                }
            }
            //Console.WriteLine(treeView.SelectedNode.Text);
            
        }
        
        
        //选择某个墨宝后，从List中添加或删除
        private void treeView_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            isNodeChecked = e.Node.Checked;
            //Console.WriteLine(e.Node.Checked);
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e) 
        {
            if (isNodeChecked == true && e.Node.Checked == false)
            {
                //从选中变成未选中 删除
                //Console.WriteLine($"删除墨宝 {e.Node}");
                RemovePaintingFromQueue(e.Node.Text);
                if (isTimerRunning && isUseMultiSelect==false)
                {
                    CheckQueue();
                    UpdateList();
                    if (isUseReminderForm)
                    {
                        FormSwitch.reminderForm.UpdateForm(reminderList);
                    }
                }
            }
            else if (isNodeChecked == false && e.Node.Checked == true)
            {
                //从未选中变成选中 添加
                //Console.WriteLine($"添加墨宝 {e.Node}");
                AddPaintingToQueue(e.Node.Text);
                if (isTimerRunning && isUseMultiSelect == false)
                {
                    CheckQueue();
                    UpdateList();
                    if (isUseReminderForm)
                    {
                        FormSwitch.reminderForm.UpdateForm(reminderList);
                    }
                }
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Form formHelp = new FormHelp();
            formHelp.Show();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            Form formAbout = new FormAbout();
            formAbout.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Text = "正在保存用户设置文件中... 请不要强行关闭程序!";
            SaveConfig();
            notifyIcon1.Dispose();
        }

        private void checkBoxTimer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTimer.Checked==true)
            {
                isTimerRunning = true;
                timer1.Start();
                CheckQueue();
                UpdateList();
                if (isUseReminderForm)
                {
                    formSwitch.ShowFormSwitch();
                    FormSwitch.reminderForm.UpdateForm(reminderList);
                }
                
            }
            else
            {
                isTimerRunning = false;
                listViewShowQueue.Items.Clear();

                if (isUseReminderForm)
                {
                    formSwitch.HideFormSwitch();
                }
                
                labelNowTime.Text = "未知";
                labelGameTime.Text="未知";
                labelEndTime.Text = "未知";
            }
        }

        private void checkBoxRemind_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRemind.Checked==true)
            {
                isUseBalloon = true;
            }
            else
            {
                isUseBalloon = false;
            }
        }

        private void buttonOpenWebMap_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.wuxiatools.com/map");
        }

        private void checkBoxGame_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGame.Checked == true)
            {
                isUseReminderForm = true;
                formSwitch = new FormSwitch();
                formSwitch.Show();
                CheckQueue();
                FormSwitch.reminderForm.UpdateForm(reminderList);
            }
            else
            {
                isUseReminderForm = false;
                formSwitch.Close();
            }
        }

        private void buttonUseless_Click(object sender, EventArgs e)
        {

            /*
            Random random = new Random();
            int index = random.Next(0, 15);
            Console.WriteLine(index);
            switch (index)
            {
                case 0:
                    MessageBox.Show("都说了这个按钮没用了，你还点我干什么啊？");
                    break;
                case 1:
                    MessageBox.Show("今天有多喝水吗？不要渴了才想着喝水哦~");
                    break;
                case 2:
                    MessageBox.Show("坐在电脑面前时间太长可不好，记得适当休息一下！");
                    break;
                case 3:
                    MessageBox.Show("推塔！推塔啊！我都带兵线过来了……哎？你什么时候进来的！快出去！");
                    break;
                case 4:
                    MessageBox.Show("今天有没有和亲人们问好呢？");
                    break;
                case 5:
                    MessageBox.Show("Zzzzzzzzz……");
                    break;
                case 6:
                    MessageBox.Show("嘘！安静点！我打到决赛圈了！");
                    MessageBox.Show("哎呀都怪你！本来能吃鸡的！");
                    break;
                case 7:
                    MessageBox.Show("听说天刀里有个小师妹？有机会想和她PK一下看看谁更厉害。");
                    break;
                case 8:
                    MessageBox.Show("帮派联盟委任交了吗？师妹行侠游历了吗？每天10个话本盒子拿了吗？活力清干净了吗？没有？没有没事戳我干什么？");
                    break;
                case 9:
                    MessageBox.Show("贴吧又有新的818了，你要不要看看？");
                    break;
                case 10:
                    MessageBox.Show("大象~大象~你的脖子为什么那么长~……！？你是不是听到了！！？？");
                    break;
                case 11:
                    MessageBox.Show("据说骑马读条的时候使用大轻功会飞的很高哦？你试过吗？");
                    break;
                case 12:
                    MessageBox.Show("家园的老管家、拍卖行边上的家园NPC、驻地里的守林人都可以卖掉杂货的~");
                    break;
                case 13:
                    MessageBox.Show("天刀同人Show和微信公众号每周都有蚊子腿奖励，你领过了吗？");
                    break;
                case 14:
                    MessageBox.Show("听说隔壁的小哥哥找了个男朋友？？");
                    break;
                default:
                    MessageBox.Show("自闭中");
                    break;
            }
            */
        }
    }
}
