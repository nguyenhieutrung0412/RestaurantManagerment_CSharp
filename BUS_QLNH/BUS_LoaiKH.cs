using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_QLNH;
using System.Data;
using ET_QLNH;

namespace BUS_QLNH
{
    public class BUS_LoaiKH
    {
        DAL_LoaiKhachHang DAL_LoaiKH = new DAL_LoaiKhachHang();
        ET_LoaiKH etLoaiKH = new ET_LoaiKH();
        public DataTable DSLoaiKH()
        {
            return DAL_LoaiKH.LayDSNhanVien();
        }
        public int ThemLoaiKH(ET_LoaiKH kh)
        {
            return DAL_LoaiKH.InsertDataLoaiKH(kh);
        }
        public int XoaLoaiKH(ET_LoaiKH kh)
        {
            return DAL_LoaiKH.DeleteLoaiKH(kh);
        }
        public int SuaLoaiKH(ET_LoaiKH kh)
        {
            return DAL_LoaiKH.UpdateLoaiKH(kh);
        }

    }
}
