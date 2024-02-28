using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_QLNH;
using ET_QLNH;
using System.Data;

namespace BUS_QLNH
{
    public class BUS_KhuVuc
    {
        DAL_KhuVuc dal_KhuVuc = new DAL_KhuVuc();
        ET_KhuVuc kv = new ET_KhuVuc();
        public DataTable DSKhuVuc()
        {
            return dal_KhuVuc.LayDSKhuVuc();
        }
        public int ThemKV(ET_KhuVuc kv)
        {
            return dal_KhuVuc.InsertDataKhuVuc(kv);
        }
        public int XoaKV(ET_KhuVuc kv)
        {
            return dal_KhuVuc.DeleteKhuVuc(kv);
        }
        public int SuaKV(ET_KhuVuc kv)
        {
            return dal_KhuVuc.UpdateKhuVuc(kv);
        }
    }
}
