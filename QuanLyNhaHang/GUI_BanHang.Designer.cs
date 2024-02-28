namespace QuanLyNhaHang
{
    partial class GUI_BanHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvBill = new System.Windows.Forms.ListView();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.cboMonAn = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboLoaiMonAn = new System.Windows.Forms.ComboBox();
            this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
            this.btnThem = new System.Windows.Forms.Button();
            this.floTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvBill);
            this.panel2.Controls.Add(this.txtTongTien);
            this.panel2.Controls.Add(this.cboNhanVien);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnThanhToan);
            this.panel2.Location = new System.Drawing.Point(479, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 531);
            this.panel2.TabIndex = 1;
            // 
            // lvBill
            // 
            this.lvBill.GridLines = true;
            this.lvBill.Location = new System.Drawing.Point(0, 3);
            this.lvBill.Name = "lvBill";
            this.lvBill.Size = new System.Drawing.Size(534, 442);
            this.lvBill.TabIndex = 6;
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(368, 451);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(117, 22);
            this.txtTongTien.TabIndex = 5;
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(197, 489);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(187, 24);
            this.cboNhanVien.TabIndex = 1;
            this.cboNhanVien.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 454);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tổng tiền :";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(390, 482);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(95, 37);
            this.btnThanhToan.TabIndex = 3;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // cboMonAn
            // 
            this.cboMonAn.FormattingEnabled = true;
            this.cboMonAn.Location = new System.Drawing.Point(23, 45);
            this.cboMonAn.Name = "cboMonAn";
            this.cboMonAn.Size = new System.Drawing.Size(261, 24);
            this.cboMonAn.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cboLoaiMonAn);
            this.panel3.Controls.Add(this.nmFoodCount);
            this.panel3.Controls.Add(this.btnThem);
            this.panel3.Controls.Add(this.cboMonAn);
            this.panel3.Location = new System.Drawing.Point(493, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(520, 83);
            this.panel3.TabIndex = 2;
            // 
            // cboLoaiMonAn
            // 
            this.cboLoaiMonAn.FormattingEnabled = true;
            this.cboLoaiMonAn.Location = new System.Drawing.Point(23, 11);
            this.cboLoaiMonAn.Name = "cboLoaiMonAn";
            this.cboLoaiMonAn.Size = new System.Drawing.Size(261, 24);
            this.cboLoaiMonAn.TabIndex = 4;
            this.cboLoaiMonAn.SelectedIndexChanged += new System.EventHandler(this.cboLoaiMonAn_SelectedIndexChanged);
            // 
            // nmFoodCount
            // 
            this.nmFoodCount.Location = new System.Drawing.Point(402, 30);
            this.nmFoodCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmFoodCount.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nmFoodCount.Name = "nmFoodCount";
            this.nmFoodCount.Size = new System.Drawing.Size(65, 22);
            this.nmFoodCount.TabIndex = 3;
            this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(312, 11);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 58);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // floTable
            // 
            this.floTable.AutoScroll = true;
            this.floTable.Location = new System.Drawing.Point(2, 1);
            this.floTable.Name = "floTable";
            this.floTable.Size = new System.Drawing.Size(471, 620);
            this.floTable.TabIndex = 3;
            // 
            // GUI_BanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 621);
            this.Controls.Add(this.floTable);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "GUI_BanHang";
            this.Text = "GUI_BanHang";
            this.Load += new System.EventHandler(this.GUI_BanHang_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.ComboBox cboMonAn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.FlowLayoutPanel floTable;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvBill;
        private System.Windows.Forms.ComboBox cboLoaiMonAn;
    }
}