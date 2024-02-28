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
    public partial class GUI_KhuVuc : Form
    {
        public GUI_KhuVuc()
        {
            InitializeComponent();
        }
        BUS_KhuVuc bus_KhuVuc = new BUS_KhuVuc();
        private void GUI_KhuVuc_Load(object sender, EventArgs e)
        {

            dgvKhuVuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhuVuc.DataSource = bus_KhuVuc.DSKhuVuc();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sMaKV = txtMaKhuVuc.Text;
            string sTenKV = txtTenKhuVuc.Text;
            string sTrangThai = cboTrangThai.Text;

            ET_KhuVuc kv = new ET_KhuVuc();
            kv.MaKhuVuc = sMaKV;
            kv.TenKhuVuc = sTenKV;
            kv.TrangThai = sTrangThai;
            if (bus_KhuVuc.ThemKV(kv) > 0)
            {
                MessageBox.Show("Thêm thành công ", "Thông báo");
                dgvKhuVuc.DataSource = bus_KhuVuc.DSKhuVuc();


            }
            else
            {
                MessageBox.Show("Thêm thất bại", "thong báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dir = MessageBox.Show("Bạn có muốn xóa thông tin này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            ET_KhuVuc kv = new ET_KhuVuc();
            kv.MaKhuVuc = txtMaKhuVuc.Text;
            if (dir == DialogResult.Yes)
            {
                if (bus_KhuVuc.XoaKV(kv) != 0)
                {
                    MessageBox.Show("Xóa thành công ", "Thông báo");
                    dgvKhuVuc.DataSource = bus_KhuVuc.DSKhuVuc();


                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dir = MessageBox.Show("Bạn có muốn sửa thông tin này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string sMaKV = txtMaKhuVuc.Text;
            string sTenKV = txtTenKhuVuc.Text;
            string sTrangThai = cboTrangThai.Text;

            ET_KhuVuc kv = new ET_KhuVuc();
            kv.MaKhuVuc = sMaKV;
            kv.TenKhuVuc = sTenKV;
            kv.TrangThai = sTrangThai;
            if (dir == DialogResult.Yes)
            {
                bus_KhuVuc.SuaKV(kv);
                MessageBox.Show("Sửa thành công", "Thông báo");
                dgvKhuVuc.DataSource = bus_KhuVuc.DSKhuVuc();
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "Thông báo");
            }
        }

        private void dgvKhuVuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKhuVuc.Text = dgvKhuVuc.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenKhuVuc.Text = dgvKhuVuc.Rows[e.RowIndex].Cells[1].Value.ToString();
            cboTrangThai.Text = dgvKhuVuc.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void GUI_KhuVuc_FormClosing(object sender, FormClosingEventArgs e)
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
        private void txtMaKhuVuc_Validated(object sender, EventArgs e)
        {
            if (txtMaKhuVuc.Text == "")
            {
                txtMaKhuVuc.Focus();
                this.errorProvider1.SetError(txtMaKhuVuc, "Không được để trống");
            }
            else
            {
                this.errorProvider1.Clear();
                btnThem.Enabled = true;
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
