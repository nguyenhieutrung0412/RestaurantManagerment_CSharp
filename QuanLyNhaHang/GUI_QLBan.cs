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
    public partial class GUI_QLBan : Form
    {
        public GUI_QLBan()
        {
            InitializeComponent();
        }
        BUS_Ban bus_Ban = new BUS_Ban();
        BUS_KhuVuc bus_khuVuc = new BUS_KhuVuc();
        private void GUI_QLBan_Load(object sender, EventArgs e)
        {
            dgvBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBan.DataSource = bus_Ban.DSBan();
            FillCombobox();
            btnThem.Enabled = false;
        }

        void FillCombobox()
        {
            DataTable table = bus_khuVuc.DSKhuVuc();
            cboMaKhuVuc.DataSource = table;
            cboMaKhuVuc.DisplayMember = "TenKhuVuc";
            cboMaKhuVuc.ValueMember = "MaKhuVuc";

        }

        private void txtMaBan_Validated(object sender, EventArgs e)
        {
            if (txtMaBan.Text == "")
            {
                txtMaBan.Focus();
                this.errorProvider1.SetError(txtMaBan, "Không được để trống");
            }
            else
            {
                this.errorProvider1.Clear();
                btnThem.Enabled = true;
            }
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cboTrangThai.SelectedItem == " ")
            //{
            //    MessageBox.Show("Vui lòng chọn trạng thái ","Thông báo");
            //}
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //string c = cboTrangThai.SelectedValue.ToString();
            //if (c == "")
            //{
            //    MessageBox.Show("Vui lòng chọn trạng thái ", "Thông báo");
            //}
            string sMaBan = txtMaBan.Text;
            string sTrangThai = cboTrangThai.Text;
            string sMaKhuVUc = cboMaKhuVuc.SelectedValue.ToString();
           
            ET_Ban ban = new ET_Ban();
            ban.MaBan = sMaBan;
            ban.TrangThai = sTrangThai;
            ban.MaKhuVuc = sMaKhuVUc;

            if (bus_Ban.ThemBan(ban) > 0)
            {
                MessageBox.Show("Thêm thành công ", "Thông báo");
                dgvBan.DataSource = bus_Ban.DSBan();


            }
            else
            {
                MessageBox.Show("Thêm thất bại", "thong báo");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dir = MessageBox.Show("Bạn có muốn xóa thông tin này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            ET_Ban ban = new ET_Ban();
            ban.MaBan = txtMaBan.Text;
            if (dir == DialogResult.Yes)
            {
                if (bus_Ban.XoaBan(ban) != 0)
                {
                    MessageBox.Show("Xóa thành công ", "Thông báo");
                    dgvBan.DataSource = bus_Ban.DSBan();


                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dir = MessageBox.Show("Bạn có muốn sửa thông tin này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string sMaBan = txtMaBan.Text;
            string sTrangThai = cboTrangThai.Text;
            string sMaKhuVUc = cboMaKhuVuc.SelectedValue.ToString(); ;

            ET_Ban ban = new ET_Ban();
            ban.MaBan = sMaBan;
            ban.TrangThai = sTrangThai;
            ban.MaKhuVuc = sMaKhuVUc;
            if (dir == DialogResult.Yes)
            {
                bus_Ban.SuaBan(ban);
                MessageBox.Show("Sửa thành công", "Thông báo");
                dgvBan.DataSource = bus_Ban.DSBan();
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "Thông báo");
            }
        }

        private void dgvBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaBan.Text = dgvBan.Rows[e.RowIndex].Cells[0].Value.ToString();
            cboTrangThai.Text = dgvBan.Rows[e.RowIndex].Cells[1].Value.ToString();
            cboMaKhuVuc.Text = dgvBan.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void GUI_QLBan_FormClosing(object sender, FormClosingEventArgs e)
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
    }
    
}
