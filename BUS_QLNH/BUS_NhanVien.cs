using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_QLNH;
using ET_QLNH;
using System.Data;
namespace BUS_QLNH
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dal_NhanVien = new DAL_NhanVien();
        ETNhanVien nv = new ETNhanVien();
        public DataTable LayDSNhanVien()
        {
            return dal_NhanVien.LayDSNhanVien();
        }
        public int ThemNhanVien(ETNhanVien nv)
        {
            return dal_NhanVien.InsertDataNhanVien(nv);
        }
        public int XoaNhanVien(ETNhanVien nv)
        {
            return dal_NhanVien.DeleteNhanVien(nv);
        }
        public int SuaNhanVien(ETNhanVien nv)
        {
            return dal_NhanVien.UpdateNhanVien(nv);
        }
        public DataTable TimNhanVien(ETNhanVien nv)
        {
            return dal_NhanVien.SearchNV(nv);
        }

    }
}
