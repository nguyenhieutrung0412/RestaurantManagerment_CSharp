using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ET_QLNH;

namespace DAL_QLNH
{
    public class DAL_LoaiMonAn :KetNoiDB
    {
        public List<ET_LoaiMonAn> listLoaiMonAn()
        {
            List<ET_LoaiMonAn> list = new List<ET_LoaiMonAn>();
            DataTable data = LayDSLoaiMonAn();
            foreach (DataRow item in data.Rows)
            {
                ET_LoaiMonAn loaiMonAn = new ET_LoaiMonAn(item);
                list.Add(loaiMonAn);
            }
            return list;
        }
        public DataTable LayDSLoaiMonAn()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmdban = new SqlCommand("SP_LoaiMonAn_LayDS");
                cmdban.Connection = _cn;
                cmdban.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daLoaiKH = new SqlDataAdapter(cmdban);
                daLoaiKH.Fill(dt);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
    }
}
