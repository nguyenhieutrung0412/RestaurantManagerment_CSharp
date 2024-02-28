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
    public partial class GUI_MonAn : Form
    {
        BUS_LoaiMonAn bus_LoaiMonAn = new BUS_LoaiMonAn();
        public GUI_MonAn()
        {
            InitializeComponent();
        }
        BUS_MonAn bus_MonAn = new BUS_MonAn();
        private void GUI_MonAn_Load(object sender, EventArgs e)
        {
            dgvMonAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonAn.DataSource = bus_MonAn.DSMonAn();
            btnThem.Enabled = false;
            ComboboxLoaiMonAn();
        }
        void ComboboxLoaiMonAn()
        {
            DataTable table = bus_LoaiMonAn.LayDSLoaiMonAn();
            cboLoaiMonAn.DataSource = table;
            cboLoaiMonAn.DisplayMember = "TenLoai";
            cboLoaiMonAn.ValueMember = "MaLoai";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string sMaMonAn = txtMaMonAn.Text;
            string sTenMonAn = txtTenMonAn.Text;
            float sDonGia = float.Parse( txtDonGia.Text);

            ET_MonAn ma = new ET_MonAn();
            ma.MaMonAn = sMaMonAn;
            ma.TenMonAn = sTenMonAn;
            ma.DonGia = sDonGia;
            if (bus_MonAn.ThemMonAn(ma) > 0)
            {
                MessageBox.Show("Thêm thành công ", "Thông báo");
                dgvMonAn.DataSource = bus_MonAn.DSMonAn();


            }
            else
            {
                MessageBox.Show("Thêm thất bại", "thong báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dir = MessageBox.Show("Bạn có muốn xóa thông tin này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            ET_MonAn ma = new ET_MonAn();
            ma.MaMonAn = txtMaMonAn.Text;
            if (dir == DialogResult.Yes)
            {
                if (bus_MonAn.XoaMonAn(ma) != 0)
                {
                    MessageBox.Show("Xóa thành công ", "Thông báo");
                    dgvMonAn.DataSource = bus_MonAn.DSMonAn();


                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dir = MessageBox.Show("Bạn có muốn sửa thông tin này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string sMaMonAn = txtMaMonAn.Text;
            string sTenMonAn = txtTenMonAn.Text;
            float sDonGia = float.Parse(txtDonGia.Text);

            ET_MonAn ma = new ET_MonAn();
            ma.MaMonAn = sMaMonAn;
            ma.TenMonAn = sTenMonAn;
            ma.DonGia = sDonGia;
            if (dir == DialogResult.Yes)
            {
                bus_MonAn.SuaMonAn(ma);
                MessageBox.Show("Sửa thành công", "Thông báo");
                dgvMonAn.DataSource = bus_MonAn.DSMonAn();
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "Thông báo");
            }
        }

        private void dgvMonAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaMonAn.Text = dgvMonAn.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenMonAn.Text = dgvMonAn.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDonGia.Text = dgvMonAn.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void GUI_MonAn_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtMaMonAn_Validated(object sender, EventArgs e)
        {
            if (txtMaMonAn.Text == "")
            {
                txtMaMonAn.Focus();
                this.errorProvider1.SetError(txtMaMonAn, "Không được để trống");
            }
            else
            {
                this.errorProvider1.Clear();
                btnThem.Enabled = true;
            }
        }
    }
    
}
