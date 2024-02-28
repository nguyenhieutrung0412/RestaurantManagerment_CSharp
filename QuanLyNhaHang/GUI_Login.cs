using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS_QLNH;
using System.Data;
using ET_QLNH;

namespace QuanLyNhaHang
{
    public partial class GUI_Login : Form
    {
        BUS_Login bus_login = new BUS_Login();
     
        public GUI_Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtTaiKhoan_Validating(object sender, CancelEventArgs e)
        {
            if(txtTaiKhoan.Text == "")
            {
                errorProvider1.SetError(txtTaiKhoan, "Không được để trống");
                txtTaiKhoan.Focus();
            }
            else
            {
                this.errorProvider1.Clear();
            }
            
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            ET_Login et_login = new ET_Login();
            et_login.TenDangNhap = tenDangNhap;
            et_login.MatKhau = matKhau;
            DataTable dt = new DataTable();
            dt = bus_login.CheckLogin(et_login);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công!");
                this.Hide();
                formManHinhChinh formMain = new formManHinhChinh(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                formMain.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai!");
            }
            //if(txtTaiKhoan.Text == "admin" & txtMatKhau.Text =="admin")
            //{
            //    MessageBox.Show("Đăng nhập thành công!");
            //    //GUI_Login formLogin = new GUI_Login();
            //    //formLogin.Close();
            //    this.Hide();
            //    formManHinhChinh formMain = new formManHinhChinh();
            //    formMain.ShowDialog();


            //}
            //else if(txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            //{
            //    MessageBox.Show("Tài khoản hoặc mật khẩu không được để trống!");

            //}

        }

        private void GUI_Login_Load(object sender, EventArgs e)
        {

        }

        private void GUI_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(thoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
