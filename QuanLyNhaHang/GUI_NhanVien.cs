using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS_QLNH;
using ET_QLNH;

namespace QuanLyNhaHang
{
    public partial class GUI_QLNV : Form
    {
        public GUI_QLNV()
        {
            InitializeComponent();
        }
        BUS_NhanVien bus_NhanVien = new BUS_NhanVien();
       
        private void rdNu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GUI_ThemNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvNhanVien.DataSource = bus_NhanVien.LayDSNhanVien();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không load được dữ liệu ", ex.Message);
            }
          
            rdNam.Checked = true;
            btnThem.Enabled = false;
        }

        private void txtMaNV_Validated(object sender, EventArgs e)
        {
            if(txtMaNV.Text == "")
            {
                //txtMaNV.Focus();
                this.errorProvider1.SetError(txtMaNV, "Không được để trống");
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sMaNV = txtMaNV.Text;
            string sHoten = txthoTen.Text;
            
            string sNgaySinh = dtpNgaySinh.Text;
            string sGioiTinh = "";
            if (rdNam.Checked == true)
            {
                sGioiTinh = "Nam";
            }
            if (rdNu.Checked == true)
            {
                sGioiTinh = "Nữ";
            }
            
            
            string sDiaChi = txtDiaChi.Text;
            string sSDT = txtSDT.Text;
            string sEmail = txtEmail.Text;
            ETNhanVien nv = new ETNhanVien();
            nv.MaNV = sMaNV;
            nv.HoTen = sHoten;
            nv.SNgaySinh = sNgaySinh;
            nv.SGioiTinh = sGioiTinh;
            nv.SDiaChi = sDiaChi;
            nv.SSDT = sSDT;
            nv.SEmail = sEmail;







            if (bus_NhanVien.ThemNhanVien(nv) > 0)
            {
                MessageBox.Show("Them thanh cong ", "thong báo");
                dgvNhanVien.DataSource = bus_NhanVien.LayDSNhanVien();


            }
            else
            {
                MessageBox.Show("Them khong thanh cong", "thong báo");
            }

        }

        private void grTim_Enter(object sender, EventArgs e)
        {

        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString();
            txthoTen.Text = dgvNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString();
           
            string gioiTinh = dgvNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (gioiTinh == "Nam")
            {
                rdNam.Checked = true;

            }
            if (gioiTinh == "Nu")
            {
                rdNu.Checked = true;
            }

          
            txtDiaChi.Text = dgvNhanVien.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEmail.Text = dgvNhanVien.Rows[e.RowIndex].Cells[6].Value.ToString();
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            DialogResult dir = MessageBox.Show("Ban co muon xoa khong ?", "THong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
       
            ETNhanVien nv = new ETNhanVien();
            nv.MaNV = txtMaNV.Text;
            if (dir == DialogResult.Yes)
            {
                if (bus_NhanVien.XoaNhanVien(nv) != 0)
                {
                    MessageBox.Show("Xoa thành công ", "Thông báo");
                    dgvNhanVien.DataSource = bus_NhanVien.LayDSNhanVien();


                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dir = MessageBox.Show("Bạn có muốn sửa thông tin này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string sMaNV = txtMaNV.Text;
            string sHoten = txthoTen.Text;

            string sNgaySinh = dtpNgaySinh.Text;
            string sGioiTinh = "";
            if (rdNam.Checked == true)
            {
                sGioiTinh = "Nam";
            }
            if (rdNu.Checked == true)
            {
                sGioiTinh = "Nữ";
            }


            string sDiaChi = txtDiaChi.Text;
            string sSDT = txtSDT.Text;
            string sEmail = txtEmail.Text;
            ETNhanVien nv = new ETNhanVien();
            nv.MaNV = sMaNV;
            nv.HoTen = sHoten;
            nv.SNgaySinh = sNgaySinh;
            nv.SGioiTinh = sGioiTinh;
            nv.SDiaChi = sDiaChi;
            nv.SSDT = sSDT;
            nv.SEmail = sEmail;
            if (dir == DialogResult.Yes)
            {
                bus_NhanVien.SuaNhanVien(nv);
                MessageBox.Show("Sửa thành công", "Thông báo");
                dgvNhanVien.DataSource = bus_NhanVien.LayDSNhanVien();
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "Thông báo");
            }

        }

        private void GUI_QLNV_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sMaNV = txtTimMaNV.Text;
            ETNhanVien nv = new ETNhanVien();
            nv.MaNV = sMaNV;
            //if (bus_NhanVien.TimNhanVien(nv) == true)
            //{
                // bus_NhanVien.TimNhanVien(nv);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                MessageBox.Show("Tìm thành công", "Thông báo");
                dgvNhanVien.DataSource = bus_NhanVien.TimNhanVien(nv);
            //}
            //else
            //{
            //    MessageBox.Show("Tìm thất bại", "Thông báo");
            //}
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
 }
    

