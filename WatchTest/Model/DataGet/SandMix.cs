using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XORM;

namespace WatchTest.Model
{
    public class SandMix
    {
        [ColumnMapping("SandMixSID", "-1")]           //混砂主表SID
        public int SandMixSID { get; set; }


    }
}
