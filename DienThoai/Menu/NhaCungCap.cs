using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DienThoai.Menu
{
    public partial class NhaCungCap : UserControl
    {
        Supplier s = new Supplier();
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        DataSet ds = new DataSet();
        int indexRow;
        
        public NhaCungCap()
        {
            InitializeComponent();
        }
        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            dgvNhaCungCap.DataSource = s.HienThiNhaCungCap();
            cboSearch.SelectedIndex = 0;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dgvNhaCungCap.DataSource = s.HienThiNhaCungCap();
            DataGridViewRow dgvr = dgvNhaCungCap.SelectedRows[0];
            DuLieuTextbox(dgvr);
            dgvNhaCungCap.Rows[0].Selected = true;
            cboSearch.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtMaNhaCungCap.ReadOnly = false;
            txtTenNhaCungCap.ReadOnly = false;
            txtSoDienThoai.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtMaNhaCungCap.Clear();
            txtTenNhaCungCap.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cboSearch.SelectedIndex == 0)
            {
                string sql = "select * from NHACUNGCAP where MANHACUNGCAP like '%" + txtSearch.Text + "%' or TENNHACUNGCAP like '%" + txtSearch.Text + "%' or SODIENTHOAI like '%" + txtSearch.Text + "%' or DIACHI like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "NHACUNGCAP");
                if (ds.Tables["NHACUNGCAP"].Rows.Count > 0)
                    dgvNhaCungCap.DataSource = ds.Tables["NHACUNGCAP"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 1)
            {
                string sql = "select * from NHACUNGCAP where MANHACUNGCAP like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "NHACUNGCAP");
                if (ds.Tables["NHACUNGCAP"].Rows.Count > 0)
                    dgvNhaCungCap.DataSource = ds.Tables["NHACUNGCAP"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 2)
            {
                string sql = "select * from NHACUNGCAP where TENNHACUNGCAP like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "NHACUNGCAP");
                if (ds.Tables["NHACUNGCAP"].Rows.Count > 0)
                    dgvNhaCungCap.DataSource = ds.Tables["NHACUNGCAP"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 3)
            {
                string sql = "select * from NHACUNGCAP where SODIENTHOAI like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "NHACUNGCAP");
                if (ds.Tables["NHACUNGCAP"].Rows.Count > 0)
                    dgvNhaCungCap.DataSource = ds.Tables["NHACUNGCAP"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 4)
            {
                string sql = "select * from NHACUNGCAP where DIACHI like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "NHACUNGCAP");
                if (ds.Tables["NHACUNGCAP"].Rows.Count > 0)
                    dgvNhaCungCap.DataSource = ds.Tables["NHACUNGCAP"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!s.KiemTraKhoaNgoaiNhaCungCap(dgvNhaCungCap.CurrentRow.Cells["MANHACUNGCAP"].Value.ToString()))
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    s.XoaNhaCungCap(txtMaNhaCungCap.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgvNhaCungCap.DataSource = s.HienThiNhaCungCap();
                dgvNhaCungCap.Rows[0].Selected = true;
                DuLieuTextbox(dgvNhaCungCap.Rows[0]);
            }
            else
            {
                MessageBox.Show("Lỗi : Nhà cung cấp này đang cung cấp sản phẩm\nKhông thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*indexRow = e.RowIndex;
            DataGridViewRow row = dgvNhaCungCap.Rows[indexRow];*/
            txtMaNhaCungCap.Text = dgvNhaCungCap.CurrentRow.Cells[1].Value.ToString();
            txtTenNhaCungCap.Text = dgvNhaCungCap.CurrentRow.Cells[2].Value.ToString();
            txtSoDienThoai.Text = dgvNhaCungCap.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = dgvNhaCungCap.CurrentRow.Cells[4].Value.ToString();
            txtMaNhaCungCap.ReadOnly = true;
            txtTenNhaCungCap.ReadOnly = true;
            txtSoDienThoai.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
        }
        public void DuLieuTextbox(DataGridViewRow dgvr)
        {
            txtMaNhaCungCap.Text = dgvr.Cells[1].Value.ToString();
            txtTenNhaCungCap.Text = dgvr.Cells[2].Value.ToString();
            txtDiaChi.Text = dgvr.Cells[4].Value.ToString();
            txtSoDienThoai.Text = dgvr.Cells[3].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is System.Windows.Forms.TextBox)
                {
                    if (string.IsNullOrEmpty(ctrl.Text))
                    {
                        MessageBox.Show("Thông tin không được rỗng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ctrl.Focus();
                        return;
                    }
                }
            }
            if (txtMaNhaCungCap.ReadOnly == false)
            {
                if (s.KiemTraTonTaiMaNhaCungCap(txtMaNhaCungCap.Text))
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    s.ThemNhaCungCap(txtMaNhaCungCap.Text, txtTenNhaCungCap.Text, txtSoDienThoai.Text, txtDiaChi.Text);
                    MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNhaCungCap.DataSource = s.HienThiNhaCungCap();
                    txtMaNhaCungCap.ReadOnly = true;
                    txtTenNhaCungCap.ReadOnly = true;
                    txtSoDienThoai.ReadOnly = true;
                    txtDiaChi.ReadOnly = true;
                }
            }
            else
            {
                s.CapNhatNhaCungCap(txtMaNhaCungCap.Text, txtTenNhaCungCap.Text, txtSoDienThoai.Text, txtDiaChi.Text);
                MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewRow row_new = dgvNhaCungCap.Rows[indexRow];
                row_new.Cells[1].Value = txtMaNhaCungCap.Text;
                row_new.Cells[2].Value = txtTenNhaCungCap.Text;
                row_new.Cells[3].Value = txtSoDienThoai.Text;
                row_new.Cells[4].Value = txtDiaChi.Text;

                txtMaNhaCungCap.ReadOnly = true;
                txtTenNhaCungCap.ReadOnly = true;
                txtSoDienThoai.ReadOnly = true;
                txtDiaChi.ReadOnly = true;

            }
            /*if (!s.KiemTraHopLeSoDienThoai(txtSoDienThoai.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoDienThoai.Focus();
                return;
            }*/
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtTenNhaCungCap.ReadOnly = false;
            txtSoDienThoai.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
        }
        
        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void btnExport_Excel_Click(object sender, EventArgs e)
        {
            dgvNhaCungCap.SelectAll();
            DataObject CopyData = dgvNhaCungCap.GetClipboardContent();
            if (CopyData != null)
                Clipboard.SetDataObject(CopyData);
            Microsoft.Office.Interop.Excel.Application Exapp = new Microsoft.Office.Interop.Excel.Application();
            Exapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook Exwb;
            Microsoft.Office.Interop.Excel.Worksheet Exws;
            object data = System.Reflection.Missing.Value;
            Exwb = Exapp.Workbooks.Add(data);

            Exws = (Microsoft.Office.Interop.Excel.Worksheet)Exwb.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range r = (Microsoft.Office.Interop.Excel.Range)Exws.Cells[1, 1];
            r.Select();

            Exws.PasteSpecial(r, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
        /*private void ThemDuLieu(string MaCungCap, string TenCungCap, string SoDienThoai, string DiaChi)
        {
            String[] row = { MaCungCap, TenCungCap, SoDienThoai, DiaChi };
            System.Data.DataTable dt = dgvNhaCungCap.DataSource as System.Data.DataTable;
            dt.Rows.Add(row);
        }*/
        private void btnImport_Excel_Click(object sender, EventArgs e)
        {
            txtMaNhaCungCap.Clear();
            txtTenNhaCungCap.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            txtMaNhaCungCap.ReadOnly = true;
            txtTenNhaCungCap.ReadOnly = true;
            txtSoDienThoai.ReadOnly = true;
            txtDiaChi.ReadOnly = true;

            var dt = dgvNhaCungCap.DataSource as System.Data.DataTable;
            dt.Rows.Clear();
            dgvNhaCungCap.DataSource = dt;

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
                xlWorksheet = xlWorkbook.Worksheets["NHACUNGCAP"];
                xlRange = xlWorksheet.UsedRange;
                for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    if (xlRange.Cells[xlRow, 1].Text != "")
                    {
                        System.Data.DataTable dt_excel = dgvNhaCungCap.DataSource as System.Data.DataTable;
                        dt_excel.Rows.Add(xlRange.Cells[xlRow, 1].Text, xlRange.Cells[xlRow, 2].Text, xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text);
                        DataGridViewRow dgvr = dgvNhaCungCap.SelectedRows[0];
                        DuLieuTextbox(dgvr);
                    }    
                }
                xlWorkbook.Close();
                xlApp.Quit();
            }
            for (int i = 0; i < dgvNhaCungCap.Rows.Count; i++)
            {
                s.ThemNhaCungCap_Excel(dgvNhaCungCap.Rows[i].Cells["MANHACUNGCAP"].Value.ToString(), dgvNhaCungCap.Rows[i].Cells["TENNHACUNGCAP"].Value.ToString(), dgvNhaCungCap.Rows[i].Cells["SODIENTHOAI"].Value.ToString(), dgvNhaCungCap.Rows[i].Cells["DIACHI"].Value.ToString());
            }
            MessageBox.Show("Thêm dữ liệu từ Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvNhaCungCap.DataSource = s.HienThiNhaCungCap();
        }

        private void dgvNhaCungCap_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvNhaCungCap.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }
    }
}
