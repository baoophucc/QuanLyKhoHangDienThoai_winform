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
    public partial class TonKho : UserControl
    {
        Inventory i = new Inventory();
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public TonKho()
        {
            InitializeComponent();
        }

        private void TonKho_Load(object sender, EventArgs e)
        {
            dgvTonKho.DataSource = i.HienThiTonKho();
            label6.Enabled = false;
            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            label10.Enabled = false;
            btnDelete.Enabled = false;
            btnImport_Excel.Enabled = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            dgvTonKho.Columns["GIA"].DefaultCellStyle.Format = "#,##0";
            cboSearch.SelectedIndex = 0;
        }

        private void btnExport_Excel_Click(object sender, EventArgs e)
        {
            dgvTonKho.SelectAll();
            DataObject CopyData = dgvTonKho.GetClipboardContent();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cboSearch.SelectedIndex == 0)
            {
                string sql = "select MADIENTHOAI, TENDIENTHOAI, HEDIEUHANH, RAM, DUNGLUONGLUUTRU, SOLUONG, GIA from DIENTHOAI where MADIENTHOAI like '%" + txtSearch.Text + "%' or TENDIENTHOAI like '%" + txtSearch.Text + "%' or HEDIEUHANH like '%" + txtSearch.Text + "%' or RAM like '%" + txtSearch.Text + "%' or DUNGLUONGLUUTRU like '%" + txtSearch.Text + "%' or SOLUONG like '%" + txtSearch.Text + "%' or GIA like '%" + txtSearch.Text + "%'";
                var da = new SqlDataAdapter(sql, c);
                var dt = new DataTable();
                da.Fill(dt);
                dgvTonKho.DataSource = dt;
                if (dgvTonKho.Rows.Count < 0)
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 1)
            {
                string sql = "select MADIENTHOAI, TENDIENTHOAI, HEDIEUHANH, RAM, DUNGLUONGLUUTRU, SOLUONG, GIA from DIENTHOAI where MADIENTHOAI like '%" + txtSearch.Text + "%'";
                var da = new SqlDataAdapter(sql, c);
                var dt = new DataTable();
                da.Fill(dt);
                dgvTonKho.DataSource = dt;
                if (dgvTonKho.Rows.Count < 0)
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 2)
            {
                string sql = "select MADIENTHOAI, TENDIENTHOAI, HEDIEUHANH, RAM, DUNGLUONGLUUTRU, SOLUONG, GIA from DIENTHOAI where TENDIENTHOAI like '%" + txtSearch.Text + "%'";
                var da = new SqlDataAdapter(sql, c);
                var dt = new DataTable();
                da.Fill(dt);
                dgvTonKho.DataSource = dt;
                if (dgvTonKho.Rows.Count < 0)
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 3)
            {
                string sql = "select MADIENTHOAI, TENDIENTHOAI, HEDIEUHANH, RAM, DUNGLUONGLUUTRU, SOLUONG, GIA from DIENTHOAI where HEDIEUHANH like '%" + txtSearch.Text + "%'";
                var da = new SqlDataAdapter(sql, c);
                var dt = new DataTable();
                da.Fill(dt);
                dgvTonKho.DataSource = dt;
                if (dgvTonKho.Rows.Count < 0)
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 4)
            {
                string sql = "select MADIENTHOAI, TENDIENTHOAI, HEDIEUHANH, RAM, DUNGLUONGLUUTRU, SOLUONG, GIA from DIENTHOAI where GIA like '%" + txtSearch.Text + "%'";
                var da = new SqlDataAdapter(sql, c);
                var dt = new DataTable();
                da.Fill(dt);
                dgvTonKho.DataSource = dt;
                if (dgvTonKho.Rows.Count < 0)
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dgvTonKho.DataSource = i.HienThiTonKho();
        }

        private void dgvTonKho_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvTonKho.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }
    }
}
