using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ET_QLNH;
using System.Data;
using BUS_QLNH;

namespace QuanLyNhaHang
{
    public partial class GUI_DoiMatKhau : Form
    {
        string taiKhoan = "";
        string matKhau = "";
        BUS_DoiMK doimk = new BUS_DoiMK();
        public GUI_DoiMatKhau()
        {
            InitializeComponent();
        }
        public GUI_DoiMatKhau(string taiKhoan, string matKhau)
        {
            InitializeComponent();
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
        }


        private void btnDongY_Click(object sender, EventArgs e)
        {
            if(txtMKCu.Text == "" || txtMKMoi.Text == ""||txtNhapLaiMK.Text == "")
            {
                MessageBox.Show("Bạn cần điền đủ thông tin", "Thông báo");

            }
            else if(txtNhapLaiMK.Text != txtMKMoi.Text)
            {
                MessageBox.Show("Nhâp lại mật khẩu mới không khớp", "Thông báo");
            }
            else
            {
                taiKhoan = txtTenDangNhap.Text;
                matKhau = txtMKCu.Text;
                string matKhauMoi = txtMKMoi.Text;
                ET_DoiMk mk = new ET_DoiMk();
                mk.TaiKhoan = taiKhoan;
                mk.MatKhau = matKhau;
                mk.MatKhauMoi = matKhauMoi;
                if(doimk.DoiMatKhau(mk) > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại", "Thông báo");
                }
                
            }
        }

        private void GUI_DoiMatKhau_Load(object sender, EventArgs e)
        {
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
