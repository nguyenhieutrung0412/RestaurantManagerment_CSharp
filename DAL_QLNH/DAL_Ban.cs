using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ET_QLNH;

namespace DAL_QLNH
{
    public class DAL_Ban :KetNoiDB
    {
        
        public List<ET_Ban> loadTableList()
        {
            List<ET_Ban> tableList = new List<ET_Ban>();
            
            DataTable data = LayDSBan();

            foreach (DataRow item in data.Rows)
            {
                ET_Ban table = new ET_Ban(item);
               tableList.Add(table);
            }
            return tableList;
        }

        public DataTable LayDSBan()
        {
            DataTable dtBan = new DataTable();
            try
            {
                SqlCommand cmdban = new SqlCommand("SP_Ban_LayDS");
                cmdban.Connection = _cn;
                cmdban.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daLoaiKH = new SqlDataAdapter(cmdban);
                daLoaiKH.Fill(dtBan);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dtBan;
        }
        public int InsertDataBan(ET_Ban ban)
        {
            int result = 0;
            try
            {
                _cn.Open();
                SqlCommand cmdBan = new SqlCommand("SP_Ban_Them");
                cmdBan.Connection = _cn;
                cmdBan.CommandType = CommandType.StoredProcedure;
                cmdBan.Parameters.AddWithValue("@MaBan", ban.MaBan);
                cmdBan.Parameters.AddWithValue("@TrangThai", ban.TrangThai);
                cmdBan.Parameters.AddWithValue("@MaKhuVuc", ban.MaKhuVuc);

                result = cmdBan.ExecuteNonQuery();
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
        public int DeleteBan(ET_Ban ban)
        {

            int result = 0;
            try
            {
                _cn.Open();

                SqlCommand cmdBan = new SqlCommand("SP_Ban_Xoa");
                cmdBan.Connection = _cn;
                cmdBan.CommandType = CommandType.StoredProcedure;
                cmdBan.Parameters.AddWithValue("@MaBan", ban.MaBan);
                result = cmdBan.ExecuteNonQuery();
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
        public int UpdateBan(ET_Ban ban)
        {
            int result = 0;
            try
            {
                _cn.Open();
                SqlCommand cmdBan = new SqlCommand("SP_Ban_Sua");
                cmdBan.Connection = _cn;
                cmdBan.CommandType = CommandType.StoredProcedure;
                cmdBan.Parameters.AddWithValue("@MaBan", ban.MaBan);
                cmdBan.Parameters.AddWithValue("@TrangThai", ban.TrangThai);
                cmdBan.Parameters.AddWithValue("@MaKhuVuc", ban.MaKhuVuc);

                result = cmdBan.ExecuteNonQuery();

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
