using DienThoai.Class;
using DienThoai.Menu;
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

namespace DienThoai.QuanLy_Menu
{
    public partial class SanPham : UserControl
    {
        Product p = new Product();
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        int indexRow;
        public SanPham()
        {
            InitializeComponent();
        }
        private void SanPham_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = p.HienThiSanPham();
            /*DataGridViewRow dgvr = dgvSanPham.SelectedRows[0];
            DuLieuTextbox(dgvr);*/
            dgvSanPham.Columns["GIA"].DefaultCellStyle.Format = "#,##0";
            /*txtDonGia.Text = Convert.ToString(double.Parse(txtDonGia.Text).ToString("#,##0"));*/
            cboSearch.SelectedIndex = 0;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = p.HienThiSanPham();
            txtSearch.Clear();
            DataGridViewRow dgvr = dgvSanPham.SelectedRows[0];
            DuLieuTextbox(dgvr);
            cboSearch.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(DangNhap.username != "admin")
            {
                MessageBox.Show("Chỉ admin được phép thêm sản phẩm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                txtMaDienThoai.ReadOnly = false;
                txtTenDienThoai.ReadOnly = false;
                cboCongNgheManHinh.Enabled = true;
                txtKichThuocManHinh.ReadOnly = false;
                txtDoPhanGiai.ReadOnly = false;
                txtHeDieuHanh.ReadOnly = false;
                txtCamTruoc.ReadOnly = false;
                txtCamSau.ReadOnly = false;
                txtChip.ReadOnly = false;
                cboRAM.Enabled = true;
                cboROM.Enabled = true;
                txtSim.ReadOnly = false;
                txtPin.ReadOnly = false;
                txtSac.ReadOnly = false;
                cboXuatXu.Enabled = true;
                txtSoLuong.ReadOnly = false;
                txtDonGia.ReadOnly = false;

                txtMaDienThoai.Clear();
                txtTenDienThoai.Clear();
                cboCongNgheManHinh.SelectedIndex = 0;
                txtKichThuocManHinh.Clear();
                txtDoPhanGiai.Clear();
                txtHeDieuHanh.Clear();
                txtCamTruoc.Clear();
                txtCamSau.Clear();
                txtChip.Clear();
                cboRAM.SelectedIndex = 0;
                cboROM.SelectedIndex = 0;
                txtSim.Clear();
                txtPin.Clear();
                txtSac.Clear();
                cboXuatXu.SelectedIndex = 0;
                txtSoLuong.Text = "0";
                txtSoLuong.ReadOnly = true;
                txtDonGia.Clear();
            }    
            
        }
        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cboSearch.SelectedIndex == 0)
            {
                string sql = "select * from DIENTHOAI where MADIENTHOAI like '%" + txtSearch.Text + "%' or TENDIENTHOAI like '%" + txtSearch.Text + "%' or CONGNGHEMANHINH like '%" + txtSearch.Text + "%' or KICHTHUOCMANHINH like '%" + txtSearch.Text + "%' or DOPHANGIAI like '%" + txtSearch.Text + "%' or HEDIEUHANH like '%" + txtSearch.Text + "%' or CHIP like '%" + txtSearch.Text + "%' or XUATXU like '%" + txtSearch.Text + "%' or GIA like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "DIENTHOAI");
                if (ds.Tables["DIENTHOAI"].Rows.Count > 0)
                    dgvSanPham.DataSource = ds.Tables["DIENTHOAI"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 1)
            {
                string sql = "select * from DIENTHOAI where MADIENTHOAI like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "DIENTHOAI");
                if (ds.Tables["DIENTHOAI"].Rows.Count > 0)
                    dgvSanPham.DataSource = ds.Tables["DIENTHOAI"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 2)
            {
                string sql = "select * from DIENTHOAI where TENDIENTHOAI like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "DIENTHOAI");
                if (ds.Tables["DIENTHOAI"].Rows.Count > 0)
                    dgvSanPham.DataSource = ds.Tables["DIENTHOAI"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 3)
            {
                string sql = "select * from DIENTHOAI where CONGNGHEMANHINH like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "DIENTHOAI");
                if (ds.Tables["DIENTHOAI"].Rows.Count > 0)
                    dgvSanPham.DataSource = ds.Tables["DIENTHOAI"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 4)
            {
                string sql = "select * from DIENTHOAI where DOPHANGIAI like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "DIENTHOAI");
                if (ds.Tables["DIENTHOAI"].Rows.Count > 0)
                    dgvSanPham.DataSource = ds.Tables["DIENTHOAI"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 5)
            {
                string sql = "select * from DIENTHOAI where HEDIEUHANH like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "DIENTHOAI");
                if (ds.Tables["DIENTHOAI"].Rows.Count > 0)
                    dgvSanPham.DataSource = ds.Tables["DIENTHOAI"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 6)
            {
                string sql = "select * from DIENTHOAI where CHIP like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "DIENTHOAI");
                if (ds.Tables["DIENTHOAI"].Rows.Count > 0)
                    dgvSanPham.DataSource = ds.Tables["DIENTHOAI"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 7)
            {
                string sql = "select * from DIENTHOAI where XUATXU like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "DIENTHOAI");
                if (ds.Tables["DIENTHOAI"].Rows.Count > 0)
                    dgvSanPham.DataSource = ds.Tables["DIENTHOAI"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboSearch.SelectedIndex == 8)
            {
                string sql = "select * from DIENTHOAI where GIA like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "DIENTHOAI");
                if (ds.Tables["DIENTHOAI"].Rows.Count > 0)
                    dgvSanPham.DataSource = ds.Tables["DIENTHOAI"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    if (string.IsNullOrEmpty(ctrl.Text))
                    {
                        MessageBox.Show("Thông tin không được rỗng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ctrl.Focus();
                        return;
                    }
                }
            }*/
            if (DangNhap.username != "admin")
            {
                return;
            }
            else
            {
                if (txtMaDienThoai.Text == "" || txtTenDienThoai.Text == "" || txtKichThuocManHinh.Text == "" || txtDoPhanGiai.Text == "" || txtPin.Text == "" || txtSac.Text == "" || txtHeDieuHanh.Text == "" || txtCamTruoc.Text == "" || txtCamSau.Text == "" || txtChip.Text == "" || txtSim.Text == "" || txtSoLuong.Text == "" || txtDonGia.Text == "")
                {
                    MessageBox.Show("Thông tin không được rỗng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtMaDienThoai.ReadOnly == false)
                {
                    if (p.KiemTraTonTaiMaDienThoai(txtMaDienThoai.Text))
                    {
                        MessageBox.Show("Mã điện thoại đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        p.ThemDienThoai(txtMaDienThoai.Text, txtTenDienThoai.Text, cboCongNgheManHinh.Text, txtKichThuocManHinh.Text + " inches", txtDoPhanGiai.Text, txtHeDieuHanh.Text, txtCamTruoc.Text + " MP", txtCamSau.Text, txtChip.Text, cboRAM.Text, cboROM.Text, txtSim.Text, txtPin.Text + " mAh", txtSac.Text + " W", cboXuatXu.Text, txtSoLuong.Text, txtDonGia.Text);
                        MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaDienThoai.ReadOnly = true;
                        txtTenDienThoai.ReadOnly = true;
                        cboCongNgheManHinh.SelectedIndex = 0;
                        txtKichThuocManHinh.ReadOnly = true;
                        txtDoPhanGiai.ReadOnly = true;
                        txtHeDieuHanh.ReadOnly = true;
                        txtCamTruoc.ReadOnly = true;
                        txtCamSau.ReadOnly = true;
                        txtChip.ReadOnly = true;
                        cboRAM.SelectedIndex = 0;
                        cboROM.SelectedIndex = 0;
                        txtSim.ReadOnly = true;
                        txtPin.ReadOnly = true;
                        txtSac.ReadOnly = true;
                        cboXuatXu.Enabled = false;
                        dgvSanPham.DataSource = p.HienThiSanPham();
                        DataGridViewRow dgvr = dgvSanPham.SelectedRows[0];
                        DuLieuTextbox(dgvr);
                    }
                }
                else
                {
                    p.CapNhatDienThoai(txtMaDienThoai.Text, txtTenDienThoai.Text, cboCongNgheManHinh.Text, txtKichThuocManHinh.Text, txtDoPhanGiai.Text, txtHeDieuHanh.Text, txtCamTruoc.Text, txtCamSau.Text, txtChip.Text, cboRAM.Text, cboROM.Text, txtSim.Text, txtPin.Text, txtSac.Text, cboXuatXu.Text, txtSoLuong.Text, Convert.ToString(double.Parse(txtDonGia.Text)));
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewRow row_new = dgvSanPham.Rows[indexRow];
                    row_new.Cells[1].Value = txtMaDienThoai.Text;
                    row_new.Cells[2].Value = txtTenDienThoai.Text;
                    row_new.Cells[3].Value = cboCongNgheManHinh.Text;
                    row_new.Cells[4].Value = txtKichThuocManHinh.Text;
                    row_new.Cells[5].Value = txtDoPhanGiai.Text;
                    row_new.Cells[6].Value = txtHeDieuHanh.Text;
                    row_new.Cells[7].Value = txtCamTruoc.Text;
                    row_new.Cells[8].Value = txtCamSau.Text;
                    row_new.Cells[9].Value = txtChip.Text;
                    row_new.Cells[10].Value = cboRAM.Text;
                    row_new.Cells[11].Value = cboROM.Text;
                    row_new.Cells[12].Value = txtSim.Text;
                    row_new.Cells[13].Value = txtPin.Text;
                    row_new.Cells[14].Value = txtSac.Text;
                    row_new.Cells[15].Value = cboXuatXu.Text;
                    row_new.Cells[16].Value = txtSoLuong.Text;
                    row_new.Cells[17].Value = Convert.ToString(double.Parse(txtDonGia.Text));

                    txtMaDienThoai.ReadOnly = true;
                    txtTenDienThoai.ReadOnly = true;
                    cboCongNgheManHinh.Enabled = false;
                    txtKichThuocManHinh.ReadOnly = true;
                    txtDoPhanGiai.ReadOnly = true;
                    txtHeDieuHanh.ReadOnly = true;
                    txtCamTruoc.ReadOnly = true;
                    txtCamSau.ReadOnly = true;
                    txtChip.ReadOnly = true;
                    cboRAM.Enabled = false;
                    cboROM.Enabled = false;
                    txtSim.ReadOnly = true;
                    txtPin.ReadOnly = true;
                    txtSac.ReadOnly = true;
                    cboXuatXu.Enabled = false;
                }
            }
            
        }   
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DangNhap.username != "admin")
            {
                MessageBox.Show("Chỉ admin được phép sửa sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                txtTenDienThoai.ReadOnly = false;
                cboCongNgheManHinh.Enabled = true;
                txtKichThuocManHinh.ReadOnly = false;
                txtDoPhanGiai.ReadOnly = false;
                txtHeDieuHanh.ReadOnly = false;
                txtCamTruoc.ReadOnly = false;
                txtCamSau.ReadOnly = false;
                txtChip.ReadOnly = false;
                cboRAM.Enabled = true;
                cboROM.Enabled = true;
                txtSim.ReadOnly = false;
                txtPin.ReadOnly = false;
                txtSac.ReadOnly = false;
                cboXuatXu.Enabled = true;
                txtSoLuong.ReadOnly = true;
                txtDonGia.ReadOnly = false;
            }    
            
        }

        private void txtSim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được phép nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được phép nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dgvSanPham.Rows[indexRow];
            txtMaDienThoai.Text = dgvSanPham.CurrentRow.Cells[1].Value.ToString();
            txtTenDienThoai.Text = dgvSanPham.CurrentRow.Cells[2].Value.ToString();
            cboCongNgheManHinh.Text = dgvSanPham.CurrentRow.Cells[3].Value.ToString();
            txtKichThuocManHinh.Text = dgvSanPham.CurrentRow.Cells[4].Value.ToString();
            txtDoPhanGiai.Text = dgvSanPham.CurrentRow.Cells[5].Value.ToString();
            txtHeDieuHanh.Text = dgvSanPham.CurrentRow.Cells[6].Value.ToString();
            txtCamTruoc.Text = dgvSanPham.CurrentRow.Cells[7].Value.ToString();
            txtCamSau.Text = dgvSanPham.CurrentRow.Cells[8].Value.ToString();
            txtChip.Text = dgvSanPham.CurrentRow.Cells[9].Value.ToString();
            cboRAM.Text = dgvSanPham.CurrentRow.Cells[10].Value.ToString();
            cboROM.Text = dgvSanPham.CurrentRow.Cells[11].Value.ToString();
            txtSim.Text = dgvSanPham.CurrentRow.Cells[12].Value.ToString();
            txtPin.Text = dgvSanPham.CurrentRow.Cells[13].Value.ToString();
            txtSac.Text = dgvSanPham.CurrentRow.Cells[14].Value.ToString();
            cboXuatXu.Text = dgvSanPham.CurrentRow.Cells[15].Value.ToString();
            txtSoLuong.Text = dgvSanPham.CurrentRow.Cells[16].Value.ToString();
            txtDonGia.Text = dgvSanPham.CurrentRow.Cells[17].Value.ToString();
            txtDonGia.Text = Convert.ToString(double.Parse(txtDonGia.Text).ToString("#,##0"));

            txtMaDienThoai.ReadOnly = true;
            txtTenDienThoai.ReadOnly = true;
            cboCongNgheManHinh.Enabled = false;
            txtKichThuocManHinh.ReadOnly = true;
            txtDoPhanGiai.ReadOnly = true;
            txtHeDieuHanh.ReadOnly = true;
            txtCamTruoc.ReadOnly = true;
            txtCamSau.ReadOnly = true;
            txtChip.ReadOnly = true;
            cboRAM.Enabled = false;
            cboROM.Enabled = false;
            txtSim.ReadOnly = true;
            txtPin.ReadOnly = true;
            txtSac.ReadOnly = true;
            cboXuatXu.Enabled = false;
            txtSoLuong.ReadOnly = true;
            txtDonGia.ReadOnly = true;
        }
        public void DuLieuTextbox(DataGridViewRow dgvr)
        {
            txtMaDienThoai.Text = dgvr.Cells[1].Value.ToString();
            txtTenDienThoai.Text = dgvr.Cells[2].Value.ToString();
            cboCongNgheManHinh.Text = dgvr.Cells[3].Value.ToString();
            txtKichThuocManHinh.Text = dgvr.Cells[4].Value.ToString();
            txtDoPhanGiai.Text = dgvr.Cells[5].Value.ToString();
            txtHeDieuHanh.Text = dgvr.Cells[6].Value.ToString();
            txtCamTruoc.Text = dgvr.Cells[7].Value.ToString();
            txtCamSau.Text = dgvr.Cells[8].Value.ToString();
            txtChip.Text = dgvr.Cells[9].Value.ToString();
            cboRAM.Text = dgvr.Cells[10].Value.ToString();
            cboROM.Text = dgvr.Cells[11].Value.ToString();
            txtSim.Text = dgvr.Cells[12].Value.ToString();
            txtPin.Text = dgvr.Cells[13].Value.ToString();
            txtSac.Text = dgvr.Cells[14].Value.ToString();
            cboXuatXu.Text = dgvr.Cells[15].Value.ToString();
            txtSoLuong.Text = dgvr.Cells[16].Value.ToString();
            txtDonGia.Text = dgvr.Cells[17].Value.ToString();
            txtDonGia.Text = double.Parse(txtDonGia.Text).ToString("#,##0");
        }
        private void btnExport_Excel_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application MExcel = new Microsoft.Office.Interop.Excel.Application();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvSanPham.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dgvSanPham.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvSanPham.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvSanPham.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dgvSanPham.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
            }
            else
            {
                MessageBox.Show("Không thể xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!p.KiemTraKhoaNgoaiSanPham(dgvSanPham.CurrentRow.Cells["MADIENTHOAI"].Value.ToString()))
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    p.XoaDienThoai(txtMaDienThoai.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgvSanPham.DataSource = p.HienThiSanPham();
                dgvSanPham.Rows[0].Selected = true;
                DuLieuTextbox(dgvSanPham.Rows[0]);
            }
            else
            {
                MessageBox.Show("Sản phẩm này tồn tại trong phiếu nhập / xuất\nKhông thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }    
            
        }

        private void btnImport_Excel_Click(object sender, EventArgs e)
        {
            if (DangNhap.username != "admin")
            {
                MessageBox.Show("Chỉ admin được phép thêm sản phẩm từ Excel", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                var dt = dgvSanPham.DataSource as DataTable;
                dt.Rows.Clear();
                dgvSanPham.DataSource = dt;

                txtMaDienThoai.Clear();
                txtTenDienThoai.Clear();
                cboCongNgheManHinh.SelectedIndex = 0;
                txtKichThuocManHinh.Clear();
                txtDoPhanGiai.Clear();
                txtHeDieuHanh.Clear();
                txtCamTruoc.Clear();
                txtCamSau.Clear();
                txtChip.Clear();
                cboRAM.SelectedIndex = 0;
                cboROM.SelectedIndex = 0;
                txtSim.Clear();
                txtPin.Clear();
                txtSac.Clear();
                cboXuatXu.SelectedIndex = 0;
                txtSoLuong.Clear();
                txtDonGia.Clear();

                txtMaDienThoai.ReadOnly = true;
                txtTenDienThoai.ReadOnly = true;
                cboCongNgheManHinh.Enabled = false;
                txtKichThuocManHinh.ReadOnly = true;
                txtDoPhanGiai.ReadOnly = true;
                txtHeDieuHanh.ReadOnly = true;
                txtCamTruoc.ReadOnly = true;
                txtCamSau.ReadOnly = true;
                txtChip.ReadOnly = true;
                cboRAM.Enabled = false;
                cboROM.Enabled = false;
                txtSim.ReadOnly = true;
                txtPin.ReadOnly = true;
                txtSac.ReadOnly = true;
                cboXuatXu.Enabled = false;
                txtSoLuong.ReadOnly = true;
                txtDonGia.ReadOnly = true;

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
                    xlWorksheet = xlWorkbook.Worksheets["SANPHAM"];
                    xlRange = xlWorksheet.UsedRange;
                    for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                    {
                        if (xlRange.Cells[xlRow, 1].Text != "")
                        {
                            DataTable dt_excel = dgvSanPham.DataSource as DataTable;
                            dt_excel.Rows.Add(xlRange.Cells[xlRow, 1].Text, xlRange.Cells[xlRow, 2].Text, xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text, xlRange.Cells[xlRow, 5].Text, xlRange.Cells[xlRow, 6].Text, xlRange.Cells[xlRow, 7].Text, xlRange.Cells[xlRow, 8].Text, xlRange.Cells[xlRow, 9].Text, xlRange.Cells[xlRow, 10].Text, xlRange.Cells[xlRow, 11].Text, xlRange.Cells[xlRow, 12].Text, xlRange.Cells[xlRow, 13].Text, xlRange.Cells[xlRow, 14].Text, xlRange.Cells[xlRow, 15].Text, xlRange.Cells[xlRow, 16].Text, xlRange.Cells[xlRow, 17].Text);
                            DataGridViewRow dgvr = dgvSanPham.SelectedRows[0];
                            DuLieuTextbox(dgvr);
                        }
                    }
                    xlWorkbook.Close();
                    xlApp.Quit();
                }
                for (int i = 0; i < dgvSanPham.Rows.Count; i++)
                {
                    p.ThemDienThoai_Excel(dgvSanPham.Rows[i].Cells["MADIENTHOAI"].Value.ToString(), dgvSanPham.Rows[i].Cells["TENDIENTHOAI"].Value.ToString(), dgvSanPham.Rows[i].Cells["CONGNGHEMANHINH"].Value.ToString(), dgvSanPham.Rows[i].Cells["KICHTHUOCMANHINH"].Value.ToString(), dgvSanPham.Rows[i].Cells["DOPHANGIAI"].Value.ToString(), dgvSanPham.Rows[i].Cells["HEDIEUHANH"].Value.ToString(), dgvSanPham.Rows[i].Cells["CAMTRUOC"].Value.ToString(), dgvSanPham.Rows[i].Cells["CAMSAU"].Value.ToString(), dgvSanPham.Rows[i].Cells["CHIP"].Value.ToString(), dgvSanPham.Rows[i].Cells["RAM"].Value.ToString(), dgvSanPham.Rows[i].Cells["DUNGLUONGLUUTRU"].Value.ToString(), dgvSanPham.Rows[i].Cells["SIM"].Value.ToString(), dgvSanPham.Rows[i].Cells["DUNGLUONGPIN"].Value.ToString(), dgvSanPham.Rows[i].Cells["SAC"].Value.ToString(), dgvSanPham.Rows[i].Cells["XUATXU"].Value.ToString(), dgvSanPham.Rows[i].Cells["SOLUONG"].Value.ToString(), dgvSanPham.Rows[i].Cells["GIA"].Value.ToString());
                }
                MessageBox.Show("Thêm dữ liệu từ Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSanPham.DataSource = p.HienThiSanPham();
            }
            
        }

        private void dgvSanPham_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvSanPham.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được phép nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }

        private void txtSac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được phép nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được phép nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }
    }
}
