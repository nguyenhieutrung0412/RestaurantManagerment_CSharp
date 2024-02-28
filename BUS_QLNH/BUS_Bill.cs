using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_QLNH;
using ET_QLNH;

namespace BUS_QLNH
{
    public class BUS_Bill
    {
        DAL_Bill bill = new DAL_Bill();
        public List<ET_Bill> ListBill(string maBan)
        {
            return bill.GetBillByTable(maBan);
        }
        public int GetMaThanhToanByMaBan(string maBan)
        {
            return bill.CheckThanhToanByMaban(maBan);
        }
        public void ThemBill(int idBill, string monAn, int soLuong)
        {
            bill.InsertBill(idBill, monAn, soLuong);
        }
    }
}
