using System;
using DAL_QLNH;
using ET_QLNH;
using System.Data;
using System.Collections.Generic;

namespace BUS_QLNH
{
    public class BUS_Ban
    {
        DAL_Ban dal_Ban = new DAL_Ban();
        ET_Ban kv = new ET_Ban();
        public List<ET_Ban> listBan()
        {
            return dal_Ban.loadTableList();
        }
       
        public DataTable DSBan()
        {
            return dal_Ban.LayDSBan();
        }
        public int ThemBan(ET_Ban ban)
        {
            return dal_Ban.InsertDataBan(ban);
        }
        public int XoaBan(ET_Ban ban)
        {
            return dal_Ban.DeleteBan(ban);
        }
        public int SuaBan(ET_Ban ban)
        {
            return dal_Ban.UpdateBan(ban);
        }
    }
}
