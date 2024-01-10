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
    public partial class SuaPhieuNhap : Form
    {
        ImportDetail_Edit ide = new ImportDetail_Edit();
        ImportCoupon ic = new ImportCoupon();
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        int indexRow;
        public SuaPhieuNhap()
        {
            InitializeComponent();
        }

        private void SuaPhieuNhap_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = ide.HienThiDienThoai();
            dgvPhieuNhap.DataSource = ide.HienThiPhieuNhap(txtMaPhieuNhap.Text);
            btnImport.Enabled = false;
            DataGridViewRow dgvr = dgvSanPham.SelectedRows[0];
            DuLieuTextbox(dgvr);
            /*DataGridViewRow dgvr_pn = dgvPhieuNhap.SelectedRows[0];
            DuLieuTextbox_PhieuNhap(dgvr_pn);*/
            dgvSanPham.Columns["GIA"].DefaultCellStyle.Format = "#,##0";
            dgvPhieuNhap.Columns["DONGIA"].DefaultCellStyle.Format = "#,##0";
            lblTongTien.Text = "0";
            double temp;
            for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
            {
                temp = double.Parse(dgvPhieuNhap.Rows[i].Cells["SOLUONGNHAP"].Value.ToString()) * double.Parse(dgvPhieuNhap.Rows[i].Cells["DONGIA"].Value.ToString());
                lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + temp);
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDienThoai.Text = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
            txtTenDienThoai.Text = dgvSanPham.CurrentRow.Cells[1].Value.ToString();
            txtDonGia.Text = double.Parse(dgvSanPham.CurrentRow.Cells[3].Value.ToString()).ToString("#,##0");
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
        private void ThemDuLieu(string MaSanPham, string TenSanPham, string SoLuongNhap, string DonGiaNhap)
        {
            String[] row = { MaSanPham, TenSanPham, SoLuongNhap, DonGiaNhap };
            DataTable dt = dgvPhieuNhap.DataSource as DataTable;
            dt.Rows.Add(row);
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
            KiemTraTonTaiMaSanPham();
            ide.ThemSoLuong(txtSoLuong.Text, txtMaDienThoai.Text);
            txtSoLuong.ReadOnly = true;
            DataGridViewRow dgvr_pn = dgvPhieuNhap.SelectedRows[0];
            DuLieuTextbox_PhieuNhap(dgvr_pn);
            for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
            {
                double temp = double.Parse(dgvPhieuNhap.Rows[i].Cells[2].Value.ToString()) * double.Parse(dgvPhieuNhap.Rows[i].Cells[3].Value.ToString());
                lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + temp);
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
            txtSoLuong.Clear();
        }
        private void KiemTraTonTaiMaSanPham()
        {
            bool found = false;
            if (dgvPhieuNhap.Rows.Count > 0)
            {
                foreach (DataGridViewRow row_check in dgvPhieuNhap.Rows)
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
        public void DuLieuTextbox_PhieuNhap(DataGridViewRow dgvr_pn)
        {
            txtSoLuong.Text = dgvr_pn.Cells[2].Value.ToString();
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoLuong.Text = dgvPhieuNhap.CurrentRow.Cells[2].Value.ToString();
            txtSoLuong.ReadOnly = true;
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            txtSoLuong.ReadOnly = false;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            DataGridViewRow dgvr = dgvSanPham.SelectedRows[0];
            DuLieuTextbox(dgvr);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "select MADIENTHOAI, TENDIENTHOAI, SOLUONG, GIA from DIENTHOAI where MADIENTHOAI like '%" + txtSearch.Text + "%' or TENDIENTHOAI like '%" + txtSearch.Text + "%' or GIA like '%" + txtSearch.Text + "%'";
            var da = new SqlDataAdapter(sql, c);
            var dt = new DataTable();
            da.Fill(dt);
            dgvSanPham.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblTongTien.Text == "0")
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                return;
            }
            else
            {
                btnImport.Enabled = true;
                int rowIndex = dgvPhieuNhap.CurrentCell.RowIndex;
                ide.SoLuongBanDau(dgvPhieuNhap.CurrentRow.Cells["SOLUONGNHAP"].Value.ToString(), dgvPhieuNhap.CurrentRow.Cells["MASANPHAM"].Value.ToString());
                dgvPhieuNhap.Rows.RemoveAt(rowIndex);
                lblTongTien.Text = "0";
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                {
                    double temp = double.Parse(dgvPhieuNhap.Rows[i].Cells[2].Value.ToString()) * double.Parse(dgvPhieuNhap.Rows[i].Cells[3].Value.ToString());
                    lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + temp);
                }
                lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
            }  
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (lblTongTien.Text != "0")
            {
                ide.XoaChiTietPhieuNhap(txtMaPhieuNhap.Text);
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                {
                    ide.ThemChiTietPhieuNhap(txtMaPhieuNhap.Text, dgvPhieuNhap.Rows[i].Cells["MASANPHAM"].Value.ToString(), dgvPhieuNhap.Rows[i].Cells["SOLUONGNHAP"].Value.ToString(), dgvPhieuNhap.Rows[i].Cells["DONGIA"].Value.ToString());
                }
                ide.CapNhatPhieuNhap(Convert.ToString(double.Parse(lblTongTien.Text)), cboNhaCungCap.Text = ide.HienThiMaCungCap(cboNhaCungCap.Text), txtMaPhieuNhap.Text);
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                {
                    ide.SoLuongBanDau(dgvPhieuNhap.Rows[i].Cells["SOLUONGNHAP"].Value.ToString(), dgvPhieuNhap.Rows[i].Cells["MASANPHAM"].Value.ToString());
                    ide.ThemSoLuong(dgvPhieuNhap.Rows[i].Cells["SOLUONGNHAP"].Value.ToString(), dgvPhieuNhap.Rows[i].Cells["MASANPHAM"].Value.ToString());
                    dgvSanPham.Update();
                    dgvSanPham.DataSource = ide.HienThiDienThoai();
                }
                MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            
        }
        
        private void btnSaveQuantity_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow.Cells[2].Value.ToString() == txtSoLuong.Text)
            {
                MessageBox.Show("Hãy nhập số lượng cần sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                int rowIndex = dgvPhieuNhap.CurrentCell.RowIndex;
                ide.CapNhatSoLuong(dgvPhieuNhap.CurrentRow.Cells["SOLUONGNHAP"].Value.ToString(), txtSoLuong.Text, dgvPhieuNhap.CurrentRow.Cells["MASANPHAM"].Value.ToString());
                DataGridViewRow row_new = dgvPhieuNhap.Rows[rowIndex];
                row_new.Cells[2].Value = txtSoLuong.Text;
                btnImport.Enabled = true;
                lblTongTien.Text = "0";
                double temp;
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                {
                    temp = double.Parse(dgvPhieuNhap.Rows[i].Cells[2].Value.ToString()) * double.Parse(dgvPhieuNhap.Rows[i].Cells[3].Value.ToString());
                    lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + temp);
                }
                lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
                txtSoLuong.ReadOnly = true;
            }    
        }

        private void cboNhaCungCap_Click(object sender, EventArgs e)
        {
            cboNhaCungCap.DisplayMember = "TENNHACUNGCAP";
            cboNhaCungCap.ValueMember = "MANHACUNGCAP";
            cboNhaCungCap.DataSource = ide.HienThiNhaCungCap(); 
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được phép nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }
    }
}