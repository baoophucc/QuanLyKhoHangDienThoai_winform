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
    public partial class SuaPhieuXuat : Form
    {
        ExportDetail_Edit ede = new ExportDetail_Edit();
        ExportCoupon ec = new ExportCoupon();
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public SuaPhieuXuat()
        {
            InitializeComponent();
        }

        private void SuaPhieuXuat_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = ede.HienThiDienThoai();
            dgvPhieuXuat.DataSource = ede.HienThiPhieuXuat(txtMaPhieuXuat.Text);
            DataGridViewRow dgvr = dgvSanPham.SelectedRows[0];
            DuLieuTextbox(dgvr);
            /*DataGridViewRow dgvr_px = dgvPhieuXuat.SelectedRows[0];
            DuLieuTextbox_PhieuXuat(dgvr_px);*/
            dgvSanPham.Columns["GIA"].DefaultCellStyle.Format = "#,##0";
            dgvPhieuXuat.Columns["DONGIA"].DefaultCellStyle.Format = "#,##0";
            btnExport.Enabled = false;
            lblTongTien.Text = "0";
            double temp;
            for (int i = 0; i < dgvPhieuXuat.Rows.Count; i++)
            {
                temp = double.Parse(dgvPhieuXuat.Rows[i].Cells[2].Value.ToString()) * double.Parse(dgvPhieuXuat.Rows[i].Cells[3].Value.ToString());
                lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + temp);
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
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
            ede.XoaChiTietPhieuXuat(txtMaPhieuXuat.Text);
            for (int i = 0; i < dgvPhieuXuat.Rows.Count; i++)
            {
                ede.ThemChiTietPhieuXuat(txtMaPhieuXuat.Text, dgvPhieuXuat.Rows[i].Cells["MASANPHAM"].Value.ToString(), dgvPhieuXuat.Rows[i].Cells["SOLUONGXUAT"].Value.ToString(), dgvPhieuXuat.Rows[i].Cells["DONGIA"].Value.ToString());
            }
            ede.CapNhatTongTien(Convert.ToString(double.Parse(lblTongTien.Text)), txtMaPhieuXuat.Text);
            for (int i = 0; i < dgvPhieuXuat.Rows.Count; i++)
            {
                ede.SoLuongBanDau(dgvPhieuXuat.Rows[i].Cells["SOLUONGXUAT"].Value.ToString(), dgvPhieuXuat.Rows[i].Cells["MASANPHAM"].Value.ToString());
                ede.GiamSoLuong(dgvPhieuXuat.Rows[i].Cells["SOLUONGXUAT"].Value.ToString(), dgvPhieuXuat.Rows[i].Cells["MASANPHAM"].Value.ToString());
                dgvSanPham.Update();
                dgvSanPham.DataSource = ede.HienThiDienThoai();
            }
            MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ThemDuLieu(string MaSanPham, string TenSanPham, string SoLuongNhap, string DonGiaNhap)
        {
            String[] row = { MaSanPham, TenSanPham, SoLuongNhap, DonGiaNhap };
            DataTable dt = dgvPhieuXuat.DataSource as DataTable;
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
            ede.GiamSoLuong(txtSoLuong.Text, txtMaDienThoai.Text);
            txtSoLuong.ReadOnly = true;
            DataGridViewRow dgvr_px = dgvPhieuXuat.SelectedRows[0];
            DuLieuTextbox_PhieuXuat(dgvr_px);
            for (int i = 0; i < dgvPhieuXuat.Rows.Count; i++)
            {
                double temp = double.Parse(dgvPhieuXuat.Rows[i].Cells[2].Value.ToString()) * double.Parse(dgvPhieuXuat.Rows[i].Cells[3].Value.ToString());
                lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + temp);
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
            txtSoLuong.Clear();
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
        public void DuLieuTextbox_PhieuXuat(DataGridViewRow dgvr_px)
        {
            txtSoLuong.Text = dgvr_px.Cells[2].Value.ToString();
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
                btnExport.Enabled = true;
                int rowIndex = dgvPhieuXuat.CurrentCell.RowIndex;
                ede.SoLuongBanDau(dgvPhieuXuat.CurrentRow.Cells["SOLUONGXUAT"].Value.ToString(), dgvPhieuXuat.CurrentRow.Cells["MASANPHAM"].Value.ToString());
                dgvSanPham.DataSource = ede.HienThiDienThoai();
                dgvPhieuXuat.Rows.RemoveAt(rowIndex);
                btnExport.Enabled = true;
                if (dgvPhieuXuat.Rows.Count > 0)
                {
                    dgvPhieuXuat.Rows[0].Selected = true;
                    txtSoLuong.Text = dgvPhieuXuat.CurrentRow.Cells[2].Value.ToString();
                }
                lblTongTien.Text = "0";
                for (int i = 0; i < dgvPhieuXuat.Rows.Count; i++)
                {
                    double temp = double.Parse(dgvPhieuXuat.Rows[i].Cells[2].Value.ToString()) * double.Parse(dgvPhieuXuat.Rows[i].Cells[3].Value.ToString());
                    lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + temp);
                }
                lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
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

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            txtSoLuong.ReadOnly = false;
        }

        private void dgvPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoLuong.Text = dgvPhieuXuat.CurrentRow.Cells[2].Value.ToString();
            txtSoLuong.ReadOnly = true;
        }

        private void btnSaveQuantity_Click(object sender, EventArgs e)
        {
            if (dgvPhieuXuat.CurrentRow.Cells[2].Value.ToString() == txtSoLuong.Text)
            {
                MessageBox.Show("Hãy nhập số lượng cần sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                int rowIndex = dgvPhieuXuat.CurrentCell.RowIndex;
                ede.CapNhatSoLuong(dgvPhieuXuat.CurrentRow.Cells["SOLUONGXUAT"].Value.ToString(), txtSoLuong.Text, dgvPhieuXuat.CurrentRow.Cells["MASANPHAM"].Value.ToString());
                DataGridViewRow row_new = dgvPhieuXuat.Rows[rowIndex];
                row_new.Cells[2].Value = txtSoLuong.Text;
                btnExport.Enabled = true;
                lblTongTien.Text = "0";
                double temp;
                for (int i = 0; i < dgvPhieuXuat.Rows.Count; i++)
                {
                    temp = double.Parse(dgvPhieuXuat.Rows[i].Cells[2].Value.ToString()) * double.Parse(dgvPhieuXuat.Rows[i].Cells[3].Value.ToString());
                    lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + temp);
                }
                lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
                txtSoLuong.ReadOnly = true;
            }    
            
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
    }
}
