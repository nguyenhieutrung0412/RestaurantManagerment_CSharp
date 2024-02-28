using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_QLNH
{
    public class ET_DoiMk
    {
        private string taiKhoan;
        private string matKhau;
        private string matKhauMoi;

        public string TaiKhoan
        {
            get
            {
                return taiKhoan;
            }

            set
            {
                taiKhoan = value;
            }
        }

        public string MatKhau
        {
            get
            {
                return matKhau;
            }

            set
            {
                matKhau = value;
            }
        }

        public string MatKhauMoi
        {
            get
            {
                return matKhauMoi;
            }

            set
            {
                matKhauMoi = value;
            }
        }
    }
}
