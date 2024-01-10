using DienThoai.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DienThoai.Menu
{
    public partial class XuatHang : UserControl
    {
        Export ex = new Export();
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        string Ma = "PX";
        int indexRow;
        string datetime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        public XuatHang()
        {
            InitializeComponent();
        }

        private void XuatHang_Load(object sender, EventArgs e)
        {
            MaPhieuXuatTuDong();
            txtNguoiTaoPhieu.Text = DangNhap.username;
            dgvSanPham.DataSource = ex.HienThiSanPham();
            /*DataGridViewRow dgvr = dgvSanPham.SelectedRows[0];
            DuLieuTextbox(dgvr);*/
            dgvSanPham.Columns["GIA"].DefaultCellStyle.Format = "#,##0";
            
        }
        public void MaPhieuXuatTuDong()
        {
            c.Open();
            string s = "select count(MAPHIEU) from PHIEUXUAT";
            SqlCommand cmd = new SqlCommand(s, c);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            c.Close();
            i++;
            txtMaPhieuXuat.Text = Ma + i.ToString();
        }
        public void DuLieuTextbox_PhieuXuat(DataGridViewRow dgvr_pn)
        {
            txtSoLuong.Text = dgvr_pn.Cells[2].Value.ToString();
        }
        private void ThemDuLieu(string MaSanPham, string TenSanPham, string SoLuongNhap, string DonGiaNhap)
        {
            String[] row = { MaSanPham, TenSanPham, SoLuongNhap, DonGiaNhap };
            dgvPhieuXuat.Rows.Add(row);
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
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvPhieuXuat.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu cần xuất !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ex.ThemPhieuXuat(txtMaPhieuXuat.Text, datetime, txtNguoiTaoPhieu.Text, Convert.ToString(double.Parse(lblTongTien.Text)));
                for (int i = 0; i < dgvPhieuXuat.Rows.Count; i++)
                {
                    ex.ThemChiTietPhieuXuat(txtMaPhieuXuat.Text, dgvPhieuXuat.Rows[i].Cells["MASANPHAM"].Value.ToString(), dgvPhieuXuat.Rows[i].Cells["SOLUONGXUAT"].Value.ToString(), dgvPhieuXuat.Rows[i].Cells["DONGIAXUAT"].Value.ToString());
                }
                for (int i = 0; i < dgvPhieuXuat.Rows.Count; i++)
                {
                    ex.CapNhatSoLuongSanPham(dgvPhieuXuat.Rows[i].Cells["SOLUONGXUAT"].Value.ToString(), dgvPhieuXuat.Rows[i].Cells["MASANPHAM"].Value.ToString());
                }
                MessageBox.Show("Xuất hàng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSanPham.Update();
                dgvSanPham.DataSource = ex.HienThiSanPham();
                if (MessageBox.Show("Bạn có muốn in phiếu xuất ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ChiTietPhieuXuat ctpx = new ChiTietPhieuXuat();
                    ctpx.lblMaPhieu.Text = txtMaPhieuXuat.Text;
                    ctpx.lblNguoiTao.Text = txtNguoiTaoPhieu.Text;
                    ctpx.lblThoiGianTao.Text = datetime;
                    ctpx.lblTongTien.Text = lblTongTien.Text;
                    ctpx.ShowDialog();
                }
                else
                {
                    MaPhieuXuatTuDong();
                    txtSoLuong.Clear();
                    dgvPhieuXuat.Rows.Clear();
                }    
            }    
        }
        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            txtSoLuong.ReadOnly = false;
        }
        private void btnSaveQuantity_Click(object sender, EventArgs e)
        {
            DataGridViewRow row_new = dgvPhieuXuat.Rows[indexRow];
            row_new.Cells[2].Value = txtSoLuong.Text;
            txtSoLuong.ReadOnly = true;
        }
        private void dgvPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*indexRow = e.RowIndex;
            DataGridViewRow row = dgvPhieuXuat.Rows[indexRow];*/
            txtSoLuong.Text = dgvSanPham.CurrentRow.Cells[2].Value.ToString();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "select MADIENTHOAI, TENDIENTHOAI, SOLUONG, GIA from DIENTHOAI where MADIENTHOAI like '%" + txtSearch.Text + "%' or TENDIENTHOAI like '%" + txtSearch.Text + "%' or GIA like '%" + txtSearch.Text + "%'";
            var da = new SqlDataAdapter(sql, c);
            var dt = new DataTable();
            da.Fill(dt);
            dgvSanPham.DataSource = dt;
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
            int min = Convert.ToInt32(txtSoLuongSanPham.Text);
            if (max <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn không (> 0)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Clear();
                txtSoLuong.Focus();
                return;
            }
            if(max > min)
            {
                MessageBox.Show("Số lượng xuất vượt quá số lượng tồn kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Clear();
                txtSoLuong.Focus();
                return;
            }
            KiemTraTonTaiMaSanPham();
            txtSoLuong.ReadOnly = true;
            DataGridViewRow dgvr_pn = dgvPhieuXuat.SelectedRows[0];
            DuLieuTextbox_PhieuXuat(dgvr_pn);
            lblTongTien.Text = "0";
            double temp = 0;
            for (int i = 0; i < dgvPhieuXuat.Rows.Count; i++)
            {
                temp = double.Parse(dgvPhieuXuat.Rows[i].Cells[2].Value.ToString()) * double.Parse(dgvPhieuXuat.Rows[i].Cells[3].Value.ToString());
                lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + temp);
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
        }
        private void KiemTraTonTaiMaSanPham()
        {
            bool found = false;
            if (dgvPhieuXuat.Rows.Count > 0)
            {
                foreach (DataGridViewRow row_check in dgvPhieuXuat.Rows)
                {
                    if (Convert.ToString(row_check.Cells[0].Value) == txtMaDienThoai.Text)
                    {
                        row_check.Cells[2].Value = Convert.ToString(Convert.ToInt32(txtSoLuong.Text) + Convert.ToInt32(row_check.Cells[2].Value));
                        found = true;
                    }
                }
                if (!found)
                {
                    ThemDuLieu(txtMaDienThoai.Text, txtTenDienThoai.Text, txtSoLuong.Text, Convert.ToString(double.Parse(txtDonGia.Text)));
                }
            }
            else
                ThemDuLieu(txtMaDienThoai.Text, txtTenDienThoai.Text, txtSoLuong.Text, Convert.ToString(double.Parse(txtDonGia.Text)));
        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được phép nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvPhieuXuat.CurrentCell.RowIndex;
            dgvPhieuXuat.Rows.RemoveAt(rowIndex);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            DataGridViewRow dgvr = dgvSanPham.SelectedRows[0];
            DuLieuTextbox(dgvr);
            dgvPhieuXuat.Rows.Clear();
            txtSoLuong.Clear();
            MaPhieuXuatTuDong();
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
                xlWorksheet = xlWorkbook.Worksheets["XUATHANG"];
                xlRange = xlWorksheet.UsedRange;
                for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    if (xlRange.Cells[xlRow, 1].Text != "")
                    {
                        dgvPhieuXuat.Rows.Add(xlRange.Cells[xlRow, 1].Text, xlRange.Cells[xlRow, 2].Text, xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text);
                        DataGridViewRow dgvr = dgvPhieuXuat.SelectedRows[0];
                        DuLieuTextbox(dgvr);
                    }
                }
                xlWorkbook.Close();
                xlApp.Quit();
            }
            lblTongTien.Text = "0";
            double temp;
            for (int i = 0; i < dgvPhieuXuat.Rows.Count; i++)
            {
                temp = double.Parse(dgvPhieuXuat.Rows[i].Cells[2].Value.ToString()) * double.Parse(dgvPhieuXuat.Rows[i].Cells[3].Value.ToString());
                lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + temp);
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
        }
    }
}
