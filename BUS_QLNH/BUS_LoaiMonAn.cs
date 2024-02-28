using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_QLNH;
using System.Data;
using ET_QLNH;

namespace BUS_QLNH
{
    public class BUS_LoaiMonAn
    {
        DAL_LoaiMonAn dal_loaiMonAn = new DAL_LoaiMonAn();
        public DataTable LayDSLoaiMonAn()
        {
            return dal_loaiMonAn.LayDSLoaiMonAn();
        }
        public List<ET_LoaiMonAn> GetListLoaiMonAn()
        {
            return dal_loaiMonAn.listLoaiMonAn();
        }
    }
}
