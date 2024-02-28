using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ET_QLNH;


namespace DAL_QLNH
{
    public class DAL_KhachHang:KetNoiDB
    {
        public DataTable LayDSKH()
        {
            DataTable dtKH = new DataTable();
            try
            {
                SqlCommand cmdKH = new SqlCommand("SP_KhachHang_LayDS", _cn);
                cmdKH.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daLoaiKH = new SqlDataAdapter(cmdKH);
                daLoaiKH.Fill(dtKH);


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dtKH;

        }
        public int InsertDataKhachHang(ET_KhachHang etkh)
        {
            int result = 0;
            try
            {
                _cn.Open();
                SqlCommand sqlCmdSinhVien = new SqlCommand("SP_KhachHang_Them");
                sqlCmdSinhVien.Connection = _cn;
                sqlCmdSinhVien.CommandType = CommandType.StoredProcedure;
                sqlCmdSinhVien.Parameters.AddWithValue("@MaKH", etkh.MaNV);
                sqlCmdSinhVien.Parameters.AddWithValue("@HoTen", etkh.HoTen);
                sqlCmdSinhVien.Parameters.AddWithValue("@SDT", etkh.SSDT);
                sqlCmdSinhVien.Parameters.AddWithValue("@DiaChi", etkh.SDiaChi);
       
                sqlCmdSinhVien.Parameters.AddWithValue("@Email", etkh.SEmail);

                sqlCmdSinhVien.Parameters.AddWithValue("@MaLoaiKH", etkh.SMaLoai);

                result = sqlCmdSinhVien.ExecuteNonQuery();
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
        public int DeleteKhachHang(ET_KhachHang etkh)
        {

            int result = 0;
            try
            {
                _cn.Open();

                SqlCommand cmdSV = new SqlCommand("SP_KhachHang_Xoa");
                cmdSV.Connection = _cn;
                cmdSV.CommandType = CommandType.StoredProcedure;
                cmdSV.Parameters.AddWithValue("@MaKH", etkh.MaNV);
                result = cmdSV.ExecuteNonQuery();
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
        public int UpdateKhachHang(ET_KhachHang etkh)
        {
            int result = 0;
            try
            {
                _cn.Open();
                SqlCommand cmdKH = new SqlCommand("SP_NhanVien_Sua");
                cmdKH.Connection = _cn;
                cmdKH.CommandType = CommandType.StoredProcedure;
                cmdKH.Parameters.AddWithValue("@MaKH", etkh.MaNV);
                cmdKH.Parameters.AddWithValue("@HoTen", etkh.HoTen);
                cmdKH.Parameters.AddWithValue("@SDT", etkh.SSDT);
                cmdKH.Parameters.AddWithValue("@DiaChi", etkh.SDiaChi);

                cmdKH.Parameters.AddWithValue("@Email", etkh.SEmail);

                cmdKH.Parameters.AddWithValue("@MaLoaiKH", etkh.SMaLoai);
                result = cmdKH.ExecuteNonQuery();

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
