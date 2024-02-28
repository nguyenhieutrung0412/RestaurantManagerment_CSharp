using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ET_QLNH;

namespace DAL_QLNH
{
    public class DAL_KhuVuc : KetNoiDB
    {
        public DataTable LayDSKhuVuc()
        {
            DataTable dtKhuVuc = new DataTable();
            try
            {
                SqlCommand cmdKhuVuc = new SqlCommand("SP_KhuVuc_LayDS");
                cmdKhuVuc.Connection = _cn;
                cmdKhuVuc.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daLoaiKH = new SqlDataAdapter(cmdKhuVuc);
                daLoaiKH.Fill(dtKhuVuc);


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dtKhuVuc;

        }
        public int InsertDataKhuVuc(ET_KhuVuc kv)
        {
            int result = 0;
            try
            {
                _cn.Open();
                SqlCommand cmdKV = new SqlCommand("SP_KhuVuc_Them");
                cmdKV.Connection = _cn;
                cmdKV.CommandType = CommandType.StoredProcedure;
                cmdKV.Parameters.AddWithValue("@MaKhuVuc", kv.MaKhuVuc);
                cmdKV.Parameters.AddWithValue("@TenKhuVuc", kv.TenKhuVuc);
                cmdKV.Parameters.AddWithValue("@TrangThai", kv.TrangThai);

                result = cmdKV.ExecuteNonQuery();
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
        public int DeleteKhuVuc(ET_KhuVuc kv)
        {

            int result = 0;
            try
            {
                _cn.Open();

                SqlCommand cmdKV = new SqlCommand("SP_KhuVuc_Xoa");
                cmdKV.Connection = _cn;
                cmdKV.CommandType = CommandType.StoredProcedure;
                cmdKV.Parameters.AddWithValue("@MaKhuVuc", kv.MaKhuVuc);
                result = cmdKV.ExecuteNonQuery();
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
        public int UpdateKhuVuc(ET_KhuVuc kv)
        {
            int result = 0;
            try
            {
                _cn.Open();
                SqlCommand cmdKV = new SqlCommand("SP_KhuVuc_Sua");
                cmdKV.Connection = _cn;
                cmdKV.CommandType = CommandType.StoredProcedure;
                cmdKV.Parameters.AddWithValue("@MaKhuVuc", kv.MaKhuVuc);
                cmdKV.Parameters.AddWithValue("@TenKhuVuc", kv.TenKhuVuc);
                cmdKV.Parameters.AddWithValue("@TrangThai", kv.TrangThai);

                result = cmdKV.ExecuteNonQuery();

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
