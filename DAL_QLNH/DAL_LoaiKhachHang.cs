using System;
using System.Data;
using System.Data.SqlClient;
using ET_QLNH;

namespace DAL_QLNH
{
    public class DAL_LoaiKhachHang : KetNoiDB
    {

        public DataTable LayDSNhanVien()
        {
            DataTable dtLoaiKH = new DataTable();
            try
            {
                SqlCommand cmdLoaiKH = new SqlCommand("SP_loaiKH_LayDS", _cn);
                cmdLoaiKH.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daLoaiKH = new SqlDataAdapter(cmdLoaiKH);
                daLoaiKH.Fill(dtLoaiKH);


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dtLoaiKH;

        }
        public int InsertDataLoaiKH(ET_LoaiKH etnv)
        {
            int result = 0;
            try
            {
                _cn.Open();
                SqlCommand cmdLoaiKH = new SqlCommand("SP_LoaiKH_Them");
                cmdLoaiKH.Connection = _cn;
                cmdLoaiKH.CommandType = CommandType.StoredProcedure;
                cmdLoaiKH.Parameters.AddWithValue("@MaLoaiKH", etnv.MaLoaiKh);
                cmdLoaiKH.Parameters.AddWithValue("@TenLoaiKH", etnv.TenLoaiKH);


                result = cmdLoaiKH.ExecuteNonQuery();
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
        public int DeleteLoaiKH(ET_LoaiKH etnv)
        {

            int result = 0;
            try
            {
                _cn.Open();

                SqlCommand cmdLoaiKH = new SqlCommand("SP_LoaiKH_Xoa");
                cmdLoaiKH.Connection = _cn;
                cmdLoaiKH.CommandType = CommandType.StoredProcedure;
                cmdLoaiKH.Parameters.AddWithValue("@MaLoaiKH", etnv.MaLoaiKh);
                result = cmdLoaiKH.ExecuteNonQuery();
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
        public int UpdateLoaiKH(ET_LoaiKH etnv)
        {
            int result = 0;
            try
            {
                _cn.Open();
                SqlCommand cmdLoaiKH = new SqlCommand("SP_LoaiKH_Sua");
                cmdLoaiKH.Connection = _cn;
                cmdLoaiKH.CommandType = CommandType.StoredProcedure;
                cmdLoaiKH.Parameters.AddWithValue("@MaLoaiKH", etnv.MaLoaiKh);
                cmdLoaiKH.Parameters.AddWithValue("@TenLoaiKH", etnv.TenLoaiKH);
                result = cmdLoaiKH.ExecuteNonQuery();

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
