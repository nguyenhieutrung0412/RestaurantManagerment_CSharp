using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLNH
{
    public class KetNoiDB
    {
        protected SqlConnection _cn = new SqlConnection("Data Source=.;Initial Catalog=CSDL_QLNH;Integrated Security=True");
    }
}
