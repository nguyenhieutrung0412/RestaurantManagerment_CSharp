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
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

namespace QuanLyNhaHang
{
    public partial class GUI_BanHang : Form
    {
        ET_Ban et_ban = new ET_Ban();
        public int width = 80;
        public int height = 80;
        BUS_Ban listBan = new BUS_Ban();
        BUS_MonAn monAn = new BUS_MonAn();
        BUS_NhanVien nv = new BUS_NhanVien();
        BUS_Bill bus_bill = new BUS_Bill();
        BUS_LoaiMonAn bus_LoaiMonAn = new BUS_LoaiMonAn();
        BUS_ThanhToan bus_ThanhToan = new BUS_ThanhToan();
        public GUI_BanHang()
        {
            InitializeComponent();
        }

        private void GUI_BanHang_Load(object sender, EventArgs e)
        {
            loadTableList();
            
            LoadListNhanVien();
            ColumnsListView();
            loadListLoaiMonAn();
        }
        void ColumnsListView()
        {
           
          //  lvBill.Columns.Add("Mã bill", 50);
          //  lvBill.Columns.Add("Mã NV ", 70);
            //lvBill.Columns.Add("Mã bàn", 50);
            lvBill.Columns.Add("Món ăn", 150);
            lvBill.Columns.Add("Giá", 100);
            lvBill.Columns.Add("Số lượng", 60);
           
            lvBill.Columns.Add("Thành tiền", 120);
        }
        void LoadListNhanVien()
        {
            DataTable table = nv.LayDSNhanVien();
            cboNhanVien.DataSource = table;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";
        }
        void LoadListMonAn(string maLoai)
        {
            List<ET_MonAn> listMonAn = monAn.ListMonAnByMaLoai(maLoai);
            cboMonAn.DataSource = listMonAn;
            cboMonAn.DisplayMember = "TenMonAn";
            cboMonAn.ValueMember = "MaMonAn";
        }
        void loadListLoaiMonAn()
        {
            List<ET_LoaiMonAn> listLoaiMonAn = bus_LoaiMonAn.GetListLoaiMonAn();
            cboLoaiMonAn.DataSource = listLoaiMonAn;
            cboLoaiMonAn.DisplayMember = "TenLoai";
        }
        void loadTableList()
        {
            floTable.Controls.Clear();
            List<ET_Ban> listTable = listBan.listBan();
            foreach (ET_Ban item in listTable)
            {
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button() {Width = width,Height = height };
             
                btn.Text = item.MaBan + Environment.NewLine + item.TrangThai;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.TrangThai)
                {
                    case "Không Hoạt động ":
                        btn.BackColor = Color.IndianRed;
                        break;

                    default:
                        btn.BackColor = Color.LightGreen;
                        break;
                }
                floTable.Controls.Add(btn);

            }
        }
        void ShowBill(string maBan)
        {
            lvBill.Items.Clear();
            float tongTien = 0;
            List<ET_Bill> listBillInfo = bus_bill.ListBill(maBan);
            foreach (ET_Bill item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.MonAn1);
                //lsvItem.SubItems.Add(item.MonAn1);
                lsvItem.SubItems.Add(item.Gia.ToString());
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.TongTien.ToString());
                tongTien += item.TongTien;
                lvBill.Items.Add(lsvItem);
            }
            CultureInfo c = new CultureInfo("vi-VN");
           
            txtTongTien.Text = tongTien.ToString("c",c);
        }
        private void btn_Click(object sender, EventArgs e)
        {
            string maBan = ((sender as System.Windows.Forms.Button).Tag as ET_Ban).MaBan;
            lvBill.Tag = (sender as System.Windows.Forms.Button).Tag;
            ShowBill(maBan);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ET_Ban table = lvBill.Tag as ET_Ban;
            int idBill = bus_bill.GetMaThanhToanByMaBan(table.MaBan.ToString());
            string MaMonAn = (cboMonAn.SelectedItem as ET_MonAn).MaMonAn;
            int soLuong = (int)nmFoodCount.Value;
            if(idBill == -1)
            {
                bus_ThanhToan.InsertThanhToan(table.MaBan.ToString());
                bus_bill.ThemBill(bus_ThanhToan.GetMaxIdBill(), MaMonAn, soLuong);
            }
            else
            {
                 bus_bill.ThemBill(idBill, MaMonAn, soLuong);
            }
            ShowBill(table.MaBan.ToString());
            loadTableList();


        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            ET_Ban table = lvBill.Tag as ET_Ban;
            int idBill = bus_bill.GetMaThanhToanByMaBan(table.MaBan.ToString());
            double tongTien = Convert.ToDouble(txtTongTien.Text.Split(',')[0]);

            if (idBill != -1)
            {
                DialogResult d = MessageBox.Show("Bạn có muốn thanh toán bàn " + table.MaBan, "Thông báo",MessageBoxButtons.OKCancel);
                if(d == DialogResult.OK)
                {
                    bus_ThanhToan.ThanhToan(idBill);
                    MessageBox.Show("Thanh toán thành công \n Tổng tiền : " + tongTien);
                    ShowBill(table.MaBan);
                 
                    loadTableList();
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboLoaiMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maLoai = "";
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            ET_LoaiMonAn selected = cb.SelectedItem as ET_LoaiMonAn;
            maLoai = selected.MaLoai;

            LoadListMonAn(maLoai);

        }

    
    }
}
