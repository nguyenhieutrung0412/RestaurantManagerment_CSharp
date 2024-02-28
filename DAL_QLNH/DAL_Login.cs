using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ET_QLNH;

namespace DAL_QLNH
{
    public class DAL_Login : KetNoiDB
    {
        ET_Login login = new ET_Login();
        public DataTable Login(ET_Login login)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TaiKhoan where TenDangNhap =N'" + login.TenDangNhap + "' and MatKhau = N'" + login.MatKhau + "'", _cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
