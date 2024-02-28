using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ET_QLNH;
//using System.Data;

namespace QuanLyNhaHang
{
    public partial class formManHinhChinh : Form
    {
        string tenDangNhap = "";
        string matKhau = "";
        string quyen = "";

        ET_Login lo = new ET_Login();
        public formManHinhChinh()
        {
            InitializeComponent();

        }
        public formManHinhChinh(string tenDangNhap, string matKhau, string quyen)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.quyen = quyen;

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool KiemTraTonTai(string frmName)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name.Equals(frmName))
                {
                    return true;
                }

            }
            return false;
        }
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_QLNV qlnv = new GUI_QLNV();

            if (KiemTraTonTai("GUI_QLNV") == true)
            {
                qlnv.Hide();
                qlnv.Activate();
                //qlnv.Close();
            }
            else
            {
                //this.Hide();
                //  qlnv.MdiParent = this;
                qlnv.Show();

            }

        }



        private void khuVựcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }











        private void formManHinhChinh_Validated(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pboxNhanVien_Click(object sender, EventArgs e)
        {
            if (quyen == "admin")
            {


                GUI_QLNV qlnv = new GUI_QLNV();

                if (KiemTraTonTai("GUI_QLNV") == true)
                {
                    qlnv.FormClosed += new FormClosedEventHandler(qlnv_formclosed);

                    qlnv.Activate();
                    this.Hide();
                    //qlnv.Close();
                }
                else
                {
                    qlnv.FormClosed += new FormClosedEventHandler(qlnv_formclosed);
                    //this.Hide();
                    //qlnv.MdiParent = this;
                    qlnv.Show();
                    this.Hide();

                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Thông báo");
            }
        }
        private void qlnv_formclosed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void pboxKhachhang_Click(object sender, EventArgs e)
        {

            GUI_QLKhachHang qlkh = new GUI_QLKhachHang();
            qlkh.FormClosed += new FormClosedEventHandler(qlnv_formclosed);
            if (KiemTraTonTai("GUI_QLKhachHang") == true)
            {

                qlkh.Activate();
                this.Hide();
            }
            else
            {
                //qlkh.MdiParent = this;
                qlkh.Show();
                this.Hide();
            }
        }

        private void pboxLoaiKhachHang_Click(object sender, EventArgs e)
        {
            if (quyen == "admin")
            {

                GUI_LoaiKH qllkh = new GUI_LoaiKH();
                qllkh.FormClosed += new FormClosedEventHandler(qlnv_formclosed);
                if (KiemTraTonTai("GUI_LoaiKH") == true)
                {

                    qllkh.Activate();
                    this.Hide();
                }
                else
                {
                    //  qllkh.MdiParent = this;
                    qllkh.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Thông báo");
            }
        }

        private void pboxKhuVuc_Click(object sender, EventArgs e)
        {
            if (quyen == "admin")
            {

                GUI_KhuVuc qlkv = new GUI_KhuVuc();
                qlkv.FormClosed += new FormClosedEventHandler(qlnv_formclosed);
                if (KiemTraTonTai("GUI_LoaiKH") == true)
                {

                    qlkv.Activate();
                    this.Hide();
                }
                else
                {
                    //  qllkh.MdiParent = this;
                    qlkv.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Thông báo");
            }
        }

        private void pboxMonAn_Click(object sender, EventArgs e)
        {
            if (quyen == "admin")
            {

                GUI_MonAn qlma = new GUI_MonAn();
                qlma.FormClosed += new FormClosedEventHandler(qlnv_formclosed);
                if (KiemTraTonTai("GUI_LoaiKH") == true)
                {

                    qlma.Activate();
                    this.Hide();
                }
                else
                {
                    //  qllkh.MdiParent = this;
                    qlma.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Thông báo");
            }
        }

        private void pboxBan_Click(object sender, EventArgs e)
        {
            if (quyen == "admin")
            {

                GUI_QLBan qlBan = new GUI_QLBan();
                qlBan.FormClosed += new FormClosedEventHandler(qlnv_formclosed);
                if (KiemTraTonTai("GUI_LoaiKH") == true)
                {

                    qlBan.Activate();
                    this.Hide();
                }
                else
                {
                    //  qllkh.MdiParent = this;
                    qlBan.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Thông báo");
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManHinhChinh main = new formManHinhChinh();

            GUI_Login login = new GUI_Login();
            main.Close();
            login.Show();
            this.Hide();
        }

        private void formManHinhChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.No)
            {
                e.Cancel = true;

            }

        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (quyen == "admin")
            {

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pbBanHang_Click(object sender, EventArgs e)
        {
            GUI_BanHang qlBanHang = new GUI_BanHang();
            qlBanHang.FormClosed += new FormClosedEventHandler(qlnv_formclosed);
            if (KiemTraTonTai("GUI_LoaiKH") == true)
            {

                qlBanHang.Activate();
                this.Hide();
            }
            else
            {
                //  qllkh.MdiParent = this;
                qlBanHang.Show();
                this.Hide();
            }

            //private void btnThoat_Click(object sender, EventArgs e)
            //{
            //    this.Close();
            //}

        }

        private void DoiMKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_DoiMatKhau dmk = new GUI_DoiMatKhau();
            dmk.FormClosed += new FormClosedEventHandler(qlnv_formclosed);
            if (KiemTraTonTai("GUI_LoaiKH") == true)
            {

                dmk.Activate();
                this.Hide();
            }
            else
            {
                //  qllkh.MdiParent = this;
                dmk.Show();
                this.Hide();
            }
        }
    }
}
