using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XORM;
using WatchTest.Model;

namespace WatchTest.DAL
{
    class SandMixSuppDAL
    {
        #region 静态实例
        private static volatile SandMixSuppDAL instance = null;
        private static object lockHelper = new object();

        public static SandMixSuppDAL GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new SandMixSuppDAL();    
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region 新增混砂子表信息
        public static int AddSandMixSupp(SandMixSupp sandmixsupp)
        {
            int result = 0;
            try
            {
                result = DataFactory.UpdateEntity(sandmixsupp, "SandMixSID,Time,Batch,SetCompactability,SandTem,MSetCompactability,FirstWater,Bias,TotalWater,CircleTime,SetStrength,RealStrength,Bentonite,Additive,Support1,Support2,SandWeight,RealCompactability", "MW_SandMixSupp_INS");
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }

        #endregion

        //#region 查询包装最新SID
        //public static int GetSandMixSID()
        //{
        //    List<SandMix> sandmixs = null;
        //    SandMix sandmix = new SandMix();
        //    try
        //    {
        //        packs = DataFactory.FillEntities<Pack>(pack, "", "MW_PackSID_SEL");
        //    }
        //    catch (Exception)
        //    {
        //        packs = new List<Pack>();
        //    }
        //    return packs[0].PackSID;
        //}

        //#endregion

        //#region 更新包装信息
        //public static int UpdPack(Pack pack)
        //{
        //    int result = 0;
        //    try
        //    {
        //        result = DataFactory.UpdateEntity(pack
        //            , "PackSID,PackNum,PackTotalNum,PackEndTime", "MW_Pack_UPD");
        //    }
        //    catch (Exception)
        //    {
        //        result = 0;
        //    }
        //    return result;
        //}

        //#endregion
    }
}
