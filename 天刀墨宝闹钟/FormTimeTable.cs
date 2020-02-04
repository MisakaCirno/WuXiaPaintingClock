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
    public partial class FormTimeTable : Form
    {
        //六个时间段，用于动态生成label
        string[] timeListDay1 = new string[]
        {
            "02:04:48—02:09:35",
            "02:09:36—02:16:47",
            "02:16:48—02:26:23",
            "02:26:24—02:50:23",
            "02:50:24—03:31:11",
            "03:31:12—03:55:11",
            "03:55:12—04:02:23",
            "04:02:24—04:16:47",
            "04:16:48—05:02:23",
            "05:02:24—05:35:59",
            "05:36:00—05:55:11",
            "05:55:12—06:04:47"
        };
        string[] timeListDay2 = new string[]
        {
            "06:04:48—06:09:35",
            "06:09:36—06:16:47",
            "06:16:48—06:26:23",
            "06:26:24—06:50:23",
            "06:50:24—07:31:11",
            "07:31:12—07:55:11",
            "07:55:12—08:02:23",
            "08:02:24—08:16:47",
            "08:16:48—09:02:23",
            "09:02:24—09:35:59",
            "09:36:00—09:55:11",
            "09:55:12—10:04:47"
        };
        string[] timeListDay3 = new string[]
        {
            "10:04:48—10:09:35",
            "10:09:36—10:16:47",
            "10:16:48—10:26:23",
            "10:26:24—10:50:23",
            "10:50:24—11:31:11",
            "11:31:12—11:55:11",
            "11:55:12—12:02:23",
            "12:02:24—12:16:47",
            "12:16:48—13:02:23",
            "13:02:24—13:35:59",
            "13:36:00—13:55:11",
            "13:55:12—14:04:47"
        };
        string[] timeListDay4 = new string[]
        {
            "14:04:48—14:09:35",
            "14:09:36—14:16:47",
            "14:16:48—14:26:23",
            "14:26:24—14:50:23",
            "14:50:24—15:31:11",
            "15:31:12—15:55:11",
            "15:55:12—16:02:23",
            "16:02:24—16:16:47",
            "16:16:48—17:02:23",
            "17:02:24—17:35:59",
            "17:36:00—17:55:11",
            "17:55:12—18:04:47"
        };
        string[] timeListDay5 = new string[]
        {
            "18:04:48—18:09:35",
            "18:09:36—18:16:47",
            "18:16:48—18:26:23",
            "18:26:24—18:50:23",
            "18:50:24—19:31:11",
            "19:31:12—19:55:11",
            "19:55:12—20:02:23",
            "20:02:24—20:16:47",
            "20:16:48—21:02:23",
            "21:02:24—21:35:59",
            "21:36:00—21:55:11",
            "21:55:12—22:04:47"
        };
        string[] timeListDay6 = new string[]
        {
            "22:04:48—22:09:35",
            "22:09:36—22:16:47",
            "22:16:48—22:26:23",
            "22:26:24—22:50:23",
            "22:50:24—23:31:11",
            "23:31:12—23:55:11",
            "23:55:12—00:02:23",
            "00:02:24—00:16:47",
            "00:16:48—01:02:23",
            "01:02:24—01:35:59",
            "01:36:00—01:55:11",
            "01:55:12—02:04:47"
        };
        List<string[]> timeListAll;

        //存储label，方便修改
        List<Label> labelDay1 = new List<Label>();
        List<Label> labelDay2 = new List<Label>();
        List<Label> labelDay3 = new List<Label>();
        List<Label> labelDay4 = new List<Label>();
        List<Label> labelDay5 = new List<Label>();
        List<Label> labelDay6 = new List<Label>();
        List<List<Label>> labelDayAll;

        //存所有的板子
        List<FlowLayoutPanel> allFLP;
        //标题的Label
        List<Label> titleLabelAll;
        //十二时辰对应索引
        Dictionary<string, int> twelveTime = new Dictionary<string, int>
        {
            { "子时",0 },
            { "丑时",1 },
            { "寅时",2 },
            { "卯时",3 },
            { "辰时",4 },
            { "巳时",5 },
            { "午时",6 },
            { "未时",7 },
            { "申时",8 },
            { "酉时",9 },
            { "戌时",10 },
            { "亥时",11 },
            { "白昼",-1 },
            { "黑夜",-2 }

        };
        //十二时辰是否存在对应hashset
        HashSet<string> isHasTime = new HashSet<string>();

        Font fontNormal = new Font("宋体",12) ;
        Font fontBold = new Font("宋体", 12, FontStyle.Bold);

        List<Label> modifiedTimeLabels = new List<Label>();
        Label modifiedTitleLabel;
        Label modifiedMarkLabel;
        FlowLayoutPanel modifiedFLP;

        bool isFirstLoad = true;

        public FormTimeTable()
        {
            InitializeComponent();
            Icon = Properties.Resources.Clock;

            timeListAll = new List<string[]>
            {
                timeListDay1,
                timeListDay2,
                timeListDay3,
                timeListDay4,
                timeListDay5,
                timeListDay6
            };

            labelDayAll = new List<List<Label>>
            {
                labelDay1,
                labelDay2,
                labelDay3,
                labelDay4,
                labelDay5,
                labelDay6
            };

            titleLabelAll = new List<Label>
            {
                labelTitle1,
                labelTitle2,
                labelTitle3,
                labelTitle4,
                labelTitle5,
                labelTitle6
            };

            allFLP = new List<FlowLayoutPanel>
            {
                flowLayoutPanelDay1,
                flowLayoutPanelDay2,
                flowLayoutPanelDay3,
                flowLayoutPanelDay4,
                flowLayoutPanelDay5,
                flowLayoutPanelDay6
            };

            
        }

        private void FormTimeTable_Load(object sender, EventArgs e)
        {
            CreateAndAddLabels();
            ReadQueue();
            UpdateForm();
            isFirstLoad = false;
        }

        private void CreateAndAddLabels()
        {
            for (int i = 0; i < 6; i++)
            {
                foreach (var timeString in timeListAll[i])
                {
                    Label newLabel = new Label()
                    {
                        Margin = new Padding(5, 5, 5, 5),
                        Size = new Size(160, 18),//160 16
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = fontNormal,
                        ForeColor = Color.Black,
                        Text = timeString
                    };
                    allFLP[i].Controls.Add(newLabel);
                    labelDayAll[i].Add(newLabel);
                }
            }
        }

        private void ReadQueue()
        {
            //获取全部时辰数据
            isHasTime.Clear();
            foreach (var painting in FormMain.paintingQueue)
            {
                foreach (var item in painting.Value.timeArray)
                {
                    if (isHasTime.Contains(item)==false)
                    {
                        isHasTime.Add(item);
                    }
                }
            }
        }

        //修改具体时辰、昼夜标签
        private void ChangeTimeLabel()
        {
            foreach (var item in isHasTime)
            {
                if (twelveTime[item]==-1) //白昼
                {
                    labelTimeDay.ForeColor = Color.DeepPink;
                    modifiedTimeLabels.Add(labelTimeDay);
                }
                else if (twelveTime[item] == -2) //黑夜
                {
                    labelTimeNight1.ForeColor = Color.DeepPink;
                    labelTimeNight2.ForeColor = Color.DeepPink;
                    modifiedTimeLabels.Add(labelTimeNight1);
                    modifiedTimeLabels.Add(labelTimeNight2);
                }
                else
                {
                    int index = twelveTime[item]; //十二时辰
                    foreach (var labels in labelDayAll)
                    {
                        labels[index].ForeColor = Color.DeepPink;
                        modifiedTimeLabels.Add(labels[index]);
                    }
                }
            }
        }
        
        //修改游戏日标题标签
        private void ChangeTitleLabel(int index)
        {
            index--;
            titleLabelAll[index].Font = fontBold;
            titleLabelAll[index].ForeColor = Color.DeepPink;
            titleLabelAll[index].BackColor = Color.LightCyan;
            modifiedTitleLabel = titleLabelAll[index];
        }

        //修改FLP样式
        private void ChangeFLP(int index)
        {
            index--;
            allFLP[index].BackColor = Color.LightCyan;
            modifiedFLP = allFLP[index];
        }

        //标记现在的时间
        private void MarkNowTime(int index)
        {
            Label label = labelDayAll[index-1][twelveTime[FormMain.nowChinaTime]];
            label.BorderStyle = BorderStyle.FixedSingle;
            modifiedMarkLabel = label;
        }

        public void UpdateForm()
        {
            //重置所有部件
            ResetAllControls();
            //获取当前游戏日次序
            int index = GameDayTimeData.GetNowGameDay();
            if (index==-1)
            {
                return;
            }
            //读取队列
            ReadQueue();
            //修改标题标签样式
            ChangeTitleLabel(index);
            //修改FLP样式
            ChangeFLP(index);
            //标记当前所在时间
            MarkNowTime(index);
            //点亮所有标签
            ChangeTimeLabel();
        }

        private void ResetAllControls()
        {
            if (isFirstLoad)
            {
                return;
            }

            //重置时间标签
            if (modifiedTimeLabels!=null)
            {
                foreach (var label in modifiedTimeLabels)
                {
                    label.ForeColor = Color.Black;
                    label.Font = fontNormal;
                }
            }

            //重置标记时间标签
            if (modifiedMarkLabel!=null)
            {
                modifiedMarkLabel.BorderStyle = BorderStyle.None;
            }

            //重置FLP
            if (modifiedFLP!=null)
            {
                modifiedFLP.BackColor = Color.White;
            }

            //重置标题标签
            if (modifiedTitleLabel!=null)
            {
                modifiedTitleLabel.BackColor = Color.White;
                modifiedTitleLabel.ForeColor = Color.Black;
                modifiedTitleLabel.Font = fontNormal;
            }
        }

        private void FormTimeTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.isShowTimeTableForm = false;
        }

        private void labelShiChen_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "【游戏时间解释】\r\n"+
                "1个现实日等于6个游戏日，每个游戏日有12个时辰，每个时辰代表游戏日的两小时。\r\n" +
                "例如：\r\n" +
                "子时为游戏时间23: 00:00~00:59:59；丑时为游戏时间01: 00:00~02:59:59……\r\n" +
                "其余时辰以此类推。\r\n" +
                "\r\n" +
                "白昼为游戏时间06: 00:00~17:59:59；黑夜为游戏时间18: 00：00~05:59:59。\r\n" +
                "因此白昼起于卯时，终于酉时；黑夜起于酉时，终于卯时。右侧的昼夜的方框的位置蕴含着这一信息。\r\n" +
                "\r\n" +
                "【窗口信息解释】\r\n" +
                "1.浅蓝色底色：代表现在现实时间所对应游戏时间；\r\n" +
                "2.粉色高亮字体：代表在此时间段内有可以绘制的书画；\r\n" +
                "3.框选时间段：代表现在显示时间所对应游戏时间的时间段。\r\n", 
                "使用帮助");
        }
    }
    class GameDayTimeData
    {
        //偷懒的生成TimeSpan的方法
        public static TimeSpan CTS(int t1, int t2, int t3)
        {
            return new TimeSpan(t1, t2, t3);
        }

        public static int GetNowGameDay()
        {
            TimeSpan timeNow = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            foreach (var item in GameDay)
            {
                if (item.startTime <= timeNow && timeNow <= item.endTime)
                {
                    return item.dayNumber;
                }
            }
            return -1;
        }

        class TimeFrame
        {
            public TimeSpan startTime;
            public TimeSpan endTime;
            public int dayNumber;
            public TimeFrame(TimeSpan s,TimeSpan e, int d)
            {
                startTime = s;
                endTime = e;
                dayNumber = d;
            }
        }

        static List<TimeFrame> GameDay = new List<TimeFrame>
        {
            new TimeFrame(CTS(02,04,48),CTS(06,04,47),1),
            new TimeFrame(CTS(06,04,48),CTS(10,04,47),2),
            new TimeFrame(CTS(10,04,48),CTS(14,04,47),3),
            new TimeFrame(CTS(14,04,48),CTS(18,04,47),4),
            new TimeFrame(CTS(18,04,48),CTS(22,04,47),5),
            new TimeFrame(CTS(22,04,48),CTS(23,59,59),6),
            new TimeFrame(CTS(00,00,00),CTS(02,04,47),6)
        };
    }
}
