using System;
using System.Data;
using System.Data.SqlClient;
using ET_QLNH;
using System.Collections.Generic;

namespace DAL_QLNH
{
    public class DAL_MonAN:KetNoiDB
    {
        ET_MonAn _ETMonAn = new ET_MonAn();

        public List<ET_MonAn> listMonAnbyMaLoai(string maLoai)
        {
            List<ET_MonAn> listMonAn = new List<ET_MonAn>();
            string query = "Select * from MonAn where MaLoaiMonAn =" + maLoai;
            SqlCommand cmdMA = new SqlCommand(query);
            cmdMA.Connection = _cn;
            cmdMA.CommandType = CommandType.Text;
            DataTable data = new DataTable();
            SqlDataAdapter daMonAn = new SqlDataAdapter(cmdMA);
            daMonAn.Fill(data);
            foreach (DataRow item in data.Rows)
            {
                ET_MonAn ma = new ET_MonAn(item);
                listMonAn.Add(ma);
            }
            return listMonAn;
        }
        public DataTable LayDSMonAn()
        {
            DataTable dtMonAn = new DataTable();
            try
            {
                SqlCommand cmdMonAn = new SqlCommand("SP_MonAn_LayDS", _cn);
                cmdMonAn.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daNhanVien = new SqlDataAdapter(cmdMonAn);
                daNhanVien.Fill(dtMonAn);


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dtMonAn;

        }
        public int InsertDataMonAN(ET_MonAn monAn)
        {
            int result = 0;
            try
            {
                _cn.Open();
                SqlCommand cmdMA = new SqlCommand("SP_MonAn_Them");
                cmdMA.Connection = _cn;
                cmdMA.CommandType = CommandType.StoredProcedure;
                cmdMA.Parameters.AddWithValue("@MaMonAn", monAn.MaMonAn);
                cmdMA.Parameters.AddWithValue("@TenMonAn", monAn.TenMonAn);
                cmdMA.Parameters.AddWithValue("@MaLoaiMonAn", monAn.LoaiMonAn);
                cmdMA.Parameters.AddWithValue("@DonGia", monAn.DonGia);

                result = cmdMA.ExecuteNonQuery();
                // return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                _cn.Close();

            }
            return result;
        }
        public int DeleteMonAn(ET_MonAn monAn)
        {

            int result = 0;
            try
            {
                _cn.Open();

                SqlCommand cmdMA = new SqlCommand("SP_MonAn_Xoa");
                cmdMA.Connection = _cn;
                cmdMA.CommandType = CommandType.StoredProcedure;
                cmdMA.Parameters.AddWithValue("@MaMonAn", monAn.TenMonAn);
                result = cmdMA.ExecuteNonQuery();
                // return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                _cn.Close();

            }
            return result;
        }
        public int UpdateMonAn(ET_MonAn monAn)
        {
            int result = 0;
            try
            {
                _cn.Open();
                SqlCommand cmdMA = new SqlCommand("SP_MonAn_Sua");
                cmdMA.Connection = _cn;
                cmdMA.CommandType = CommandType.StoredProcedure;
                cmdMA.Parameters.AddWithValue("@MaMonAn", monAn.MaMonAn);
                cmdMA.Parameters.AddWithValue("@TenMonAn", monAn.TenMonAn);
                cmdMA.Parameters.AddWithValue("@MaLoaiMonAn", monAn.LoaiMonAn);
                cmdMA.Parameters.AddWithValue("@DonGia", monAn.DonGia);

                result = cmdMA.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                _cn.Close();

            }
            return result;
        }
    }
}
