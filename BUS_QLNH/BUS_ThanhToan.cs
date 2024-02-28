using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_QLNH;

namespace BUS_QLNH
{
    public class BUS_ThanhToan
    {
        DAL_ThanhToan t = new DAL_ThanhToan();
        public void InsertThanhToan(string maBan)
        {
             t.InsertThanhToan(maBan);
        }
        public int GetMaxIdBill()
        {
            return t.GetMaxMaThanhToan();
        }
        public void ThanhToan(int id )
        {
             t.ThanhToan(id);
        }
    }
}
