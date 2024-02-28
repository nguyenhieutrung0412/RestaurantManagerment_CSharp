using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ET_QLNH
{
   public class ET_Bill
    {
        private int maBill;
  
        private string monAn;
        private int soLuong;
        private float gia;
        private float tongTien;
        public ET_Bill() { }
        public ET_Bill(int id,string monAn,int soLuong,float gia,float thanhTien = 0)
        {
            this.maBill = id;
     
            this.monAn = monAn;
            this.soLuong = soLuong;
            this.gia = gia;
           this.tongTien = thanhTien;
        }
        public ET_Bill(DataRow row)
        {
           // this.MaBill = (int)(row)["MaThanhToan"];
     
            this.monAn = (row)["TenMonAn"].ToString();
            this.soLuong = (int)(row)["SoLuong"];
            this.gia = (float)Convert.ToDouble((row)["DonGia"].ToString()) ;
            this.tongTien = (float)Convert.ToDouble((row)["ThanhTien"].ToString());
        }

     

        public string MonAn1
        {
            get
            {
                return monAn;
            }

            set
            {
                monAn = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        public float Gia
        {
            get
            {
                return gia;
            }

            set
            {
                gia = value;
            }
        }

        public float TongTien
        {
            get
            {
                return tongTien;
            }

            set
            {
                tongTien = value;
            }
        }

        public int MaBill
        {
            get
            {
                return maBill;
            }

            set
            {
                maBill = value;
            }
        }
    }
}
