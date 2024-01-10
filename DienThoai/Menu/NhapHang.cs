using DienThoai.Class;
using iTextSharp.text.pdf;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DienThoai.Menu
{
    public partial class NhapHang : UserControl
    {
        Import im = new Import();
        string Ma = "PN";
        int indexRow;
        string datetime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public NhapHang()
        {
            InitializeComponent();
        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            txtNguoiTaoPhieu.Text = DangNhap.username;
            MaPhieuNhapTuDong();
            dgvSanPham.Columns["GIA"].DefaultCellStyle.Format = "#,##0";
            cboNhaCungCap.DisplayMember = "TENNHACUNGCAP";
            cboNhaCungCap.ValueMember = "MANHACUNGCAP";
            cboNhaCungCap.DataSource = im.HienThiTenNhaCungCap();
            dgvSanPham.DataSource = im.HienThiSanPham();
        }
        public void MaPhieuNhapTuDong()
        {
            c.Open();
            string s = "select count(MAPHIEU) from PHIEUNHAP";
            SqlCommand cmd = new SqlCommand(s, c);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            c.Close();
            i++;
            txtMaPhieuNhap.Text = Ma + i.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Số lượng không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            int max = Convert.ToInt32(txtSoLuong.Text);
            if (max <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn không (> 0)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Clear();
                txtSoLuong.Focus();
                return;
            }
            /*dgvPhieuNhap.Columns["DONGIANHAP"].DefaultCellStyle.Format = "#,##0";*/
            KiemTraTonTaiMaSanPham();
            txtSoLuong.ReadOnly = true;
            txtSoLuong.Clear();
            dgvPhieuNhap.CurrentCell = dgvPhieuNhap[0, dgvPhieuNhap.Rows.Count - 1];
            lblTongTien.Text = "0";
            double temp;
            for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
            {
                temp = double.Parse(dgvPhieuNhap.Rows[i].Cells[2].Value.ToString()) * double.Parse(dgvPhieuNhap.Rows[i].Cells[3].Value.ToString());
                lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + temp);
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
        }
        
        private void KiemTraTonTaiMaSanPham()
        {
            bool found = false;
            if(dgvPhieuNhap.Rows.Count > 0)
            {
                foreach(DataGridViewRow row_check in dgvPhieuNhap.Rows)
                {
                    if (Convert.ToString(row_check.Cells[0].Value) == txtMaDienThoai.Text)
                    {
                        row_check.Cells[2].Value = Convert.ToString(Convert.ToInt32(txtSoLuong.Text) + Convert.ToInt32(row_check.Cells[2].Value));
                        found = true;
                    }    
                }
                if(!found)
                {
                    ThemDuLieu(txtMaDienThoai.Text, txtTenDienThoai.Text, txtSoLuong.Text, Convert.ToString(double.Parse(txtDonGia.Text)));
                }    
            }
            else
                ThemDuLieu(txtMaDienThoai.Text, txtTenDienThoai.Text, txtSoLuong.Text, Convert.ToString(double.Parse(txtDonGia.Text)));
        }
        private void ThemDuLieu(string MaSanPham, string TenSanPham, string SoLuongNhap, string DonGiaNhap)
        {
            String[] row = { MaSanPham, TenSanPham, SoLuongNhap, DonGiaNhap };
            dgvPhieuNhap.Rows.Add(row);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            /*txtThoiGian.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();*/
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDienThoai.Text = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
            txtTenDienThoai.Text = dgvSanPham.CurrentRow.Cells[1].Value.ToString();
            txtDonGia.Text = int.Parse(dgvSanPham.CurrentRow.Cells[3].Value.ToString()).ToString("#,##");
            txtSoLuongSanPham.Text = dgvSanPham.CurrentRow.Cells[2].Value.ToString();
            txtSoLuong.ReadOnly = false;
            txtSoLuong.Clear();           
        }
        public void DuLieuTextbox(DataGridViewRow dgvr)
        {
            txtMaDienThoai.Text = dgvr.Cells[0].Value.ToString();
            txtTenDienThoai.Text = dgvr.Cells[1].Value.ToString();
            txtSoLuongSanPham.Text = dgvr.Cells[2].Value.ToString();
            txtDonGia.Text = int.Parse(dgvr.Cells[3].Value.ToString()).ToString("#,##");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvPhieuNhap.CurrentCell.RowIndex;
            dgvPhieuNhap.Rows.RemoveAt(rowIndex);
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dgvPhieuNhap.Rows[indexRow];
            txtSoLuong.Text = dgvPhieuNhap.CurrentRow.Cells[2].Value.ToString();
            txtSoLuong.ReadOnly = true;
        }
        public void DuLieuTextbox_PhieuNhap(DataGridViewRow dgvr_pn)
        {
            txtSoLuong.Text = dgvr_pn.Cells[2].Value.ToString();
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            txtSoLuong.ReadOnly = false;
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
            Microsoft.Office.Interop.Excel.Range xlRange;

            int xlRow;
            string strFilename;

            openFD.Filter = "Excel Office |*.xls; *xlsx";
            openFD.ShowDialog();
            strFilename = openFD.FileName;
            if (strFilename != "")
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(strFilename);
                xlWorksheet = xlWorkbook.Worksheets["NHAPHANG"];
                xlRange = xlWorksheet.UsedRange;
                for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    if (xlRange.Cells[xlRow, 1].Text != "")
                    {
                        /*DataTable dt_excel = dgvPhieuNhap.DataSource as DataTable;*/
                        dgvPhieuNhap.Rows.Add(xlRange.Cells[xlRow, 1].Text, xlRange.Cells[xlRow, 2].Text, xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text);
                        DataGridViewRow dgvr = dgvPhieuNhap.SelectedRows[0];
                        DuLieuTextbox(dgvr);
                    }
                }
                xlWorkbook.Close();
                xlApp.Quit();
            }
            lblTongTien.Text = "0";
            double temp;
            for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
            {
                temp = double.Parse(dgvPhieuNhap.Rows[i].Cells[2].Value.ToString()) * double.Parse(dgvPhieuNhap.Rows[i].Cells[3].Value.ToString());
                lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + temp);
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
        }

        private void btnSaveQuantity_Click(object sender, EventArgs e)
        {
            DataGridViewRow row_new = dgvPhieuNhap.Rows[indexRow];
            row_new.Cells[2].Value = txtSoLuong.Text;
            txtSoLuong.ReadOnly = true;
            lblTongTien.Text = "0";
            double temp;
            for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
            {
                temp = double.Parse(dgvPhieuNhap.Rows[i].Cells[2].Value.ToString()) * double.Parse(dgvPhieuNhap.Rows[i].Cells[3].Value.ToString());
                lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + temp);
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được phép nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }    
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboNhaCungCap.SelectedIndex = 0;
            DataGridViewRow dgvr = dgvSanPham.SelectedRows[0];
            DuLieuTextbox(dgvr);
            dgvPhieuNhap.Rows.Clear();
            txtSoLuong.Clear();
            MaPhieuNhapTuDong();
            cboNhaCungCap.Enabled = true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu cần nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                im.ThemPhieuNhap(txtMaPhieuNhap.Text, /*txtThoiGian.Text*/datetime, txtNguoiTaoPhieu.Text, cboNhaCungCap.Text = im.MaNhaCungCap_Ten(cboNhaCungCap.Text), Convert.ToString(double.Parse(lblTongTien.Text)));
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                {
                    im.ThemChiTietPhieuNhap(txtMaPhieuNhap.Text, dgvPhieuNhap.Rows[i].Cells["MASANPHAM"].Value.ToString(), dgvPhieuNhap.Rows[i].Cells["SOLUONGNHAP"].Value.ToString(), dgvPhieuNhap.Rows[i].Cells["DONGIANHAP"].Value.ToString());
                }
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                {
                    im.CapNhatSoLuongSanPham(dgvPhieuNhap.Rows[i].Cells["SOLUONGNHAP"].Value.ToString(), dgvPhieuNhap.Rows[i].Cells["MASANPHAM"].Value.ToString());
                }
                cboNhaCungCap.DisplayMember = "TENNHACUNGCAP";
                cboNhaCungCap.ValueMember = "MANHACUNGCAP";
                cboNhaCungCap.DataSource = im.HienThiTenNhaCungCap();
                MessageBox.Show("Nhập hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSanPham.DataSource = im.HienThiSanPham();
                if (MessageBox.Show("Bạn có muốn in phiếu nhập ?", "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                {
                    ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
                    ctpn.lblMaPhieu.Text = txtMaPhieuNhap.Text;
                    ctpn.lblThoiGianTao.Text = datetime;
                    ctpn.lblNguoiTao.Text = txtNguoiTaoPhieu.Text;
                    ctpn.lblNhaCungCap.Text = cboNhaCungCap.Text;
                    ctpn.lblTongTien.Text = lblTongTien.Text;
                    ctpn.ShowDialog();
                }
                else
                {
                    MaPhieuNhapTuDong();
                    txtSoLuong.Clear();
                    cboNhaCungCap.SelectedIndex = 0;
                    cboNhaCungCap.DisplayMember = "TENNHACUNGCAP";
                    cboNhaCungCap.ValueMember = "MANHACUNGCAP";
                    cboNhaCungCap.DataSource = im.HienThiTenNhaCungCap();
                    cboNhaCungCap.Enabled = true;
                    dgvPhieuNhap.Rows.Clear();
                }    
            }    
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "select MADIENTHOAI, TENDIENTHOAI, SOLUONG, GIA from DIENTHOAI where MADIENTHOAI like '%" + txtSearch.Text + "%' or TENDIENTHOAI like '%" + txtSearch.Text + "%' or GIA like '%" + txtSearch.Text + "%'";
            var da = new SqlDataAdapter(sql, c);
            var dt = new DataTable();
            da.Fill(dt);
            dgvSanPham.DataSource = dt;
        }
    }
}
