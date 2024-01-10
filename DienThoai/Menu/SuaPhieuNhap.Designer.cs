namespace DienThoai.Menu
{
    partial class SuaPhieuNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuaPhieuNhap));
            this.btnSaveQuantity = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTenDienThoai = new System.Windows.Forms.TextBox();
            this.txtMaDienThoai = new System.Windows.Forms.TextBox();
            this.txtSoLuongSanPham = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdateQuantity = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaPhieuNhap = new System.Windows.Forms.TextBox();
            this.txtNguoiTaoPhieu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvPhieuNhap = new System.Windows.Forms.DataGridView();
            this.MASANPHAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENSANPHAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONGNHAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DONGIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.MADIENTHOAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENDIENTHOAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveQuantity
            // 
            this.btnSaveQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveQuantity.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveQuantity.Image")));
            this.btnSaveQuantity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveQuantity.Location = new System.Drawing.Point(219, 24);
            this.btnSaveQuantity.Name = "btnSaveQuantity";
            this.btnSaveQuantity.Size = new System.Drawing.Size(167, 35);
            this.btnSaveQuantity.TabIndex = 37;
            this.btnSaveQuantity.Text = "Cập nhật số lượng";
            this.btnSaveQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveQuantity.UseVisualStyleBackColor = true;
            this.btnSaveQuantity.Click += new System.EventHandler(this.btnSaveQuantity_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(128, 122);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoLuong.Multiline = true;
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.ReadOnly = true;
            this.txtSoLuong.Size = new System.Drawing.Size(168, 25);
            this.txtSoLuong.TabIndex = 1;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(128, 96);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtDonGia.Multiline = true;
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(258, 25);
            this.txtDonGia.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Số lượng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTenDienThoai);
            this.groupBox1.Controls.Add(this.txtMaDienThoai);
            this.groupBox1.Controls.Add(this.txtDonGia);
            this.groupBox1.Controls.Add(this.txtSoLuongSanPham);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(553, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 164);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sản phẩm";
            // 
            // txtTenDienThoai
            // 
            this.txtTenDienThoai.Location = new System.Drawing.Point(128, 63);
            this.txtTenDienThoai.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenDienThoai.Multiline = true;
            this.txtTenDienThoai.Name = "txtTenDienThoai";
            this.txtTenDienThoai.ReadOnly = true;
            this.txtTenDienThoai.Size = new System.Drawing.Size(258, 25);
            this.txtTenDienThoai.TabIndex = 1;
            // 
            // txtMaDienThoai
            // 
            this.txtMaDienThoai.Location = new System.Drawing.Point(128, 30);
            this.txtMaDienThoai.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaDienThoai.Multiline = true;
            this.txtMaDienThoai.Name = "txtMaDienThoai";
            this.txtMaDienThoai.ReadOnly = true;
            this.txtMaDienThoai.Size = new System.Drawing.Size(258, 25);
            this.txtMaDienThoai.TabIndex = 1;
            // 
            // txtSoLuongSanPham
            // 
            this.txtSoLuongSanPham.Location = new System.Drawing.Point(128, 129);
            this.txtSoLuongSanPham.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoLuongSanPham.Multiline = true;
            this.txtSoLuongSanPham.Name = "txtSoLuongSanPham";
            this.txtSoLuongSanPham.ReadOnly = true;
            this.txtSoLuongSanPham.Size = new System.Drawing.Size(258, 25);
            this.txtSoLuongSanPham.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mã điện thoại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Đơn giá";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "Tên điện thoại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Số lượng";
            // 
            // btnUpdateQuantity
            // 
            this.btnUpdateQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateQuantity.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateQuantity.Image")));
            this.btnUpdateQuantity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateQuantity.Location = new System.Drawing.Point(46, 24);
            this.btnUpdateQuantity.Name = "btnUpdateQuantity";
            this.btnUpdateQuantity.Size = new System.Drawing.Size(137, 35);
            this.btnUpdateQuantity.TabIndex = 34;
            this.btnUpdateQuantity.Text = "Sửa số lượng";
            this.btnUpdateQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateQuantity.UseVisualStyleBackColor = true;
            this.btnUpdateQuantity.Click += new System.EventHandler(this.btnUpdateQuantity_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(128, 73);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(144, 35);
            this.btnDelete.TabIndex = 33;
            this.btnDelete.Text = "Xóa sản phẩm";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(102, 503);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(0, 19);
            this.lblTongTien.TabIndex = 43;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnUpdateQuantity);
            this.groupBox4.Controls.Add(this.btnSaveQuantity);
            this.groupBox4.Controls.Add(this.btnDelete);
            this.groupBox4.Location = new System.Drawing.Point(553, 414);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(397, 117);
            this.groupBox4.TabIndex = 47;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tác vụ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtMaPhieuNhap);
            this.groupBox3.Controls.Add(this.txtNguoiTaoPhieu);
            this.groupBox3.Controls.Add(this.txtSoLuong);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cboNhaCungCap);
            this.groupBox3.Location = new System.Drawing.Point(553, 247);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(397, 161);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin phiếu nhập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mã phiếu nhập";
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(129, 25);
            this.txtMaPhieuNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaPhieuNhap.Multiline = true;
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.ReadOnly = true;
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(257, 25);
            this.txtMaPhieuNhap.TabIndex = 1;
            // 
            // txtNguoiTaoPhieu
            // 
            this.txtNguoiTaoPhieu.Location = new System.Drawing.Point(128, 89);
            this.txtNguoiTaoPhieu.Margin = new System.Windows.Forms.Padding(4);
            this.txtNguoiTaoPhieu.Multiline = true;
            this.txtNguoiTaoPhieu.Name = "txtNguoiTaoPhieu";
            this.txtNguoiTaoPhieu.ReadOnly = true;
            this.txtNguoiTaoPhieu.Size = new System.Drawing.Size(258, 25);
            this.txtNguoiTaoPhieu.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Người tạo phiếu";
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(201)))), ((int)(((byte)(88)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(303, 119);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 31);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nhà cung cấp";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(128, 57);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(258, 25);
            this.cboNhaCungCap.TabIndex = 11;
            this.cboNhaCungCap.Click += new System.EventHandler(this.cboNhaCungCap_Click);
            // 
            // btnImport
            // 
            this.btnImport.AutoSize = true;
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(201)))), ((int)(((byte)(88)))));
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(440, 496);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(106, 35);
            this.btnImport.TabIndex = 45;
            this.btnImport.Text = "Lưu thay đổi";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 503);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 19);
            this.label10.TabIndex = 44;
            this.label10.Text = "Tổng tiền";
            // 
            // btnReset
            // 
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(281, 26);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 33);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Làm mới";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvPhieuNhap
            // 
            this.dgvPhieuNhap.AllowUserToAddRows = false;
            this.dgvPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPhieuNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MASANPHAM,
            this.TENSANPHAM,
            this.SOLUONGNHAP,
            this.DONGIA});
            this.dgvPhieuNhap.Location = new System.Drawing.Point(2, 248);
            this.dgvPhieuNhap.Name = "dgvPhieuNhap";
            this.dgvPhieuNhap.ReadOnly = true;
            this.dgvPhieuNhap.RowHeadersVisible = false;
            this.dgvPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuNhap.Size = new System.Drawing.Size(544, 240);
            this.dgvPhieuNhap.TabIndex = 40;
            this.dgvPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuNhap_CellClick);
            // 
            // MASANPHAM
            // 
            this.MASANPHAM.DataPropertyName = "MADIENTHOAI";
            this.MASANPHAM.HeaderText = "Mã sản phẩm";
            this.MASANPHAM.Name = "MASANPHAM";
            this.MASANPHAM.ReadOnly = true;
            this.MASANPHAM.Width = 111;
            // 
            // TENSANPHAM
            // 
            this.TENSANPHAM.DataPropertyName = "TENDIENTHOAI";
            this.TENSANPHAM.HeaderText = "Tên sản phẩm";
            this.TENSANPHAM.Name = "TENSANPHAM";
            this.TENSANPHAM.ReadOnly = true;
            this.TENSANPHAM.Width = 116;
            // 
            // SOLUONGNHAP
            // 
            this.SOLUONGNHAP.DataPropertyName = "SOLUONGNHAP";
            this.SOLUONGNHAP.HeaderText = "Số lượng";
            this.SOLUONGNHAP.Name = "SOLUONGNHAP";
            this.SOLUONGNHAP.ReadOnly = true;
            this.SOLUONGNHAP.Width = 87;
            // 
            // DONGIA
            // 
            this.DONGIA.DataPropertyName = "DONGIA";
            this.DONGIA.HeaderText = "Đơn giá";
            this.DONGIA.Name = "DONGIA";
            this.DONGIA.ReadOnly = true;
            this.DONGIA.Width = 79;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MADIENTHOAI,
            this.TENDIENTHOAI,
            this.SOLUONG,
            this.GIA});
            this.dgvSanPham.Location = new System.Drawing.Point(3, 2);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(543, 240);
            this.dgvSanPham.TabIndex = 39;
            this.dgvSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellClick);
            // 
            // MADIENTHOAI
            // 
            this.MADIENTHOAI.DataPropertyName = "MADIENTHOAI";
            this.MADIENTHOAI.HeaderText = "Mã điện thoại";
            this.MADIENTHOAI.Name = "MADIENTHOAI";
            this.MADIENTHOAI.ReadOnly = true;
            this.MADIENTHOAI.Width = 118;
            // 
            // TENDIENTHOAI
            // 
            this.TENDIENTHOAI.DataPropertyName = "TENDIENTHOAI";
            this.TENDIENTHOAI.HeaderText = "Tên điện thoại";
            this.TENDIENTHOAI.Name = "TENDIENTHOAI";
            this.TENDIENTHOAI.ReadOnly = true;
            this.TENDIENTHOAI.Width = 124;
            // 
            // SOLUONG
            // 
            this.SOLUONG.DataPropertyName = "SOLUONG";
            this.SOLUONG.HeaderText = "Số lượng";
            this.SOLUONG.Name = "SOLUONG";
            this.SOLUONG.ReadOnly = true;
            this.SOLUONG.Width = 94;
            // 
            // GIA
            // 
            this.GIA.DataPropertyName = "GIA";
            this.GIA.HeaderText = "Đơn giá";
            this.GIA.Name = "GIA";
            this.GIA.ReadOnly = true;
            this.GIA.Width = 85;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(8, 26);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(264, 33);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Location = new System.Drawing.Point(553, 3);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(397, 67);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // SuaPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 541);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvPhieuNhap);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuaPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa phiếu nhập";
            this.Load += new System.EventHandler(this.SuaPhieuNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveQuantity;
        public System.Windows.Forms.TextBox txtSoLuong;
        public System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtTenDienThoai;
        public System.Windows.Forms.TextBox txtMaDienThoai;
        public System.Windows.Forms.TextBox txtSoLuongSanPham;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUpdateQuantity;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTongTien;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtMaPhieuNhap;
        public System.Windows.Forms.TextBox txtNguoiTaoPhieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.DataGridView dgvPhieuNhap;
        public System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn MADIENTHOAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENDIENTHOAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIA;
        private System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MASANPHAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENSANPHAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONGNHAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DONGIA;
    }
}