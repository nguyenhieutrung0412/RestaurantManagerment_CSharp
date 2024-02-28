using System;
using System.Collections.Generic;
using System.Linq;
using ET_QLNH;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLNH
{
    public class DAL_Bill:KetNoiDB
    {

        public void InsertBill(int idBill,string monAn,int soLuong )
        {
            try
            {
                _cn.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertBill");
                cmd.Connection = _cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaThanhToan", idBill);
                cmd.Parameters.AddWithValue("@MaMonAn", monAn);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@TrangThai", 0);
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
        public int CheckThanhToanByMaban(string maBan)
        {
            DataTable dtBill = new DataTable();
            try
            {
                SqlCommand cmdbill = new SqlCommand("Select * from ThanhToan WHERE MaBan ='"+maBan+"'and TrangThai = 0");
                cmdbill.Connection = _cn;
                cmdbill.CommandType = CommandType.Text;
             

                SqlDataAdapter da = new SqlDataAdapter(cmdbill);
                da.Fill(dtBill);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(dtBill.Rows.Count >0)
            {
                ET_ThanhToan bill = new ET_ThanhToan(dtBill.Rows[0]);
                return bill.MaThanhToan;
            }
            return -1;
        }
        public List<ET_Bill> GetBillByTable(string maBan)
        {
            List<ET_Bill> listBill = new List<ET_Bill>();
            DataTable data = Bill(maBan);
            foreach (DataRow item in data.Rows)
            {
                ET_Bill b = new ET_Bill(item);
                listBill.Add(b);
            }

            return listBill;
        }
        public DataTable Bill(string b)
        {
            DataTable dtBill = new DataTable();
            try
            {
                _cn.Open();
                SqlCommand cmdbill = new SqlCommand("SP_Bill");
                cmdbill.Connection = _cn;
                cmdbill.CommandType = CommandType.StoredProcedure;
                cmdbill.Parameters.AddWithValue("@id", b);
                cmdbill.ExecuteNonQuery();
                SqlDataAdapter daLoaiKH = new SqlDataAdapter(cmdbill);
                daLoaiKH.Fill(dtBill);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            _cn.Close();
            return dtBill;
        }
    }
}
