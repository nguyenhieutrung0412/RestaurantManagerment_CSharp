using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ET_QLNH
{
    public class ET_LoaiMonAn
    {
        private string maLoai;
        private string tenLoai;

        public ET_LoaiMonAn() { }
        public ET_LoaiMonAn(string maLoai,string tenLoai)
        {
            this.maLoai = maLoai;
            this.tenLoai = tenLoai;
        }
        public ET_LoaiMonAn(DataRow row)
        {
            this.maLoai = row["MaLoai"].ToString();
            this.tenLoai = row["TenLoai"].ToString();
        }
        public string MaLoai
        {
            get
            {
                return maLoai;
            }

            set
            {
                maLoai = value;
            }
        }

        public string TenLoai
        {
            get
            {
                return tenLoai;
            }

            set
            {
                tenLoai = value;
            }
        }
    }
}
