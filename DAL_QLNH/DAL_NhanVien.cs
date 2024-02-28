using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ET_QLNH;

namespace DAL_QLNH
{
    public class DAL_NhanVien : KetNoiDB
    {
        ETNhanVien _ETNhanVien = new ETNhanVien();

        public DataTable LayDSNhanVien()
        {
            DataTable dtNhanVien = new DataTable();
            try
            {
                SqlCommand cmdNhanVien = new SqlCommand("SP_NhanVien_LayDS", _cn);
                cmdNhanVien.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daNhanVien = new SqlDataAdapter(cmdNhanVien);
                daNhanVien.Fill(dtNhanVien);


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dtNhanVien;

        }
        public int InsertDataNhanVien(ETNhanVien etnv)
        {
            int result = 0;
            try
            {
                _cn.Open();
                SqlCommand sqlCmdSinhVien = new SqlCommand("SP_NhanVien_Them");
                sqlCmdSinhVien.Connection = _cn;
                sqlCmdSinhVien.CommandType = CommandType.StoredProcedure;
                sqlCmdSinhVien.Parameters.AddWithValue("@MaNV", etnv.MaNV);
                sqlCmdSinhVien.Parameters.AddWithValue("@HoTen", etnv.HoTen);
                sqlCmdSinhVien.Parameters.AddWithValue("@NgaySinh", etnv.SNgaySinh);
                sqlCmdSinhVien.Parameters.AddWithValue("@GioiTinh", etnv.SGioiTinh);
                sqlCmdSinhVien.Parameters.AddWithValue("@DiaChi", etnv.SDiaChi);
                sqlCmdSinhVien.Parameters.AddWithValue("@SDT", etnv.SSDT);
                sqlCmdSinhVien.Parameters.AddWithValue("@Email", etnv.SEmail);

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
        public int DeleteNhanVien(ETNhanVien etnv)
        {
    
            int result = 0;
            try
            {
                _cn.Open();

                SqlCommand cmdSV = new SqlCommand("SP_NhanVien_Xoa");
                cmdSV.Connection = _cn;
                cmdSV.CommandType = CommandType.StoredProcedure;
                cmdSV.Parameters.AddWithValue("@MaNV", etnv.MaNV);
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
        public int UpdateNhanVien(ETNhanVien etnv)
        {
            int result = 0;
            try
            {
                _cn.Open();
                SqlCommand cmdNhanVien = new SqlCommand("SP_NhanVien_Sua");
                cmdNhanVien.Connection = _cn;
                cmdNhanVien.CommandType = CommandType.StoredProcedure;
                cmdNhanVien.Parameters.AddWithValue("@MaNV", etnv.MaNV);
                cmdNhanVien.Parameters.AddWithValue("@HoTen", etnv.HoTen);
                cmdNhanVien.Parameters.AddWithValue("@NgaySinh", etnv.SNgaySinh);
                cmdNhanVien.Parameters.AddWithValue("@GioiTinh", etnv.SGioiTinh);
                cmdNhanVien.Parameters.AddWithValue("@DiaChi", etnv.SDiaChi);
                cmdNhanVien.Parameters.AddWithValue("@SDT", etnv.SSDT);
                cmdNhanVien.Parameters.AddWithValue("@Email", etnv.SEmail);
                result = cmdNhanVien.ExecuteNonQuery();

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
        public DataTable SearchNV(ETNhanVien nv)
        {
            DataTable dt = new DataTable();
            //int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NhanVien_TruyXuat");
                cmd.Connection = _cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
             
                da.Fill(dt);
               // cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                _cn.Close();

            }

            return dt;
        }
    }
}
