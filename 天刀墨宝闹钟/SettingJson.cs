using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 天刀墨宝闹钟
{
    public class SettingsJson
    {
        public bool isUseBalloon { get; set; } 
        public bool isTimerRunning { get; set; } 
        public bool isUseReminderForm { get; set; } 
        public Dictionary<string,bool> treeViewDic { get; set; }

    }

    public class SettingsJsondefault
    {
        public static readonly SettingsJson defaultJson = new SettingsJson()
        {
            isTimerRunning = false,
            isUseBalloon = false,
            isUseReminderForm = false,
            treeViewDic = new Dictionary<string, bool>()
                {
                    {"画卷：杭州城", false},
                    {"画卷：一醉轩", false},
                    {"画卷：三潭印月", false},
                    {"画卷：问道台", false},
                    {"画卷：天绝禅院", false},
                    {"画卷：龙井茶园", false},
                    {"画卷：四明书院", false},
                    {"画卷：连环坞", false},
                    {"画卷：长风林", false},
                    {"画卷：天泉日出", false},
                    {"画卷：飞雪滩", false},
                    {"画卷：霹雳堂旧址", false},
                    {"画卷：铸神谷", false},
                    {"画卷：枫桥夜泊", false},
                    {"画卷：桃源道观", false},
                    {"画卷：云泥梯田", false},
                    {"画卷：宁海镇", false},
                    {"画卷：长乐滩", false},
                    {"画卷：桑楚山庄", false},
                    {"画卷：万象门", false},
                    {"画卷：清永民居", false},
                    {"画卷：天香谷", false},
                    {"画卷：乌金汊", false},
                    {"画卷：野鹤湫", false},
                    {"画卷：闽越旧城", false},
                    {"画卷：淬剑清谷", false},
                    {"画卷：风雨钱塘", false},
                    {"画卷：吴王陵", false},
                    {"画卷：百里荡", false},
                    {"画卷：东平郡王府", false},
                    {"画卷：雷峰夕照", false},
                    {"画卷：藏锋谷", false},
                    {"画卷：燕来镇", false},
                    {"画卷：送君廊", false},
                    {"画卷：得意坊", false},
                    {"画卷：化清古佛", false},
                    {"画卷：离魂峡", false},
                    {"画卷：孔雀山庄", false},
                    {"画卷：芳华谷", false},
                    {"画卷：血衣楼", false},
                    {"画卷：血衣禁地", false},
                    {"画卷：平阳驿站", false},
                    {"画卷：藏月客栈", false},
                    {"画卷：古陶镇", false},
                    {"画卷：骅阳林", false},
                    {"画卷：天龙古刹", false},
                    {"画卷：剑绝轩", false},
                    {"画卷：玄刀断剑", false},
                    {"画卷：望断斜阳", false},
                    {"画卷：开封城门", false},
                    {"画卷：护龙河", false},
                    {"画卷：朱仙镇", false},
                    {"画卷：相国寺", false},
                    {"画卷：开封城", false},
                    {"画卷：居士林", false},
                    {"画卷：飞霞渡", false},
                    {"画卷：百鬼夜哭", false},
                    {"画卷：论剑峰", false},
                    {"画卷：药王谷", false},
                    {"画卷：论剑坪", false},
                    {"画卷：鹦哥镇", false},
                    {"画卷：太白山门", false},
                    {"画卷：玉泉院", false},
                    {"画卷：秦川云海", false},
                    {"画卷：万剑沉浮", false},
                    {"画卷：瀚海戈壁", false},
                    {"画卷：神木谷", false},
                    {"画卷：苍梧城", false},
                    {"画卷：风飞谷", false},
                    {"画卷：月下饮马", false},
                    {"画卷：策马坡", false},
                    {"画卷：绝尘马场", false},
                    {"画卷：燕云神威", false},
                    {"画卷：怪石黑风", false},
                    {"画卷：云来镇", false},
                    {"画卷：逢捷镇", false},
                    {"画卷：凌云壁", false},
                    {"画卷：醉月居", false},
                    {"画卷：御风堂", false},
                    {"画卷：万青竹海", false},
                    {"画卷：翠海", false},
                    {"画卷：忘忧谷", false}
                }
        };
    }
}
