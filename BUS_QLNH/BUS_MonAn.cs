using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_QLNH;
using System.Data;
using ET_QLNH;

namespace BUS_QLNH
{
    public class BUS_MonAn
    {
        DAL_MonAN DAL_MonAn = new DAL_MonAN();
        ET_MonAn etMonAn = new ET_MonAn();
        public List<ET_MonAn> ListMonAnByMaLoai(string maLoai)
        {
            return DAL_MonAn.listMonAnbyMaLoai(maLoai);
        }
        public DataTable DSMonAn()
        {
            return DAL_MonAn.LayDSMonAn();
        }
        public int ThemMonAn(ET_MonAn monAn)
        {
            return DAL_MonAn.InsertDataMonAN(monAn);
        }
        public int XoaMonAn(ET_MonAn monAn)
        {
            return DAL_MonAn.DeleteMonAn(monAn);
        }
        public int SuaMonAn(ET_MonAn monAn)
        {
            return DAL_MonAn.UpdateMonAn(monAn);
        }
    }
}
