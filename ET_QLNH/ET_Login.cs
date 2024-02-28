using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_QLNH
{
    public class ET_Login
    {
        private string tenDangNhap;
        private string matKhau;
        private string quyen;

        public string TenDangNhap
        {
            get
            {
                return tenDangNhap;
            }

            set
            {
                tenDangNhap = value;
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

        public string Quyen
        {
            get
            {
                return quyen;
            }

            set
            {
                quyen = value;
            }
        }
    }
}
