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
    public partial class PhieuXuat : UserControl
    {
        ExportCoupon ec = new ExportCoupon();
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public PhieuXuat()
        {
            InitializeComponent();
        }
        private void PhieuXuat_Load(object sender, EventArgs e)
        {
            dgvPhieuXuat.DataSource = ec.HienThiPhieuXuat();
            dgvPhieuXuat.Columns["TONGTIEN"].DefaultCellStyle.Format = "#,##0";
            cboSearch.SelectedIndex = 0;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMin.Clear();
            txtMax.Clear();
            dtpMin.Value = DateTime.Now;
            dtpMax.Value = DateTime.Now;
            txtSearch.Clear();
            dgvPhieuXuat.DataSource = ec.HienThiPhieuXuat();
        }
        private void dgvPhieuXuat_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvPhieuXuat.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        public void TimKiemGia()
        {
            string s = "select * from PHIEUXUAT where TONGTIEN BETWEEN '" + txtMin.Text + "' AND '" + txtMax.Text + "'";
            var da = new SqlDataAdapter(s, c);
            var dt = new DataTable();
            da.Fill(dt);
            dgvPhieuXuat.DataSource = dt;
        }
        public void TimKiemNgay()
        {
            string s = "select * from PHIEUXUAT where THOIGIANTAO BETWEEN '" + dtpMin.Text + "' AND '" + dtpMax.Text + "'";
            var da = new SqlDataAdapter(s, c);
            var dt = new DataTable();
            da.Fill(dt);
            dgvPhieuXuat.DataSource = dt;
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
            if (dgvPhieuXuat.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application MExcel = new Microsoft.Office.Interop.Excel.Application();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvPhieuXuat.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dgvPhieuXuat.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvPhieuXuat.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvPhieuXuat.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dgvPhieuXuat.Rows[i].Cells[j].Value.ToString();
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

        private void btnDetail_Click(object sender, EventArgs e)
        {
            ChiTietPhieuXuat ctpx = new ChiTietPhieuXuat();
            ctpx.lblMaPhieu.Text = dgvPhieuXuat.CurrentRow.Cells[1].Value.ToString();
            ctpx.lblThoiGianTao.Text = dgvPhieuXuat.CurrentRow.Cells[2].Value.ToString();
            ctpx.lblNguoiTao.Text = dgvPhieuXuat.CurrentRow.Cells[3].Value.ToString();
            ctpx.lblTongTien.Text = dgvPhieuXuat.CurrentRow.Cells[4].Value.ToString();
            ctpx.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                ec.XoaChiTietPhieuXuat(dgvPhieuXuat.CurrentRow.Cells[1].Value.ToString());
                ec.XoaPhieuXuat(dgvPhieuXuat.CurrentRow.Cells[1].Value.ToString());
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPhieuXuat.DataSource = ec.HienThiPhieuXuat();
                dgvPhieuXuat.Update();
                dgvPhieuXuat.Rows[0].Selected = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SuaPhieuXuat spx = new SuaPhieuXuat();
            spx.txtMaPhieuXuat.Text = dgvPhieuXuat.CurrentRow.Cells[1].Value.ToString();
            spx.txtNguoiTaoPhieu.Text = dgvPhieuXuat.CurrentRow.Cells[3].Value.ToString();
            spx.ShowDialog();
        }

        private void btnImport_Excel_Click(object sender, EventArgs e)
        {
            var dt = dgvPhieuXuat.DataSource as DataTable;
            dt.Rows.Clear();
            dgvPhieuXuat.DataSource = dt;

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
                xlWorksheet = xlWorkbook.Worksheets["PHIEUXUAT"];
                xlRange = xlWorksheet.UsedRange;
                for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    if (xlRange.Cells[xlRow, 1].Text != "")
                    {
                        DataTable dt_excel = dgvPhieuXuat.DataSource as DataTable;
                        dt_excel.Rows.Add(xlRange.Cells[xlRow, 1].Text, xlRange.Cells[xlRow, 2].Text, xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text);
                        DataGridViewRow dgvr = dgvPhieuXuat.SelectedRows[0];
                    }
                }
                xlWorkbook.Close();
                xlApp.Quit();
                for (int i = 0; i < dgvPhieuXuat.Rows.Count; i++)
                {
                    ec.ThemPhieuXuat_Excel(dgvPhieuXuat.Rows[i].Cells["MAPHIEU"].Value.ToString(), DateTime.Parse(dgvPhieuXuat.Rows[i].Cells["THOIGIANTAO"].Value.ToString()), dgvPhieuXuat.Rows[i].Cells["NGUOITAO"].Value.ToString(), dgvPhieuXuat.Rows[i].Cells["TONGTIEN"].Value.ToString());
                }
                MessageBox.Show("Thêm dữ liệu từ Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPhieuXuat.DataSource = ec.HienThiPhieuXuat();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cboSearch.SelectedIndex == 0)
            {
                string sql = "select * from PHIEUXUAT where MAPHIEU like '%" + txtSearch.Text + "%' or NGUOITAO like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "PHIEUXUAT");
                if (ds.Tables["PHIEUXUAT"].Rows.Count > 0)
                    dgvPhieuXuat.DataSource = ds.Tables["PHIEUXUAT"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 1)
            {
                string sql = "select * from PHIEUXUAT where MAPHIEU like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "PHIEUXUAT");
                if (ds.Tables["PHIEUXUAT"].Rows.Count > 0)
                    dgvPhieuXuat.DataSource = ds.Tables["PHIEUXUAT"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 2)
            {
                string sql = "select * from PHIEUXUAT where NGUOITAO like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "PHIEUXUAT");
                if (ds.Tables["PHIEUXUAT"].Rows.Count > 0)
                    dgvPhieuXuat.DataSource = ds.Tables["PHIEUXUAT"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }    
            
    }
}
