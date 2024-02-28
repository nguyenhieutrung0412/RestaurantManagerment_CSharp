using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_QLNH;
using System.Data;
using ET_QLNH;

namespace BUS_QLNH
{
    public class BUS_Login
    {
        DAL_Login dal_login = new DAL_Login();
        public DataTable CheckLogin(ET_Login login)
        {
            return dal_login.Login(login);
        }
    }
}
