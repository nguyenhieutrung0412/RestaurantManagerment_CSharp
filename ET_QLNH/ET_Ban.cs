using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ET_QLNH
{
    public class ET_Ban
    {
        private string maBan;
        private string trangThai;
        private string maKhuVuc;


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

        public string TrangThai
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

        public string MaKhuVuc
        {
            get
            {
                return maKhuVuc;
            }

            set
            {
                maKhuVuc = value;
            }
        }
        public ET_Ban(string maBan,string trangThai,string maKhuVuc)
        {
            this.maBan = maBan;
            this.trangThai = trangThai;
            this.maKhuVuc = maKhuVuc;
        }
        public ET_Ban()
        {

        }
        public ET_Ban(DataRow row)
        {
            this.maBan =  row["maBan"].ToString();
            this.trangThai = row["trangThai"].ToString();
            this.maKhuVuc = row["maKhuVuc"].ToString();
        }
    }
}
