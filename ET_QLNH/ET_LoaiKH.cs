using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_QLNH
{
    public class ET_LoaiKH
    {
        private string maLoaiKh;
        private string tenLoaiKH;

        public string MaLoaiKh
        {
            get
            {
                return maLoaiKh;
            }

            set
            {
                maLoaiKh = value;
            }
        }

        public string TenLoaiKH
        {
            get
            {
                return tenLoaiKH;
            }

            set
            {
                tenLoaiKH = value;
            }
        }
    }
}
