﻿using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHighWay.WatchHouse.EFModel;
using JXHighWay.WatchHouse.Net;
using JXHighWay.WatchHouse.Net.DataPack;
using JXHighWay.WatchHouse.Helper;
using System.Threading;
using System.Data;

namespace JXHighWay.WatchHouse.Bll.Client.DianYuan
{
    public class PowerMonitoring:BasicMonitoring
    {

        public PowerMonitoring()
        {

        }

        #region 命令
        /// <summary>
        /// 分路开关参数配置
        /// </summary>
        /// <param name="DianYuanID"></param>
        /// <param name="SheBieLX"></param>
        /// <param name="LuHao"></param>
        /// <param name="BiaoShiMa"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task<bool> SendCMD_SwitchParam(int DianYuanID, byte SheBieLX, byte LuHao, 
            PowerDataPack_Send_SwitchParam_CommandEnum BiaoShiMa,short Data)
        {
            PowerDataPack_Send_SwitchParam vData = new PowerDataPack_Send_SwitchParam()
            {
                BiaoShiMa = (byte)BiaoShiMa,
                LeiXing = SheBieLX,
                LuHao = LuHao,
                Data1 = (byte)(Data >> 8),
                Data2 = (byte)(Data >> 0)
            };
            bool vResult = await asyncSendCommandToDB(DianYuanID, PowerDataPack_Send_CommandEnum.Send_Switch, vData);
            if(vResult)
            {
                PowerSwithConfigEFModel vPowerSwithConfigEFModel = new PowerSwithConfigEFModel();
                switch(BiaoShiMa)
                {
                    case PowerDataPack_Send_SwitchParam_CommandEnum.ChaoWenBHZ:
                        vPowerSwithConfigEFModel.ChaoWenBHZ = Data;
                        break;
                    case PowerDataPack_Send_SwitchParam_CommandEnum.ChaoWenYJZ:
                        vPowerSwithConfigEFModel.ChaoWenYJZ = Data;
                        break;
                    case PowerDataPack_Send_SwitchParam_CommandEnum.DianLiuLLZ:
                        vPowerSwithConfigEFModel.DianLiuLLZ = Data;
                        break;
                    case PowerDataPack_Send_SwitchParam_CommandEnum.EDingLDDZDL:
                        vPowerSwithConfigEFModel.EDingLDDZDL = Data;
                        break;
                    case PowerDataPack_Send_SwitchParam_CommandEnum.GuoYaSX:
                        vPowerSwithConfigEFModel.GuoYaSX = Data;
                        break;
                    case PowerDataPack_Send_SwitchParam_CommandEnum.LouDianLYJZ:
                        vPowerSwithConfigEFModel.LouDianLYJZ = Data;
                        break;
                    case PowerDataPack_Send_SwitchParam_CommandEnum.QianYaXX:
                        vPowerSwithConfigEFModel.QianYaXX = Data;
                        break;
                    case PowerDataPack_Send_SwitchParam_CommandEnum.XianDingDN:
                        vPowerSwithConfigEFModel.XianDingDN = Data;
                        break;
                    case PowerDataPack_Send_SwitchParam_CommandEnum.XianDingGL:
                        vPowerSwithConfigEFModel.XianDingGL = Data;
                        break;
                }
                m_BasicDBClassUpdate.UpdateRecord(vPowerSwithConfigEFModel,string.Format( "DianYuanID={0} and LuHao{1}",DianYuanID,LuHao));
            }
            return vResult;
        }

        /// <summary>
        /// 控制分路开关
        /// </summary>
        /// <param name="DianYuanID">电源ID</param>
        /// <param name="SheBieLX">设备类型</param>
        /// <param name="LuHao">路号</param>
        /// <param name="IsOn">开或关</param>
        /// <returns></returns>
        public async Task<bool> SendCMD_Switch(int DianYuanID, byte SheBieLX, byte LuHao, bool IsOn)
        {
            PowerDataPack_Send_Switch vData = new PowerDataPack_Send_Switch()
            {
                LuHao = LuHao,
                SheBeiLX = SheBieLX,
                Switch = IsOn ? (byte)0x01 : (byte)0x00
            };
            bool vResult = await asyncSendCommandToDB(DianYuanID, PowerDataPack_Send_CommandEnum.Send_Switch, vData);
            return vResult;
        }

        /// <summary>
        /// 定时控制
        /// </summary>
        /// <param name="DianYuanID">电源ID</param>
        /// <param name="SheBieLX">设备类型</param>
        /// <param name="LuHao">路号</param>
        /// <param name="ZhuHao">组号</param>
        /// <param name="RenWuLX">任务类型</param>
        /// <param name="ZhouQi">周期</param>
        /// <param name="YunXuKZ">允许控制</param>
        /// <param name="TimeData">时间数据</param>
        /// <returns></returns>
        public async Task<bool> SendCMD_Timing(int DianYuanID, byte SheBieLX, byte LuHao,
            byte ZhuHao,byte RenWuLX,byte ZhouQi,byte YunXuKZ,int TimeData  )
        {
            PowerDataPack_Send_Timing vData = new PowerDataPack_Send_Timing()
            {
                LuHao = LuHao,
                LeiXing = SheBieLX,
                RenWuLX = RenWuLX,
                YunXuKZ = YunXuKZ,
                ZhouQi = ZhouQi,
                ZhuHao = ZhuHao
            };
            switch ( RenWuLX )
            {
                //单次
                case 0x00:
                    vData.TimeData1 = (byte)(TimeData >> 24);
                    vData.TimeData2 = (byte)(TimeData >> 16);
                    vData.TimeData3 = (byte)(TimeData >> 8);
                    vData.TimeData4 = (byte)(TimeData >> 0);
                    break;
                //每天
                case 0x01:
                    vData.TimeData1 = 0x00;
                    vData.TimeData2 = 0x00;
                    vData.TimeData3 = (byte)(TimeData >> 8);
                    vData.TimeData4 = (byte)(TimeData >> 0);
                    break;
                //每周
                case 0x02:
                    vData.TimeData1 = 0x00;
                    vData.TimeData2 = (byte)(TimeData >> 16);
                    vData.TimeData3 = (byte)(TimeData >> 8);
                    vData.TimeData4 = (byte)(TimeData >> 0);
                    break;
                //每月
                case 0x03:
                    vData.TimeData1 = 0x00;
                    vData.TimeData2 = (byte)(TimeData >> 16);
                    vData.TimeData3 = (byte)(TimeData >> 8);
                    vData.TimeData4 = (byte)(TimeData >> 0);
                    break;
            }

            bool vResult = await asyncSendCommandToDB(DianYuanID, PowerDataPack_Send_CommandEnum.Send_Switch, vData);
            if ( vResult )
            {
                PowerTimingEFModel vPowerTimingEFModel = new PowerTimingEFModel()
                {
                    DianYuanID = DianYuanID,
                    LeiXing = SheBieLX,
                    LuHao = LuHao,
                    RenWuLX = RenWuLX,
                    TimeData = TimeData,
                    YunXuKZ = YunXuKZ,
                    ZhouQi = ZhouQi,
                    ZhuHao = ZhuHao
                };
                vResult = m_BasicDBClass.InsertRecord(vPowerTimingEFModel) > 0 ? true : false;
            }
            return vResult;
        }

        async Task<bool> asyncSendCommandToDB<T>(int dianYuanID, PowerDataPack_Send_CommandEnum command, T SendData)
        {
            return await Task.Run(() =>
            {
                string vDataStr = System.Text.Encoding.Default.GetString(NetHelper.StructureToByte(SendData));
                PowerSendCMDEFModel vSendCMDEFModel = new PowerSendCMDEFModel()
                {
                    State = false,
                    IsSend = false,
                    IsReply = false,
                    CMD = (byte)command,
                    DianYuanID = dianYuanID,
                    SendTime = DateTime.Now,
                    SN = NetHelper.MarkSN_Byte(),
                    Data = vDataStr
                };
                int vID = m_BasicDBClassInsert.InsertRecord(vSendCMDEFModel);

                DateTime vStartTime = DateTime.Now;
                bool vResult = false;
                do
                {
                    PowerSendCMDEFModel vSelectResult = m_BasicDBClass.SelectRecordByPrimaryKeyEx<PowerSendCMDEFModel>(vID);
                    vResult = vSelectResult.State ?? false;
                    if (!vResult && (DateTime.Now - vStartTime).TotalMilliseconds >= 2000)
                        break;
                    Thread.Sleep(200);
                } while (!vResult);
                //m_BasicDBClass.DeleteRecordByPrimaryKey<PowerSendCMDEFModel>(vID);
                return vResult;
            });
        }
        #endregion


        public PowerInfo[] GetPowerLuSu( int DianYuanID)
        {
            PowerSwithConfigEFModel vPowerSwithConfigEFModel = new PowerSwithConfigEFModel()
            {
                DianYuanID = DianYuanID
            };
            PowerSwithConfigEFModel[] vSelectResult = m_BasicDBClass.SelectRecordsEx(vPowerSwithConfigEFModel);
            PowerInfo[] vResult = new PowerInfo[vSelectResult.Length];

            for (int i = 0; i < vSelectResult.Length; i++)
            {
                vResult[i] = new PowerInfo()
                {
                    LuHao = vSelectResult[i].LuHao ?? 0,
                    MingCheng = vSelectResult[i].MinCheng
                };
            }
            
            return vResult;
        }

        #region 获取用电量数据
        /// <summary>
        /// 获取某路开关的用电量(月)
        /// </summary>
        /// <param name="DianYuanID">电源ID</param>
        /// <param name="LuHao">路号</param>
        /// <returns></returns>
        public PowerInfo[] GetYongDianLiang_Yue(int DianYuanID, int LuHao)
        {
            PowerInfo[] vResult = null;
            DateTime vKaiShiSJ = DateTime.Now.AddDays(-7);
            DateTime vJieShuSJ = DateTime.Now;
            string vSql = string.Format("Select MAX(DianNeng) as DianNeng,Time From `电源数据` where unix_timestamp( Time ) "
                + "between unix_timestamp( '{0:yyyy-MM-dd 00:00:00}') and unix_timestamp('{1:yyyy-MM-dd 23:59:59}') "
                + "and DianYuanID={2} and LuHao={3} GROUP BY DAYOFYEAR(Time)", vKaiShiSJ, vJieShuSJ, DianYuanID, LuHao);
            PowerDataViewEFModel[] vSelectResult = m_BasicDBClass.SelectCustomEx<PowerDataViewEFModel>(vSql);
            vResult = new PowerInfo[vSelectResult.Length];
            double vOldDianNeng = 0;
            for ( int i=0;i<vSelectResult.Length;i++)
            {
                vResult[i] = new PowerInfo()
                {
                    DianNeng = (vSelectResult[i].DianNeng ?? 0) * 0.1 - vOldDianNeng,
                    ShiJian = vSelectResult[i].Time,
                    ShiJianStr = vSelectResult[i].Time == null ? "" : string.Format("{0}\r日", vSelectResult[i].Time.Value.Day)
                };
                vOldDianNeng = vResult[i].DianNeng;
            }
            return vResult;
        }

        /// <summary>
        /// 获取某路开关的用电量(日)
        /// </summary>
        /// <param name="DianYuanID"></param>
        /// <param name="LuHao"></param>
        /// <returns></returns>
        public PowerInfo[] GetYongDianLiang_Ri(int DianYuanID, int LuHao)
        {
            PowerInfo[] vResult = null;
            DateTime vKaiShiSJ = DateTime.Now;
            DateTime vJieShuSJ = DateTime.Now;
            string vSql = string.Format("Select MAX(DianNeng) as DianNeng,Time From `电源数据` where unix_timestamp( Time ) "
                + "between unix_timestamp( '{0:yyyy-MM-dd 00:00:00}') and unix_timestamp('{1:yyyy-MM-dd 23:59:59}') "
                + "and DianYuanID={2} and LuHao={3} GROUP BY HOUR(Time)", vKaiShiSJ, vJieShuSJ, DianYuanID, LuHao);
            PowerDataViewEFModel[] vSelectResult = m_BasicDBClass.SelectCustomEx<PowerDataViewEFModel>(vSql);
            vResult = new PowerInfo[vSelectResult.Length];
            double vOldDianNeng = 0;
            for (int i = 0; i < vSelectResult.Length; i++)
            {
                vResult[i] = new PowerInfo()
                {
                    DianNeng = (vSelectResult[i].DianNeng ?? 0) * 0.1 - vOldDianNeng,
                    ShiJian = vSelectResult[i].Time,
                    ShiJianStr = vSelectResult[i].Time == null ? "" : string.Format("{0}\r点", vSelectResult[i].Time.Value.Hour)
                };
                vOldDianNeng = vResult[i].DianNeng;
            }
            return vResult;
        }

        /// <summary>
        /// 获取某路开关的用电量(年)
        /// </summary>
        /// <param name="DianYuanID"></param>
        /// <param name="LuHao"></param>
        /// <returns></returns>
        public PowerInfo[] GetYongDianLiang_Nian(int DianYuanID, int LuHao)
        {
            PowerInfo[] vResult = null;
            DateTime vKaiShiSJ = DateTime.Now.AddMonths(-12);
            DateTime vJieShuSJ = DateTime.Now;
            string vSql = string.Format("Select MAX(DianNeng) as DianNeng,Time From `电源数据` where unix_timestamp( Time ) "
                + "between unix_timestamp( '{0:yyyy-MM-dd 00:00:00}') and unix_timestamp('{1:yyyy-MM-dd 23:59:59}') "
                + "and DianYuanID={2} and LuHao={3} GROUP BY Month(Time)", vKaiShiSJ, vJieShuSJ, DianYuanID, LuHao);
            PowerDataViewEFModel[] vSelectResult = m_BasicDBClass.SelectCustomEx<PowerDataViewEFModel>(vSql);
            vResult = new PowerInfo[vSelectResult.Length];
            double vOldDianNeng = 0;
            for (int i = 0; i < vSelectResult.Length; i++)
            {
                
                vResult[i] = new PowerInfo()
                {
                    DianNeng = (vSelectResult[i].DianNeng ?? 0) * 0.1 - vOldDianNeng,
                    ShiJian = vSelectResult[i].Time,
                    ShiJianStr = vSelectResult[i].Time == null ? "" : string.Format("{0}\r月", vSelectResult[i].Time.Value.Month)
                };
                vOldDianNeng = vResult[i].DianNeng;
            }
            return vResult;
        }

        #endregion

        #region 定时
        public List<TimingInfo> GetTimingInfo( int DianYuanID,byte LuHao)
        {
            TimingInfo[] vResult = new TimingInfo[0];
            PowerTimingEFModel vPowerTimingEFModel = new PowerTimingEFModel()
            {
                 DianYuanID = DianYuanID,
                 LuHao = LuHao
            };

            PowerTimingEFModel[] vSelectResult = m_BasicDBClass.SelectRecordsEx(vPowerTimingEFModel);
            vResult = new TimingInfo[vSelectResult.Length];
            for( int i=0;i< vResult.Length;i++)
            {
                vResult[i] = new TimingInfo()
                {
                    DianYuanID = DianYuanID,
                    LeiXing = vSelectResult[i].LeiXing ?? 0,
                    RenWuLX = vSelectResult[i].RenWuLX ?? 0,
                    YunXuKZ = vSelectResult[i].YunXuKZ ?? 0,
                    ZhouQi = vSelectResult[i].ZhouQi ?? 0,
                    ZhuHao = vSelectResult[i].ZhuHao ?? 0,
                    LuHao = vSelectResult[i].LuHao??0
                };
            }
            return vResult.ToList();
        }

        public byte ConvertTimingStrToZQ( string ZhouQi)
        {
            byte vResult;
            switch( ZhouQi )
            {
                case "单次":
                    vResult = 0x00;
                    break;
                case "每天":
                    vResult = 0x01;
                    break;
                case "每周":
                    vResult = 0x02;
                    break;
                case "每月":
                    vResult = 0x03;
                    break;
                default:
                    vResult = 0x00;
                    break;
            }
            return vResult;
        }

        public string ConvertTimingZQToStr(int ZhouQI)
        {
            string vResult = "";
            switch( ZhouQI)
            {
                case 0:
                    vResult = "单次";
                    break;
                case 1:
                    vResult = "每天";
                    break;
                case 2:
                    vResult = "每周";
                    break;
                case 3:
                    vResult = "每月";
                    break;
            }
            return vResult;
        }
        #endregion

        #region 电流统计
        /// <summary>
        /// 获取指定路号的最新数据
        /// </summary>
        /// <param name="DianYuanID"></param>
        /// <param name="LuShu"></param>
        /// <returns></returns>
        public PowerInfo GetNewPowerInfo( int DianYuanID ,int LuHao )
        {
            PowerInfo vResult = null;
            //string vSql = string.Format("Select `电源数据`.*,`电源开关配置`.MinCheng,`电源开关配置`.LeiXing From "
            //    +"`电源数据` inner join `电源开关配置` on `电源数据`.DianYuanID=`电源开关配置`.DianYuanID Where "
            //    +"`电源数据`.DianYuanID={0} and `电源数据`.LuHao={1} and  `电源开关配置`.LuHao={1} order by `电源数据`.id desc LIMIT 1", DianYuanID,LuHao);

            string vSql = string.Format("Select * From `V_电源数据` Where DianYuanID={0} and LuHao={1} order by id desc LIMIT 1", DianYuanID,LuHao);

            PowerDataViewEFModel vSelectResult = m_BasicDBClass.SelectCustomEx<PowerDataViewEFModel>(vSql).FirstOrDefault();
            if (vSelectResult.ID != 0 )
            {
                vResult = new PowerInfo()
                {
                    DianLiu = (vSelectResult.DianLiu ?? 0) * 0.01,
                    DianYa = (vSelectResult.DianYa ?? 0) * 0.1,
                    LuHao = LuHao,
                    DianNeng = (vSelectResult.DianNeng ?? 0)*0.1,
                    GongLuYinShu = vSelectResult.GongLuYinShu ?? 0,
                    LouDianLiu = vSelectResult.LouDianLiu ?? 0,
                    PinLu = vSelectResult.PinLu ?? 0,
                    WenDu = vSelectResult.WenDu ?? 0,
                    WuGongGL = vSelectResult.WuGongGL ?? 0,
                    YouGongGL = vSelectResult.YouGongGL ?? 0,
                    //ZhuangTai = (vSelectResult[0].DianYa ?? 0) == 0 ? false : true,
                    MingCheng = vSelectResult.MinCheng
                };
                vResult.ZhuangTai = vResult.DianYa == 0 ? false : true;
            }
            return vResult;
        }
        #endregion

        #region 分路开关参数
        public ParamInfo GetSwitchParamInfo(int DianYuanID,int LuoHao)
        {
            ParamInfo vResult = new ParamInfo();
            PowerSwithConfigEFModel vPowerSwithConfigEFModel = new PowerSwithConfigEFModel()
            {
                 DianYuanID = DianYuanID,
                  LuHao = LuoHao
            };
            PowerSwithConfigEFModel[] vSelectResult = m_BasicDBClass.SelectRecordsEx(vPowerSwithConfigEFModel);
            if (vSelectResult!=null && vSelectResult.Length>0)
            {
                vResult = new ParamInfo()
                {
                    XianDingDN = vSelectResult[0].XianDingDN ?? 0,
                    XianDingGL = vSelectResult[0].XianDingGL ?? 0,
                    DianLiuLLZ = vSelectResult[0].DianLiuLLZ ?? 0,
                    ChaoWenBHZ = vSelectResult[0].ChaoWenBHZ ?? 0,
                    ChaoWenYJZ = vSelectResult[0].ChaoWenYJZ ?? 0,
                    DianYuanID = DianYuanID,
                    EDingLDDZDL = vSelectResult[0].EDingLDDZDL ?? 0,
                    GuoYaSX = vSelectResult[0].GuoYaSX ?? 0,
                    LouDianLYJZ = vSelectResult[0].LouDianLYJZ ?? 0,
                    LuHao = LuoHao,
                    QianYaXX = vSelectResult[0].QianYaXX ?? 0,
                };
            }
            return vResult;
        }
        #endregion
    }
}
