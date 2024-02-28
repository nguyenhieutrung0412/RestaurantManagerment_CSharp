using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ET_QLNH
{
    public class ET_MonAn
    {
        private string maMonAn;
        private string tenMonAn;
        private string loaiMonAn;
        private float donGia;
        public ET_MonAn() { }
        public ET_MonAn(string maMonAn ,string tenMonAn ,string loaiMonAn ,float donGia)
        {
            this.maMonAn = maMonAn;
            this.tenMonAn = tenMonAn;
            this.loaiMonAn = loaiMonAn;
            this.donGia = donGia;
        }
        public ET_MonAn(DataRow row)
        {
            this.maMonAn = row["MaMonAn"].ToString(); ;
            this.tenMonAn = row["TenMonAn"].ToString();
            this.loaiMonAn = row["MaLoaiMonAn"].ToString();
            this.donGia = (float)Convert.ToDouble(row["DonGia"].ToString());
        }
        public string MaMonAn
        {
            get
            {
                return maMonAn;
            }

            set
            {
                maMonAn = value;
            }
        }

        public string TenMonAn
        {
            get
            {
                return tenMonAn;
            }

            set
            {
                tenMonAn = value;
            }
        }

        public float DonGia
        {
            get
            {
                return donGia;
            }

            set
            {
                donGia = value;
            }
        }

        public string LoaiMonAn
        {
            get
            {
                return LoaiMonAn;
            }

            set
            {
                LoaiMonAn = value;
            }
        }
    }
}
