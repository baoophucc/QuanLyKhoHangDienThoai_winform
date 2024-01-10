using DienThoai.Class;
using iTextSharp.text.pdf.codec;
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
    public partial class TaiKhoan : UserControl
    {
        Account a = new Account();
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        int indexRow;
        string VaiTro = "Nhân viên";
        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            dgvTaiKhoan.DataSource = a.HienThiTaiKhoan();
            /*DataGridViewRow dgvr = dgvTaiKhoan.SelectedRows[0];
            DuLieuTextbox(dgvr);*/
            cboSearch.SelectedIndex = 0;
            
        }
        private void btnExport_Excel_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application MExcel = new Microsoft.Office.Interop.Excel.Application();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvTaiKhoan.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dgvTaiKhoan.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvTaiKhoan.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvTaiKhoan.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dgvTaiKhoan.Rows[i].Cells[j].Value.ToString();
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
        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvTaiKhoan.DataSource = a.HienThiTaiKhoan();
            txtSearch.Clear();
            cboSearch.SelectedIndex = 0;
            DataGridViewRow dgvr = dgvTaiKhoan.SelectedRows[0];
            DuLieuTextbox(dgvr);
        }
        private void btnImport_Excel_Click(object sender, EventArgs e)
        {
            var dt = dgvTaiKhoan.DataSource as DataTable;
            dt.Rows.Clear();
            dgvTaiKhoan.DataSource = dt;

            txtTenTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtHoVaTen.Clear();
            txtEmail.Clear();

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
                xlWorksheet = xlWorkbook.Worksheets["TAIKHOAN"];
                xlRange = xlWorksheet.UsedRange;
                for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    if (xlRange.Cells[xlRow, 1].Text != "")
                    {
                        DataTable dt_excel = dgvTaiKhoan.DataSource as DataTable;
                        dt_excel.Rows.Add(xlRange.Cells[xlRow, 1].Text, xlRange.Cells[xlRow, 2].Text, xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text);
                        DataGridViewRow dgvr = dgvTaiKhoan.SelectedRows[0];
                    }
                }
                xlWorkbook.Close();
                xlApp.Quit();
            }
            for (int i = 0; i < dgvTaiKhoan .Rows.Count; i++)
            {
                a.ThemTaiKhoan_Excel(dgvTaiKhoan.Rows[i].Cells["TENTAIKHOAN"].Value.ToString(), dgvTaiKhoan.Rows[i].Cells["MATKHAU"].Value.ToString(), dgvTaiKhoan.Rows[i].Cells["HOVATEN"].Value.ToString(), dgvTaiKhoan.Rows[i].Cells["VAITRO"].Value.ToString(), dgvTaiKhoan.Rows[i].Cells["EMAIL"].Value.ToString());
            }
            MessageBox.Show("Thêm dữ liệu từ Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTaiKhoan.DataSource = a.HienThiTaiKhoan();
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


            if (txtTenTaiKhoan.Text == "" || txtMatKhau.Text == "" || txtHoVaTen.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Thông tin không được rỗng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }    
            if (!a.IsEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtTenTaiKhoan.ReadOnly == false)
            {
                if (a.KiemTraTonTaiTenTaiKhoan(txtTenTaiKhoan.Text))
                {
                    MessageBox.Show("Tên tài khoản đã được đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (a.KiemTraTonTaiEmail(txtEmail.Text))
                    {
                        MessageBox.Show("Email đã được đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        a.ThemTaiKhoan(txtTenTaiKhoan.Text, txtMatKhau.Text, txtHoVaTen.Text, VaiTro, txtEmail.Text);
                        MessageBox.Show("Thêm tài khoản thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTenTaiKhoan.ReadOnly = true;
                        txtMatKhau.ReadOnly = true;
                        txtHoVaTen.ReadOnly = true;
                        txtEmail.ReadOnly = true;
                        dgvTaiKhoan.DataSource = a.HienThiTaiKhoan();
                        DataGridViewRow dgvr = dgvTaiKhoan.SelectedRows[0];
                        DuLieuTextbox(dgvr);
                    }

                }
            }
            else
            {
                a.CapNhatTaiKhoan(txtTenTaiKhoan.Text, txtMatKhau.Text, txtHoVaTen.Text, txtEmail.Text);
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewRow row_new = dgvTaiKhoan.Rows[indexRow];
                row_new.Cells[1].Value = txtTenTaiKhoan.Text;
                row_new.Cells[2].Value = txtMatKhau.Text;
                row_new.Cells[3].Value = txtHoVaTen.Text;
                row_new.Cells[4].Value = txtEmail.Text;

                txtMatKhau.ReadOnly = true;
                txtHoVaTen.ReadOnly = true;
                txtEmail.ReadOnly = true;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cboSearch.SelectedIndex == 0)
            {
                string sql = "select * from TAIKHOAN where TENTAIKHOAN like '%" + txtSearch.Text + "%' or HOVATEN like '%" + txtSearch.Text + "%' or EMAIL like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "TAIKHOAN");
                if (ds.Tables["TAIKHOAN"].Rows.Count > 0)
                    dgvTaiKhoan.DataSource = ds.Tables["TAIKHOAN"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            if (cboSearch.SelectedIndex == 1)
            {
                string sql = "select * from TAIKHOAN where TENTAIKHOAN like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "TAIKHOAN");
                if (ds.Tables["TAIKHOAN"].Rows.Count > 0)
                    dgvTaiKhoan.DataSource = ds.Tables["TAIKHOAN"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            if (cboSearch.SelectedIndex == 2)
            {
                string sql = "select * from TAIKHOAN where HOVATEN like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "TAIKHOAN");
                if (ds.Tables["TAIKHOAN"].Rows.Count > 0)
                    dgvTaiKhoan.DataSource = ds.Tables["TAIKHOAN"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            if (cboSearch.SelectedIndex == 3)
            {
                string sql = "select * from TAIKHOAN where EMAIL like '%" + txtSearch.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, c);
                da.Fill(ds, "TAIKHOAN");
                if (ds.Tables["TAIKHOAN"].Rows.Count > 0)
                    dgvTaiKhoan.DataSource = ds.Tables["TAIKHOAN"];
                else
                    MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow.Cells[1].Value.ToString() == "admin")
            {
                MessageBox.Show("Không thể xóa tài khoản admin!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (!a.KiemTraKhoaNgoaiTaiKhoan(dgvTaiKhoan.CurrentRow.Cells[1].Value.ToString()))
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        a.XoaTaiKhoan(txtTenTaiKhoan.Text);
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        dgvTaiKhoan.DataSource = a.HienThiTaiKhoan();
                        dgvTaiKhoan.Update();
                        dgvTaiKhoan.Rows[0].Selected = true;
                        DuLieuTextbox(dgvTaiKhoan.Rows[0]);
                    }
                }    
                else
                {
                    MessageBox.Show("Lỗi : Tài khoản này đã tạo phiếu nhập / xuất\nKhông thể xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }    
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtMatKhau.ReadOnly = false;
            txtHoVaTen.ReadOnly = false;
        }

        public void DuLieuTextbox(DataGridViewRow dgvr)
        {
            txtTenTaiKhoan.Text = dgvr.Cells[1].Value.ToString();
            txtMatKhau.Text = dgvr.Cells[2].Value.ToString();
            txtHoVaTen.Text = dgvr.Cells[3].Value.ToString();
            txtEmail.Text = dgvr.Cells[5].Value.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtTenTaiKhoan.ReadOnly = false;
            txtMatKhau.ReadOnly = false;
            txtHoVaTen.ReadOnly = false;
            txtEmail.ReadOnly = false;

            txtTenTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtHoVaTen.Clear();
            txtEmail.Clear();
        }
        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked)
                txtMatKhau.UseSystemPasswordChar = false;
            else
                txtMatKhau.UseSystemPasswordChar = true;
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenTaiKhoan.Text = dgvTaiKhoan.CurrentRow.Cells[1].Value.ToString();
            txtMatKhau.Text = dgvTaiKhoan.CurrentRow.Cells[2].Value.ToString();
            txtHoVaTen.Text = dgvTaiKhoan.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgvTaiKhoan.CurrentRow.Cells[5].Value.ToString();

            txtTenTaiKhoan.ReadOnly = true;
            txtMatKhau.ReadOnly = true;
            txtHoVaTen.ReadOnly = true;
            txtEmail.ReadOnly = true;
            chkPassword.Checked = false;
        }

        private void dgvTaiKhoan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvTaiKhoan.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }
    }
}
