using DienThoai.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DienThoai.Menu
{
    public partial class PhieuNhap : UserControl
    {
        ImportCoupon ic = new ImportCoupon();
        ImportDetail id = new ImportDetail();
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public PhieuNhap()
        {
            InitializeComponent();
        }

        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            dgvPhieuNhap.DataSource = ic.HienThiPhieuNhap();
            dgvPhieuNhap.Columns["TONGTIEN"].DefaultCellStyle.Format = "#,##0";
            for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                dgvPhieuNhap.Rows[i].Cells["MANHACUNGCAP"].Value = ic.TenNhaCungCap(dgvPhieuNhap.Rows[i].Cells["MANHACUNGCAP"].Value.ToString());
            cboSearch.SelectedIndex = 0;
        }
        private void dgvPhieuNhap_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvPhieuNhap.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        public void TimKiemGia()
        {
            string s = "select * from PHIEUNHAP where TONGTIEN BETWEEN '" + txtMin.Text + "' AND '" + txtMax.Text + "'";
            var da = new SqlDataAdapter(s, c);
            var dt = new DataTable();
            da.Fill(dt);
            dgvPhieuNhap.DataSource = dt;
        }
        public void TimKiemNgay()
        {
            string s = "select * from PHIEUNHAP where THOIGIANTAO BETWEEN '" + dtpMin.Text + "' AND '" + dtpMax.Text + "'";
            var da = new SqlDataAdapter(s, c);
            var dt = new DataTable();
            da.Fill(dt);
            dgvPhieuNhap.DataSource = dt;
        }
        private void txtMin_TextChanged(object sender, EventArgs e)
        {
            TimKiemGia();
        }

        private void txtMax_TextChanged(object sender, EventArgs e)
        {
            TimKiemGia();
        }
        private void dtpMin_ValueChanged(object sender, EventArgs e)
        {
            TimKiemNgay();
        }
        private void dtpMax_ValueChanged(object sender, EventArgs e)
        {
            TimKiemNgay();
        }
        private void btnExport_Excel_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application MExcel = new Microsoft.Office.Interop.Excel.Application();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvPhieuNhap.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dgvPhieuNhap.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvPhieuNhap.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dgvPhieuNhap.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
            }
            else
                MessageBox.Show("Không thể xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMin.Clear();
            txtMax.Clear();
            dtpMin.Value = DateTime.Now;
            dtpMax.Value = DateTime.Now;
            txtSearch.Clear();
            dgvPhieuNhap.DataSource = ic.HienThiPhieuNhap();
        }

        private void btnImport_Excel_Click(object sender, EventArgs e)
        {
            var dt = dgvPhieuNhap.DataSource as DataTable;
            dt.Rows.Clear();
            dgvPhieuNhap.DataSource = dt;

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
                xlWorksheet = xlWorkbook.Worksheets["PHIEUNHAP"];
                xlRange = xlWorksheet.UsedRange;
                for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    if (xlRange.Cells[xlRow, 1].Text != "")
                    {
                        DataTable dt_excel = dgvPhieuNhap.DataSource as DataTable;
                        dt_excel.Rows.Add(xlRange.Cells[xlRow, 1].Text, xlRange.Cells[xlRow, 2].Text, xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text, xlRange.Cells[xlRow, 5].Text);
                        DataGridViewRow dgvr = dgvPhieuNhap.SelectedRows[0];
                    }
                }
                xlWorkbook.Close();
                xlApp.Quit();
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                {
                    ic.ThemPhieuNhap_Excel(dgvPhieuNhap.Rows[i].Cells["MAPHIEU"].Value.ToString(), DateTime.Parse(dgvPhieuNhap.Rows[i].Cells["THOIGIANTAO"].Value.ToString()), dgvPhieuNhap.Rows[i].Cells["NGUOITAO"].Value.ToString(), dgvPhieuNhap.Rows[i].Cells["MANHACUNGCAP"].Value.ToString(), dgvPhieuNhap.Rows[i].Cells["TONGTIEN"].Value.ToString());
                }
                MessageBox.Show("Thêm dữ liệu từ Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPhieuNhap.DataSource = ic.HienThiPhieuNhap();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                ic.XoaChiTietPhieuNhap(dgvPhieuNhap.CurrentRow.Cells[1].Value.ToString());
                ic.XoaPhieuNhap(dgvPhieuNhap.CurrentRow.Cells[1].Value.ToString());
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPhieuNhap.DataSource = ic.HienThiPhieuNhap();
                dgvPhieuNhap.Update();
                dgvPhieuNhap.Rows[0].Selected = true;
            }
        }
        private void btnDetail_Click(object sender, EventArgs e)
        {
            ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
            ctpn.lblMaPhieu.Text = dgvPhieuNhap.CurrentRow.Cells[1].Value.ToString();
            ctpn.lblThoiGianTao.Text = dgvPhieuNhap.CurrentRow.Cells[2].Value.ToString();
            ctpn.lblNguoiTao.Text = dgvPhieuNhap.CurrentRow.Cells[3].Value.ToString();
            ctpn.lblNhaCungCap.Text = dgvPhieuNhap.CurrentRow.Cells[4].Value.ToString();
            ctpn.lblTongTien.Text = dgvPhieuNhap.CurrentRow.Cells[5].Value.ToString();
            ctpn.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(cboSearch.SelectedIndex == 0)
            {
                string sql = "select * from PHIEUNHAP where MAPHIEU like '%" + txtSearch.Text + "%' or NGUOITAO like '%" + txtSearch.Text + "%'";
                var da = new SqlDataAdapter(sql, c);
                var dt = new DataTable();
                da.Fill(dt);
                dgvPhieuNhap.DataSource = dt;
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                    dgvPhieuNhap.Rows[i].Cells["MANHACUNGCAP"].Value = ic.TenNhaCungCap(dgvPhieuNhap.Rows[i].Cells["MANHACUNGCAP"].Value.ToString());
                if (dgvPhieuNhap.Rows.Count < 0)
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 1)
            {
                string sql = "select * from PHIEUNHAP where MAPHIEU like '%" + txtSearch.Text + "%'";
                var da = new SqlDataAdapter(sql, c);
                var dt = new DataTable();
                da.Fill(dt);
                dgvPhieuNhap.DataSource = dt;
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                    dgvPhieuNhap.Rows[i].Cells["MANHACUNGCAP"].Value = ic.TenNhaCungCap(dgvPhieuNhap.Rows[i].Cells["MANHACUNGCAP"].Value.ToString());
                if (dgvPhieuNhap.Rows.Count < 0)
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 2)
            {
                string sql = "select * from PHIEUNHAP where NGUOITAO like '%" + txtSearch.Text + "%'";
                var da = new SqlDataAdapter(sql, c);
                var dt = new DataTable();
                da.Fill(dt);
                dgvPhieuNhap.DataSource = dt;
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                    dgvPhieuNhap.Rows[i].Cells["MANHACUNGCAP"].Value = ic.TenNhaCungCap(dgvPhieuNhap.Rows[i].Cells["MANHACUNGCAP"].Value.ToString());
                if (dgvPhieuNhap.Rows.Count < 0)
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 3)
            {
                string sql = "select * from PHIEUNHAP where MANHACUNGCAP like '%" + txtSearch.Text + "%'";
                var da = new SqlDataAdapter(sql, c);
                var dt = new DataTable();
                da.Fill(dt);
                dgvPhieuNhap.DataSource = dt;
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                    dgvPhieuNhap.Rows[i].Cells["MANHACUNGCAP"].Value = ic.TenNhaCungCap(dgvPhieuNhap.Rows[i].Cells["MANHACUNGCAP"].Value.ToString());
                if (dgvPhieuNhap.Rows.Count < 0)
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SuaPhieuNhap spn = new SuaPhieuNhap();
            spn.txtMaPhieuNhap.Text = dgvPhieuNhap.CurrentRow.Cells[1].Value.ToString();
            spn.txtNguoiTaoPhieu.Text = dgvPhieuNhap.CurrentRow.Cells[3].Value.ToString();
            spn.cboNhaCungCap.Text = dgvPhieuNhap.CurrentRow.Cells[4].Value.ToString();
            spn.ShowDialog();
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }
    }
}
