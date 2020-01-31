using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintingDate
{
    //队列中的元素
    public class QueueElement
    {
        public string paintingName;
        public string[] timeArray;
        public bool isUsable;
        public string mapName;
    }

    //时间表的元素
    class TimeFrame
    {
        public TimeSpan startTime;
        public TimeSpan endTime;
        public string timeName;
        public TimeFrame(TimeSpan start, TimeSpan end, string name)
        {
            startTime = start;
            endTime = end;
            timeName = name;
        }
    }

    //时钟事件里存时间的
    class TimeHMS 
    {
        public int hour;
        public int minute;
        public int second;
        public TimeHMS(int h,int m,int s)
        {
            hour = h;
            minute = m;
            second = s;
        }
    }

    //查表的返回值
    class TimeResult
    {
        public string timeName;
        public string endTime;
    }

    //地图时辰对应表
    class TimeAndMapName
    {
        public string[] timeList;
        public string mapName;
        public TimeAndMapName(string[] t, string m)
        {
            timeList = t;
            mapName = m;
        }
    }

    class ChinaTime
    {
        public static ChinaTimeTable chinaTimeTable = new ChinaTimeTable();
        public static TimeResult GetChinaTime(int x,int y, int z) 
        {
            return chinaTimeTable.PrviateGetChinaTime(x, y, z);
        }

        public static string GetChinaTimeDayOrNight(int x,int y,int z)
        {
            return chinaTimeTable.PrivateGetChinaTimeDayOrNight(x, y, z);
        }
    }

    class ChinaTimeTable
    {
        public ChinaTimeTable()
        {
            timeListAll = new List<List<TimeFrame>> { timeList1, timeList2, timeList3, timeList4, timeList5, timeList6 };
        }
        public TimeResult PrviateGetChinaTime(int x, int y, int z)
        {
            TimeSpan timeNow = new TimeSpan(x, y, z);
            int listIndex = -1;
            TimeResult result = new TimeResult() {timeName= "未查询到对应时间" };

            foreach (var item in timeListRough)
            {
                if (item.startTime<=timeNow && timeNow<=item.endTime)
                {
                    listIndex = Convert.ToInt32(item.timeName);
                    break;
                }
            }

            if (listIndex==-1)
            {
                Console.WriteLine($"意外的时间信息：{timeNow.ToString()}");
            }
            else
            {
                foreach (var item in timeListAll[listIndex])
                {
                    if (item.startTime <= timeNow && timeNow <= item.endTime)
                    {
                        result.timeName = item.timeName;
                        result.endTime = item.endTime.ToString();
                        if (result.endTime== "23:59:59")
                        {
                            result.endTime = "0:2:23";
                        }
                        break;
                    }
                }
            }
            return result;
        }

        public string PrivateGetChinaTimeDayOrNight(int x,int y,int z)
        {
            TimeSpan timeNow = new TimeSpan(x, y, z);
            string result = "未查询到对应时间" ;

            foreach (var item in timeListDayandNight)
            {
                if (item.startTime <= timeNow && timeNow <= item.endTime)
                {
                    result = item.timeName;
                    break;
                }
            }

            return result;
        }

        //偷懒的生成TimeSpan的方法
        public static TimeSpan CTS(int t1,int t2,int t3) 
        {
            return new TimeSpan(t1, t2, t3);
        }

        //六个时间段的开始时间和结束时间
        public static List<TimeFrame> timeListRough = new List<TimeFrame>
        {
            new TimeFrame(CTS(0,0,0),CTS(4,2,23),"0"),
            new TimeFrame(CTS(4,2,24),CTS(8,2,23),"1"),
            new TimeFrame(CTS(8,2,24),CTS(12,2,23),"2"),
            new TimeFrame(CTS(12,2,24),CTS(16,2,23),"3"),
            new TimeFrame(CTS(16,2,24),CTS(20,2,23),"4"),
            new TimeFrame(CTS(20,2,24),CTS(23,59,59),"5"),
        };

        //把六个时间段装到一个List里面方便切换
        public static List<List<TimeFrame>> timeListAll;

        //具体的六个时间段
        public static List<TimeFrame> timeList1 = new List<TimeFrame>
        {
            new TimeFrame (CTS(0,0,0),CTS(0,2,23),"午时"),
            new TimeFrame (CTS(0,2,24),CTS(0,16,47),"未时"),
            new TimeFrame (CTS(0,16,48),CTS(1,2,23),"申时"),
            new TimeFrame (CTS(1,2,24),CTS(1,35,59),"酉时"),
            new TimeFrame (CTS(1,36,0),CTS(1,55,11),"戌时"),
            new TimeFrame (CTS(1,55,12),CTS(2,4,47),"亥时"),
            new TimeFrame (CTS(2,4,48),CTS(2,9,35),"子时"),
            new TimeFrame (CTS(2,9,36),CTS(2,16,47),"丑时"),
            new TimeFrame (CTS(2,16,48),CTS(2,26,23),"寅时"),
            new TimeFrame (CTS(2,26,24),CTS(2,50,23),"卯时"),
            new TimeFrame (CTS(2,50,24),CTS(3,31,11),"辰时"),
            new TimeFrame (CTS(3,31,12),CTS(3,55,11),"巳时"),
            new TimeFrame (CTS(3,55,12),CTS(4,2,23),"午时"),
        };

        public static List<TimeFrame> timeList2 = new List<TimeFrame>
        {
            new TimeFrame (CTS(4,2,24),CTS(4,16,47),"未时"),
            new TimeFrame (CTS(4,16,48),CTS(5,2,23),"申时"),
            new TimeFrame (CTS(5,2,24),CTS(5,35,59),"酉时"),
            new TimeFrame (CTS(5,36,0),CTS(5,55,11),"戌时"),
            new TimeFrame (CTS(5,55,12),CTS(6,4,47),"亥时"),
            new TimeFrame (CTS(6,4,48),CTS(6,9,35),"子时"),
            new TimeFrame (CTS(6,9,36),CTS(6,16,47),"丑时"),
            new TimeFrame (CTS(6,16,48),CTS(6,26,23),"寅时"),
            new TimeFrame (CTS(6,26,24),CTS(6,50,23),"卯时"),
            new TimeFrame (CTS(6,50,24),CTS(7,31,11),"辰时"),
            new TimeFrame (CTS(7,31,12),CTS(7,55,11),"巳时"),
            new TimeFrame (CTS(7,55,12),CTS(8,2,23),"午时"),
        };

        public static List<TimeFrame> timeList3 = new List<TimeFrame>
        {
            new TimeFrame (CTS(8,2,24),CTS(8,16,47),"未时"),
            new TimeFrame (CTS(8,16,48),CTS(9,2,23),"申时"),
            new TimeFrame (CTS(9,2,24),CTS(9,35,59),"酉时"),
            new TimeFrame (CTS(9,36,0),CTS(9,55,11),"戌时"),
            new TimeFrame (CTS(9,55,12),CTS(10,4,47),"亥时"),
            new TimeFrame (CTS(10,4,48),CTS(10,9,35),"子时"),
            new TimeFrame (CTS(10,9,36),CTS(10,16,47),"丑时"),
            new TimeFrame (CTS(10,16,48),CTS(10,26,23),"寅时"),
            new TimeFrame (CTS(10,26,24),CTS(10,50,23),"卯时"),
            new TimeFrame (CTS(10,50,24),CTS(11,31,11),"辰时"),
            new TimeFrame (CTS(11,31,12),CTS(11,55,11),"巳时"),
            new TimeFrame (CTS(11,55,12),CTS(12,2,23),"午时"),
        };

        public static List<TimeFrame> timeList4 = new List<TimeFrame>
        {
            new TimeFrame (CTS(12,2,24),CTS(12,16,47),"未时"),
            new TimeFrame (CTS(12,16,48),CTS(13,2,23),"申时"),
            new TimeFrame (CTS(13,2,24),CTS(13,35,59),"酉时"),
            new TimeFrame (CTS(13,36,0),CTS(13,55,11),"戌时"),
            new TimeFrame (CTS(13,55,12),CTS(14,4,47),"亥时"),
            new TimeFrame (CTS(14,4,48),CTS(14,9,35),"子时"),
            new TimeFrame (CTS(14,9,36),CTS(14,16,47),"丑时"),
            new TimeFrame (CTS(14,16,48),CTS(14,26,23),"寅时"),
            new TimeFrame (CTS(14,26,24),CTS(14,50,23),"卯时"),
            new TimeFrame (CTS(14,50,24),CTS(15,31,11),"辰时"),
            new TimeFrame (CTS(15,31,12),CTS(15,55,11),"巳时"),
            new TimeFrame (CTS(15,55,12),CTS(16,2,23),"午时"),
        };

        public static List<TimeFrame> timeList5 = new List<TimeFrame>
        {
            new TimeFrame (CTS(16,2,24),CTS(16,16,47),"未时"),
            new TimeFrame (CTS(16,16,48),CTS(17,2,23),"申时"),
            new TimeFrame (CTS(17,2,24),CTS(17,35,59),"酉时"),
            new TimeFrame (CTS(17,36,0),CTS(17,55,11),"戌时"),
            new TimeFrame (CTS(17,55,12),CTS(18,4,47),"亥时"),
            new TimeFrame (CTS(18,4,48),CTS(18,9,35),"子时"),
            new TimeFrame (CTS(18,9,36),CTS(18,16,47),"丑时"),
            new TimeFrame (CTS(18,16,48),CTS(18,26,23),"寅时"),
            new TimeFrame (CTS(18,26,24),CTS(18,50,23),"卯时"),
            new TimeFrame (CTS(18,50,24),CTS(19,31,11),"辰时"),
            new TimeFrame (CTS(19,31,12),CTS(19,55,11),"巳时"),
            new TimeFrame (CTS(19,55,12),CTS(20,2,23),"午时"),
        };

        public static List<TimeFrame> timeList6 = new List<TimeFrame>
        {
            new TimeFrame (CTS(20,2,24),CTS(20,16,47),"未时"),
            new TimeFrame (CTS(20,16,48),CTS(21,2,23),"申时"),
            new TimeFrame (CTS(21,2,24),CTS(21,35,59),"酉时"),
            new TimeFrame (CTS(21,36,0),CTS(21,55,11),"戌时"),
            new TimeFrame (CTS(21,55,12),CTS(22,4,47),"亥时"),
            new TimeFrame (CTS(22,4,48),CTS(22,9,35),"子时"),
            new TimeFrame (CTS(22,9,36),CTS(22,16,47),"丑时"),
            new TimeFrame (CTS(22,16,48),CTS(22,26,23),"寅时"),
            new TimeFrame (CTS(22,26,24),CTS(22,50,23),"卯时"),
            new TimeFrame (CTS(22,50,24),CTS(23,31,11),"辰时"),
            new TimeFrame (CTS(23,31,12),CTS(23,55,11),"巳时"),
            new TimeFrame (CTS(23,55,12),CTS(23,59,59),"午时"),
        };

        //白昼黑夜的特殊时间段
        public static List<TimeFrame> timeListDayandNight = new List<TimeFrame>
        {
            new TimeFrame (CTS(0,0,0),CTS(1,20,59),"白昼"),
            new TimeFrame (CTS(1,21,0),CTS(2,35,59),"黑夜"),
            new TimeFrame (CTS(2,36,0),CTS(5,20,59),"白昼"),
            new TimeFrame (CTS(5,21,0),CTS(6,35,59),"黑夜"),
            new TimeFrame (CTS(6,36,0),CTS(9,20,59),"白昼"),
            new TimeFrame (CTS(9,21,0),CTS(10,35,59),"黑夜"),
            new TimeFrame (CTS(10,36,0),CTS(13,20,59),"白昼"),
            new TimeFrame (CTS(13,21,0),CTS(14,35,59),"黑夜"),
            new TimeFrame (CTS(14,36,0),CTS(17,20,59),"白昼"),
            new TimeFrame (CTS(17,21,0),CTS(18,35,59),"黑夜"),
            new TimeFrame (CTS(18,36,0),CTS(21,20,59),"白昼"),
            new TimeFrame (CTS(21,21,0),CTS(22,35,59),"黑夜"),
            new TimeFrame (CTS(22,36,0),CTS(23,59,59),"白昼"),
        };
    }
}
