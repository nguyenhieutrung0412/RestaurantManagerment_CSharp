using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_QLNH
{
    public class ET_KhuVuc
    {
        private string maKhuVuc;
        private string tenKhuVuc;
        private string trangThai;

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

        public string TenKhuVuc
        {
            get
            {
                return tenKhuVuc;
            }

            set
            {
                tenKhuVuc = value;
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
    }
}
