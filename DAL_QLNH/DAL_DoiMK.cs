using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ET_QLNH;
using System.Data;

namespace DAL_QLNH
{
    public class DAL_DoiMK : KetNoiDB
    {
        public int DoiMatKhau(ET_DoiMk mk)
        {
            int result = 0;
            try
            {
                _cn.Open();
                SqlCommand cmdmk = new SqlCommand("SP_TaiKhoan_DoiMatKhau", _cn);
                cmdmk.CommandType = CommandType.StoredProcedure;
                cmdmk.Parameters.AddWithValue("@TenDangNhap", mk.TaiKhoan);
                cmdmk.Parameters.AddWithValue("@MatKhau" , mk.MatKhau);
                cmdmk.Parameters.AddWithValue("@MatKhauMoi", mk.MatKhauMoi);
                result = cmdmk.ExecuteNonQuery();


            }
            catch (SqlException ex)
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
