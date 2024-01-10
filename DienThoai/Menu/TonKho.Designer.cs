namespace DienThoai.Menu
{
    partial class TonKho
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TonKho));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport_Excel = new System.Windows.Forms.Button();
            this.btnExport_Excel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvTonKho = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MADIENTHOAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENDIENTHOAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONGNGHEMANHINH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KICHTHUOCMANHINH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOPHANGIAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HEDIEUHANH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAMTRUOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAMSAU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DUNGLUONGLUUTRU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SIM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DUNGLUONGPIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XUATXU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(143, 28);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(302, 25);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnReset
            // 
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(8, 60);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(102, 35);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Làm mới";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboSearch);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Location = new System.Drawing.Point(473, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(453, 107);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnImport_Excel);
            this.groupBox1.Controls.Add(this.btnExport_Excel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 109);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(259, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 80);
            this.panel1.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(362, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 29);
            this.label6.TabIndex = 19;
            this.label6.Text = "Nhập Excel";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(90, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Xóa";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(214, 68);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 29);
            this.label10.TabIndex = 16;
            this.label10.Text = "Lưu";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(151, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 29);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sửa";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(269, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 29);
            this.label5.TabIndex = 18;
            this.label5.Text = "Xuất Excel";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Thêm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImport_Excel
            // 
            this.btnImport_Excel.BackColor = System.Drawing.SystemColors.Control;
            this.btnImport_Excel.FlatAppearance.BorderSize = 0;
            this.btnImport_Excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport_Excel.Image = ((System.Drawing.Image)(resources.GetObject("btnImport_Excel.Image")));
            this.btnImport_Excel.Location = new System.Drawing.Point(381, 25);
            this.btnImport_Excel.Name = "btnImport_Excel";
            this.btnImport_Excel.Size = new System.Drawing.Size(40, 40);
            this.btnImport_Excel.TabIndex = 0;
            this.btnImport_Excel.UseVisualStyleBackColor = false;
            // 
            // btnExport_Excel
            // 
            this.btnExport_Excel.BackColor = System.Drawing.SystemColors.Control;
            this.btnExport_Excel.FlatAppearance.BorderSize = 0;
            this.btnExport_Excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport_Excel.Image = ((System.Drawing.Image)(resources.GetObject("btnExport_Excel.Image")));
            this.btnExport_Excel.Location = new System.Drawing.Point(283, 24);
            this.btnExport_Excel.Name = "btnExport_Excel";
            this.btnExport_Excel.Size = new System.Drawing.Size(40, 40);
            this.btnExport_Excel.TabIndex = 0;
            this.btnExport_Excel.UseVisualStyleBackColor = false;
            this.btnExport_Excel.Click += new System.EventHandler(this.btnExport_Excel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(210, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(147, 24);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(40, 40);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(84, 24);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 40);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(17, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // dgvTonKho
            // 
            this.dgvTonKho.AllowUserToAddRows = false;
            this.dgvTonKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvTonKho.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTonKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MADIENTHOAI,
            this.TENDIENTHOAI,
            this.CONGNGHEMANHINH,
            this.KICHTHUOCMANHINH,
            this.DOPHANGIAI,
            this.HEDIEUHANH,
            this.CAMTRUOC,
            this.CAMSAU,
            this.CHIP,
            this.RAM,
            this.DUNGLUONGLUUTRU,
            this.SIM,
            this.DUNGLUONGPIN,
            this.SAC,
            this.XUATXU,
            this.SOLUONG,
            this.GIA});
            this.dgvTonKho.Location = new System.Drawing.Point(6, 118);
            this.dgvTonKho.Name = "dgvTonKho";
            this.dgvTonKho.ReadOnly = true;
            this.dgvTonKho.RowHeadersVisible = false;
            this.dgvTonKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTonKho.Size = new System.Drawing.Size(921, 464);
            this.dgvTonKho.TabIndex = 15;
            this.dgvTonKho.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTonKho_RowPostPaint);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 61;
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
            // CONGNGHEMANHINH
            // 
            this.CONGNGHEMANHINH.DataPropertyName = "CONGNGHEMANHINH";
            this.CONGNGHEMANHINH.HeaderText = "Công nghệ màn hình";
            this.CONGNGHEMANHINH.Name = "CONGNGHEMANHINH";
            this.CONGNGHEMANHINH.ReadOnly = true;
            this.CONGNGHEMANHINH.Visible = false;
            this.CONGNGHEMANHINH.Width = 168;
            // 
            // KICHTHUOCMANHINH
            // 
            this.KICHTHUOCMANHINH.DataPropertyName = "KICHTHUOCMANHINH";
            this.KICHTHUOCMANHINH.HeaderText = "Kích thước màn hình";
            this.KICHTHUOCMANHINH.Name = "KICHTHUOCMANHINH";
            this.KICHTHUOCMANHINH.ReadOnly = true;
            this.KICHTHUOCMANHINH.Visible = false;
            this.KICHTHUOCMANHINH.Width = 170;
            // 
            // DOPHANGIAI
            // 
            this.DOPHANGIAI.DataPropertyName = "DOPHANGIAI";
            this.DOPHANGIAI.HeaderText = "Độ phân giải";
            this.DOPHANGIAI.Name = "DOPHANGIAI";
            this.DOPHANGIAI.ReadOnly = true;
            this.DOPHANGIAI.Visible = false;
            this.DOPHANGIAI.Width = 114;
            // 
            // HEDIEUHANH
            // 
            this.HEDIEUHANH.DataPropertyName = "HEDIEUHANH";
            this.HEDIEUHANH.HeaderText = "Hệ điều hành";
            this.HEDIEUHANH.Name = "HEDIEUHANH";
            this.HEDIEUHANH.ReadOnly = true;
            this.HEDIEUHANH.Width = 118;
            // 
            // CAMTRUOC
            // 
            this.CAMTRUOC.DataPropertyName = "CAMTRUOC";
            this.CAMTRUOC.HeaderText = "Cam trước";
            this.CAMTRUOC.Name = "CAMTRUOC";
            this.CAMTRUOC.ReadOnly = true;
            this.CAMTRUOC.Visible = false;
            this.CAMTRUOC.Width = 106;
            // 
            // CAMSAU
            // 
            this.CAMSAU.DataPropertyName = "CAMSAU";
            this.CAMSAU.HeaderText = "Cam sau";
            this.CAMSAU.Name = "CAMSAU";
            this.CAMSAU.ReadOnly = true;
            this.CAMSAU.Visible = false;
            this.CAMSAU.Width = 93;
            // 
            // CHIP
            // 
            this.CHIP.DataPropertyName = "CHIP";
            this.CHIP.HeaderText = "Chipset";
            this.CHIP.Name = "CHIP";
            this.CHIP.ReadOnly = true;
            this.CHIP.Visible = false;
            this.CHIP.Width = 83;
            // 
            // RAM
            // 
            this.RAM.DataPropertyName = "RAM";
            this.RAM.HeaderText = "RAM";
            this.RAM.Name = "RAM";
            this.RAM.ReadOnly = true;
            this.RAM.Width = 64;
            // 
            // DUNGLUONGLUUTRU
            // 
            this.DUNGLUONGLUUTRU.DataPropertyName = "DUNGLUONGLUUTRU";
            this.DUNGLUONGLUUTRU.HeaderText = "Bộ nhớ";
            this.DUNGLUONGLUUTRU.Name = "DUNGLUONGLUUTRU";
            this.DUNGLUONGLUUTRU.ReadOnly = true;
            this.DUNGLUONGLUUTRU.Width = 81;
            // 
            // SIM
            // 
            this.SIM.DataPropertyName = "SIM";
            this.SIM.HeaderText = "Sim";
            this.SIM.Name = "SIM";
            this.SIM.ReadOnly = true;
            this.SIM.Visible = false;
            this.SIM.Width = 59;
            // 
            // DUNGLUONGPIN
            // 
            this.DUNGLUONGPIN.DataPropertyName = "DUNGLUONGPIN";
            this.DUNGLUONGPIN.HeaderText = "Dung lượng pin";
            this.DUNGLUONGPIN.Name = "DUNGLUONGPIN";
            this.DUNGLUONGPIN.ReadOnly = true;
            this.DUNGLUONGPIN.Visible = false;
            this.DUNGLUONGPIN.Width = 134;
            // 
            // SAC
            // 
            this.SAC.DataPropertyName = "SAC";
            this.SAC.HeaderText = "Công suất sạc";
            this.SAC.Name = "SAC";
            this.SAC.ReadOnly = true;
            this.SAC.Visible = false;
            this.SAC.Width = 128;
            // 
            // XUATXU
            // 
            this.XUATXU.DataPropertyName = "XUATXU";
            this.XUATXU.HeaderText = "Xuất xứ";
            this.XUATXU.Name = "XUATXU";
            this.XUATXU.ReadOnly = true;
            this.XUATXU.Visible = false;
            this.XUATXU.Width = 83;
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
            // cboSearch
            // 
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Items.AddRange(new object[] {
            "Tất cả",
            "Mã điện thoại",
            "Tên điện thoại",
            "Hệ điều hành",
            "Giá"});
            this.cboSearch.Location = new System.Drawing.Point(7, 28);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(129, 25);
            this.cboSearch.TabIndex = 3;
            this.cboSearch.SelectedIndexChanged += new System.EventHandler(this.cboSearch_SelectedIndexChanged);
            // 
            // TonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTonKho);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TonKho";
            this.Size = new System.Drawing.Size(930, 585);
            this.Load += new System.EventHandler(this.TonKho_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport_Excel;
        private System.Windows.Forms.Button btnExport_Excel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvTonKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MADIENTHOAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENDIENTHOAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONGNGHEMANHINH;
        private System.Windows.Forms.DataGridViewTextBoxColumn KICHTHUOCMANHINH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOPHANGIAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn HEDIEUHANH;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAMTRUOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAMSAU;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DUNGLUONGLUUTRU;
        private System.Windows.Forms.DataGridViewTextBoxColumn SIM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DUNGLUONGPIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn XUATXU;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIA;
        private System.Windows.Forms.ComboBox cboSearch;
    }
}
