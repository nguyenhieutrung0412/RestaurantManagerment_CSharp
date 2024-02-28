using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ET_QLNH;
using DAL_QLNH;

namespace BUS_QLNH
{
    public class BUS_DoiMK
        
    {
        DAL_DoiMK dal_DoiMk = new DAL_DoiMK();
        public int DoiMatKhau(ET_DoiMk mk)
        {
            return dal_DoiMk.DoiMatKhau(mk);
        }
    }

}
