using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ET_QLNH
{
    public class ET_ThanhToan
    {
        private int maThanhToan;



        private DateTime? gioVao;

        private int trangThai;
        private string maBan;
        public ET_ThanhToan() { }
        public ET_ThanhToan(int maThanhToan, DateTime? gioVao,int trangThai ,string maBan)
        {
            this.maThanhToan = maThanhToan;
            this.gioVao = gioVao;
            this.trangThai = trangThai;
            this.maBan = maBan;
        }
        public ET_ThanhToan(DataRow row)
        {
            this.maThanhToan = (int)row["MaThanhToan"];
            this.gioVao = (DateTime?)row["gioVao"];
            this.trangThai = (int)row["TrangThai"];
            this.maBan = row["MaBan"].ToString();
        }
        public int MaThanhToan
        {
            get
            {
                return maThanhToan;
            }

            set
            {
                maThanhToan = value;
            }
        }

      

        public string MaBan
        {
            get
            {
                return maBan;
            }

            set
            {
                maBan = value;
            }
        }

      

      

        public int TrangThai
        {
            get
            {
                return trangThai;
            }

            set
            {
                trangThai = value;
            }
        }

        public DateTime? GioVao
        {
            get
            {
                return gioVao;
            }

            set
            {
                gioVao = value;
            }
        }
    }
}
