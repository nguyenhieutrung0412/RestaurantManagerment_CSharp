using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_QLNH
{
    public class ET_KhachHang
    {
        private string maKH;
        private string hoTen;
        private string sSDT;
        private string sDiaChi;
        private string sEmail;
        private string sMaLoai;

        public string MaNV
        {
            get
            {
                return maKH;
            }

            set
            {
                maKH = value;
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

        public string SMaLoai
        {
            get
            {
                return sMaLoai;
            }

            set
            {
                sMaLoai = value;
            }
        }
    }
}
