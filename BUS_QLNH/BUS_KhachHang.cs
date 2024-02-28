using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_QLNH;
using System.Data;
using ET_QLNH;

namespace BUS_QLNH
{
    public class BUS_KhachHang
    {
        DAL_KhachHang DAL_KH = new DAL_KhachHang();
        ET_KhachHang etKH = new ET_KhachHang();
        public DataTable DSKH()
        {
            return DAL_KH.LayDSKH();
        }
        public int ThemKH(ET_KhachHang kh)
        {
            return DAL_KH.InsertDataKhachHang(kh);
        }
        public int XoaLoaiKH(ET_KhachHang kh)
        {
            return DAL_KH.DeleteKhachHang(kh);
        }
        public int SuaLoaiKH(ET_KhachHang kh)
        {
            return DAL_KH.UpdateKhachHang(kh);
        }
    }
}
