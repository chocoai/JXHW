﻿using System;
using MXKJ.DBMiddleWareLib;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("发送命令", "ID")]
    public struct SendCMDEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("GangTingID")]
        public int? GangTingID { get; set; }
        [ColumnAttrib("ID_H")]
        public byte? ID_H { get; set; }
        [ColumnAttrib("ID_L")]
        public byte? ID_L { get; set; }
        [ColumnAttrib("CMD")]
        public byte? CMD { get; set; }
        [ColumnAttrib("SUB")]
        public byte? SUB { get; set; }
        [ColumnAttrib("SN")]
        public Int16? SN { get; set; }
        [ColumnAttrib("SendTime")]
        public DateTime? SendTime { get; set; }
        [ColumnAttrib("State")]
        public Int16? State { get; set; }
    }
}