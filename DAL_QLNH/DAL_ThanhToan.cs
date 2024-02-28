using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL_QLNH
{
    public class DAL_ThanhToan:KetNoiDB
    {
        public void ThanhToan(int id )
        {
            _cn.Open();
            string query = "UPDATE ThanhToan set TrangThai = 1 where MaThanhToan =" + id;
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = _cn;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            _cn.Close();
        }
        public void InsertThanhToan(string maBan)
        {
            try
            {
                _cn.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertThanhToan");
                cmd.Connection = _cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaBan", maBan);
                cmd.ExecuteNonQuery();
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
        }
        public int GetMaxMaThanhToan()
        {
            int result = 1;
            try
            {
                _cn.Open();
                SqlCommand cmd = new SqlCommand("GetMaxIdThanhToan");
                cmd.Connection = _cn;
                cmd.CommandType = CommandType.StoredProcedure;
                result = cmd.ExecuteNonQuery();
                // return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return 1;

            }
            finally
            {
                _cn.Close();

            }
            return result;
        }
    }
}
