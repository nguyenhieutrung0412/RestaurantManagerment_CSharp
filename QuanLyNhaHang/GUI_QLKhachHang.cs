using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS_QLNH;
using ET_QLNH;
//using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhaHang
{
    public partial class GUI_QLKhachHang : Form
    {
        BUS_KhachHang bus_KH = new BUS_KhachHang();
        BUS_LoaiKH bus_LoaiKH = new BUS_LoaiKH();
      
        public GUI_QLKhachHang()
        {
            InitializeComponent();
        }

      
        void FillCombobox()
        {
            DataTable table = bus_LoaiKH.DSLoaiKH();
            cboLoaiKH.DataSource = table;
            cboLoaiKH.DisplayMember = "TenLoaiKH";
            cboLoaiKH.ValueMember = "MaLoaiKH";

        }

        private void GUI_QLKhachHang_Load(object sender, EventArgs e)
        {
          //  this.Hide();
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.DataSource = bus_KH.DSKH();
            FillCombobox();
            btnThem.Enabled = false;
        }

        private void txtMaKH_Validated(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                txtMaKH.Focus();
                this.errorProvider1.SetError(txtMaKH, "Không được để trống");
            }
            else
            {
                this.errorProvider1.Clear();
                btnThem.Enabled = true;
            }
        }

        private void txthoTen_Validated(object sender, EventArgs e)
        {
            if (txthoTen.Text == "")
            {
                txthoTen.Focus();
                this.errorProvider1.SetError(txthoTen, "Không được để trống");
            }
            for (int i = 0; i < txthoTen.Text.Length; i++)
            {
                if (char.IsDigit(txthoTen.Text[i]))
                {
                    txthoTen.Text = "";
                    txthoTen.Focus();
                    this.errorProvider1.SetError(txthoTen, "không được nhập số");
                }
                else
                {
                    this.errorProvider1.Clear();
                }
            }
        }

        private void txtSDT_Validated(object sender, EventArgs e)
        {
            if (txtSDT.Text == "")
            {
                txtSDT.Focus();
                this.errorProvider1.SetError(txtSDT, "Không được để trống");
            }
            for (int i = 0; i < txtSDT.Text.Length; i++)
            {
                if (!char.IsDigit(txtSDT.Text[i]))
                {
                    txtSDT.Text = "";
                    txtSDT.Focus();
                    this.errorProvider1.SetError(txthoTen, "không được nhập chữ ");
                }
                else
                {
                    this.errorProvider1.Clear();
                }
            }
        }

        private void txtDiaChi_Validated(object sender, EventArgs e)
        {
            if (txtDiaChi.Text == "")
            {
                txtDiaChi.Focus();
                this.errorProvider1.SetError(txtDiaChi, "Không được để trống");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void txtEmail_Validated(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Focus();
                this.errorProvider1.SetError(txtEmail, "Không được để trống");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void cboLoaiKH_Validated(object sender, EventArgs e)
        {

        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString();
            txthoTen.Text = dgvKhachHang.Rows[e.RowIndex].Cells[1].Value.ToString();
            //dtpNgaySinh.Text = dgvNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString();

            //string gioiTinh = dgvNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString();
            //if (gioiTinh == "Nam")
            //{
            //    rdNam.Checked = true;

            //}
            //if (gioiTinh == "Nu")
            //{
            //    rdNu.Checked = true;
            //}

            txtSDT.Text = dgvKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.Rows[e.RowIndex].Cells[3].Value.ToString();
          
            txtEmail.Text = dgvKhachHang.Rows[e.RowIndex].Cells[4].Value.ToString();
            cboLoaiKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string sMaKH = txtMaKH.Text;
            string sHoten = txthoTen.Text;
            string sSDT = txtSDT.Text;
            string sDiaChi = txtDiaChi.Text;
        
            string sEmail = txtEmail.Text;
            string sMaloai = cboLoaiKH.SelectedValue.ToString();
            ET_KhachHang kh = new ET_KhachHang();
            kh.MaNV = sMaKH;
            kh.HoTen = sHoten;
            kh.SSDT = sSDT;
            kh.SDiaChi = sDiaChi;

            kh.SEmail = sEmail;
            kh.SMaLoai = sMaloai;
            







            if (bus_KH.ThemKH(kh) > 0)
            {
                MessageBox.Show("Thêm thành công ", "Thông báo");
                dgvKhachHang.DataSource = bus_KH.DSKH();


            }
            else
            {
                MessageBox.Show("Them khong thanh cong", "thong báo");
            }

        }

    

        private void GUI_QLKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            //formManHinhChinh main = new formManHinhChinh();
            //main.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dir = MessageBox.Show("Bạn có muốn xóa thông tin này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            ET_KhachHang kh = new ET_KhachHang();
            kh.MaNV = txtMaKH.Text;
            if (dir == DialogResult.Yes)
            {
                if (bus_KH.XoaLoaiKH(kh) != 0)
                {
                    MessageBox.Show("Xoa thành công ", "Thông báo");
                    dgvKhachHang.DataSource = bus_KH.DSKH();


                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dir = MessageBox.Show("Bạn có muốn sửa thông tin này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string sMaKH = txtMaKH.Text;
            string sHoten = txthoTen.Text;

            string sSDT = txtSDT.Text;

            string sDiaChi = txtDiaChi.Text;
           
            string sEmail = txtEmail.Text;
            string sMaLoai = cboLoaiKH.SelectedValue.ToString();
            ET_KhachHang kh = new ET_KhachHang();
            kh.MaNV = sMaKH;
            kh.HoTen = sHoten;
         
            kh.SDiaChi = sDiaChi;
            kh.SSDT = sSDT;
            kh.SEmail = sEmail;
            if (dir == DialogResult.Yes)
            {
                bus_KH.SuaLoaiKH(kh);
                MessageBox.Show("Sửa thành công", "Thông báo");
                dgvKhachHang.DataSource = bus_KH.DSKH();
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "Thông báo");
            }
        }

        private void cboLoaiKH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
