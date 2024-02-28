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

namespace QuanLyNhaHang
{
    public partial class GUI_LoaiKH : Form
    {
        BUS_LoaiKH busLoaiKH = new BUS_LoaiKH();
        public GUI_LoaiKH()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void GUI_LoaiKH_Load(object sender, EventArgs e)
        {
            dgvLoaiKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoaiKH.DataSource = busLoaiKH.DSLoaiKH();
        }

        private void txtMaLoai_Validated(object sender, EventArgs e)
        {
            if (txtMaLoai.Text == "")
            {
                txtMaLoai.Focus();
                this.errorProvider1.SetError(txtMaLoai, "Không được để trống");
            }
            else
            {
                this.errorProvider1.Clear();
                btnThem.Enabled = true;
            }
        }

        private void txtTenLoai_Validated(object sender, EventArgs e)
        {
            if (txtTenLoai.Text == "")
            {
                txtTenLoai.Focus();
                this.errorProvider1.SetError(txtTenLoai, "Không được để trống");
            }
            else
            {
                this.errorProvider1.Clear();
                btnThem.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sMaLoai = txtMaLoai.Text;
            string sTenLoai = txtTenLoai.Text;
            ET_LoaiKH kh = new ET_LoaiKH();
            kh.MaLoaiKh = sMaLoai;
            kh.TenLoaiKH = sTenLoai;
            if (busLoaiKH.ThemLoaiKH(kh) > 0)
            {
                MessageBox.Show("Thêm thành công ", "Thông báo");
                dgvLoaiKH.DataSource = busLoaiKH.DSLoaiKH();


            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dir = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            ET_LoaiKH kh = new ET_LoaiKH();
            kh.MaLoaiKh = txtMaLoai.Text;
            if (dir == DialogResult.Yes)
            {
                if (busLoaiKH.XoaLoaiKH(kh) > 0)
                {
                    MessageBox.Show("Xóa thành công ", "Thông báo");
                    dgvLoaiKH.DataSource = busLoaiKH.DSLoaiKH();

                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sMaLoai = txtMaLoai.Text;
            string sTenLoai = txtTenLoai.Text;
            ET_LoaiKH kh = new ET_LoaiKH();
            kh.MaLoaiKh = sMaLoai;
            kh.TenLoaiKH = sTenLoai;
            DialogResult dir = MessageBox.Show("Bạn có muốn sửa thông tin này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dir == DialogResult.Yes)
            {
                busLoaiKH.SuaLoaiKH(kh);
                MessageBox.Show("Sửa thành công", "Thông báo");
                dgvLoaiKH.DataSource = busLoaiKH.DSLoaiKH();
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "Thông báo");
            }
        }

        private void dgvLoaiKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLoai.Text = dgvLoaiKH.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenLoai.Text = dgvLoaiKH.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void GUI_LoaiKH_FormClosing(object sender, FormClosingEventArgs e)
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
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
