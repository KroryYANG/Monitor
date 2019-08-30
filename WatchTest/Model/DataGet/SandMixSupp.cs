using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XORM;

namespace WatchTest.Model
{
    class SandMixSupp
    {
        [ColumnMapping("SandMixSID", "-1")]     //对应主表SID
        public int SandMixSID { get; set; }

        [ColumnMapping("Time", "9999-12-31")]       //时间
        public DateTime Time { get; set; }

        [ColumnMapping("Batch", "-1")]     //批次
        public int Batch { get; set; }

        [ColumnMapping("SetCompactability", "-1")]       //设定紧实率
        public double SetCompactability { get; set; }

        [ColumnMapping("SandTem", "-1")]          //旧沙温度
        public double SandTem { get; set; }

        [ColumnMapping("MSetCompactability", "-1")]  //补偿紧实率
        public double MSetCompactability { get; set; }

        [ColumnMapping("FirstWater", "-1")]          //第一次加水量
        public int FirstWater { get; set; }

        [ColumnMapping("Bias", "-1")]          //偏差（有正负之分）
        public double Bias { get; set; }

        [ColumnMapping("TotalWater", "-1")]          //总加水量
        public int TotalWater { get; set; }

        [ColumnMapping("CircleTime", "-1")]          //循环时间
        public int CircleTime { get; set; }

        [ColumnMapping("SetStrength", "-1")]          //强度设定值
        public int SetStrength { get; set; }

        [ColumnMapping("RealStrength", "-1")]          //实际强度值
        public int RealStrength { get; set; }

        [ColumnMapping("Bentonite", "-1")]          //膨润土量
        public double Bentonite { get; set; }

        [ColumnMapping("Additive", "-1")]          //综合添加剂
        public double Additive { get; set; }

        [ColumnMapping("Support1", "-1")]          //其他辅料1
        public double Support1 { get; set; }

        [ColumnMapping("Support2", "-1")]          //其他辅料2
        public double Support2 { get; set; }

        [ColumnMapping("SandWeight", "-1")]          //旧沙重量
        public int SandWeight { get; set; }

        [ColumnMapping("RealCompactability", "-1")]          //实际紧实率
        public double RealCompactability { get; set; }

        [ColumnMapping("SandMixRemark", "")]          //备注
        public string SandMixRemark { get; set; }

    }
}
