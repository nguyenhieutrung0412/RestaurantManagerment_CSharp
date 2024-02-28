using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ET_QLNH
{
    public class ETNhanVien 
    {
        private string maNV;
        private string hoTen;
        private string sNgaySinh;
        private string sGioiTinh;
        private string sDiaChi;
        private string sSDT;
        private string sEmail;

        public string MaNV
        {
            get
            {
                return maNV;
            }

            set
            {
                maNV = value;
            }
        }

        public string HoTen
        {
            get
            {
                return hoTen;
            }

            set
            {
                hoTen = value;
            }
        }

        public string SNgaySinh
        {
            get
            {
                return sNgaySinh;
            }

            set
            {
                sNgaySinh = value;
            }
        }

        public string SGioiTinh
        {
            get
            {
                return sGioiTinh;
            }

            set
            {
                sGioiTinh = value;
            }
        }

        public string SDiaChi
        {
            get
            {
                return sDiaChi;
            }

            set
            {
                sDiaChi = value;
            }
        }

        public string SSDT
        {
            get
            {
                return sSDT;
            }

            set
            {
                sSDT = value;
            }
        }

        public string SEmail
        {
            get
            {
                return sEmail;
            }

            set
            {
                sEmail = value;
            }
        }
    }
}
