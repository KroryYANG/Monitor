using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XORM;
using WatchTest.Model;

namespace WatchTest.DAL
{
    class SandMixDAL
    {
        #region 静态实例
        private static volatile SandMixDAL instance = null;
        private static object lockHelper = new object();

        public static SandMixDAL GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new SandMixDAL();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion


        #region 查询混砂主表SID
        public static int GetSandMixSID()
        {
            List<SandMix> sandmixs = null;
            SandMix sandmix = new SandMix();
            try
            {
                sandmixs = DataFactory.FillEntities<SandMix>(sandmix, "", "MW_SandMixSID_SEL");
            }
            catch (Exception)
            {
                sandmixs = new List<SandMix>();
            }
            return sandmixs[0].SandMixSID;
        }

        #endregion

       
    }
}
