using DienThoai.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace DienThoai.Menu
{
    public partial class ThongKe : UserControl
    {
        Statistical s = new Statistical();
        QuanLyDienThoai ds = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public ThongKe()
        {
            InitializeComponent();
        }
        
        private void ThongKe_Load(object sender, EventArgs e)
        {
            lblAccount.Text = s.ThongKeSoTaiKhoan().ToString();
            lblSupplier.Text = s.ThongKeSoNhaCungCap().ToString();
            lblProduct.Text = s.ThongKeSoSanPham().ToString();
            cboSearchCoupon.Items.Add("Phiếu nhập");
            cboSearchCoupon.Items.Add("Phiếu xuất");
            cboSearchCoupon.SelectedIndex = 0;
            dgvThongKeSanPham.DataSource = s.ThongKeNhapXuat();
            dgvThongKeTaiKhoan.DataSource = s.HienThiThongKeTaiKhoan();
            dgvPhieu.Columns["MANHACUNGCAP"].HeaderText = "Nhà cung cấp";
        }

        private void txtSearchAccount_TextChanged(object sender, EventArgs e)
        {
            string s = "select * from TAIKHOAN where TENTAIKHOAN like '%" + txtSearchAccount.Text + "%' or HOVATEN like '%" + txtSearchAccount.Text + "%' or EMAIL like '%" + txtSearchAccount.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(s, c);
            da.Fill(ds, "TAIKHOAN");
            if (ds.Tables["TAIKHOAN"].Rows.Count > 0)
                dgvThongKeTaiKhoan.DataSource = ds.Tables["TAIKHOAN"];
        }

        private void cboSearchCoupon_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTongTien.Text = "0";
            lblTongPhieu.Text = "0";
            if (cboSearchCoupon.SelectedIndex == 0)
            {
                txtGiaNho.Clear();
                txtGiaLon.Clear();
                dtpPhieu_DenNgay.Value = DateTime.Now;
                dtpPhieu_TuNgay.Value = DateTime.Now;
                txtSearchCoupon.Clear();
                dgvPhieu.DataSource = s.PhieuNhap();
                for (int i = 0; i < dgvPhieu.Rows.Count; i++)
                {
                    lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + double.Parse(dgvPhieu.Rows[i].Cells["TONGTIEN"].Value.ToString()));
                    lblTongPhieu.Text = dgvPhieu.RowCount.ToString();
                    dgvPhieu.Columns["TONGTIEN"].DefaultCellStyle.Format = "#,##0";
                }
                lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
                dgvPhieu.Columns["MANHACUNGCAP"].HeaderText = "Nhà cung cấp";
                for (int i = 0; i < dgvPhieu.Rows.Count; i++)
                {
                    dgvPhieu.Rows[i].Cells["MANHACUNGCAP"].Value = s.TenNhaCungCap(dgvPhieu.Rows[i].Cells["MANHACUNGCAP"].Value.ToString());
                }
            }
            if (cboSearchCoupon.SelectedIndex == 1)
            {
                dgvPhieu.Columns["MANHACUNGCAP"].Visible = false;
                txtGiaNho.Clear();
                txtGiaLon.Clear();
                dtpPhieu_DenNgay.Value = DateTime.Now;
                dtpPhieu_TuNgay.Value = DateTime.Now;
                dgvPhieu.DataSource = s.PhieuXuat();
                txtSearchCoupon.Clear();
                for (int i = 0; i < dgvPhieu.Rows.Count; i++)
                {
                    lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + double.Parse(dgvPhieu.Rows[i].Cells["TONGTIEN"].Value.ToString()));
                    lblTongPhieu.Text = dgvPhieu.RowCount.ToString();
                    dgvPhieu.Columns["TONGTIEN"].DefaultCellStyle.Format = "#,##0";
                }
                lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
            }
        }

        private void dgvThongKeSanPham_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvThongKeSanPham.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string s = "select DIENTHOAI.MADIENTHOAI, DIENTHOAI.TENDIENTHOAI, SUM(SOLUONGNHAP) as N'Số lượng nhập', SUM(SOLUONGXUAT) as N'Số lượng xuất' from DIENTHOAI INNER JOIN CHITIETPHIEUNHAP ON DIENTHOAI.MADIENTHOAI = CHITIETPHIEUNHAP.MADIENTHOAI INNER JOIN CHITIETPHIEUXUAT ON DIENTHOAI.MADIENTHOAI = CHITIETPHIEUXUAT.MADIENTHOAI where DIENTHOAI.MADIENTHOAI like '%" + txtSearchProduct.Text + "%' or DIENTHOAI.TENDIENTHOAI like '%" + txtSearchProduct.Text + "' group by DIENTHOAI.MADIENTHOAI, DIENTHOAI.TENDIENTHOAI";
            var da = new SqlDataAdapter(s, c);
            var dt = new DataTable();
            da.Fill(dt);
            dgvThongKeSanPham.DataSource = dt;
        }
        private void btnResetAccount_Click(object sender, EventArgs e)
        {
            dgvThongKeTaiKhoan.DataSource = s.HienThiThongKeTaiKhoan();
            txtSearchAccount.Clear();
        }

        private void dgvPhieu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvPhieu.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        private void btnResetCoupon_Click(object sender, EventArgs e)
        {
            txtGiaNho.Clear();
            txtGiaLon.Clear();
            dtpPhieu_DenNgay.Value = DateTime.Now;
            dtpPhieu_TuNgay.Value = DateTime.Now;
            txtSearchCoupon.Clear();
            dgvPhieu.DataSource = s.PhieuNhap();
            cboSearchCoupon.SelectedIndex = 0;
            dgvPhieu.Columns["MANHACUNGCAP"].HeaderText = "Nhà cung cấp";
            for (int i = 0; i < dgvPhieu.Rows.Count; i++)
            {
                dgvPhieu.Rows[i].Cells["MANHACUNGCAP"].Value = s.TenNhaCungCap(dgvPhieu.Rows[i].Cells["MANHACUNGCAP"].Value.ToString());
            }
        }
        public void TimKiemGia_PN()
        {
            string s = "select MAPHIEU, THOIGIANTAO, NGUOITAO, TONGTIEN from PHIEUNHAP where TONGTIEN BETWEEN '" + txtGiaNho.Text + "' AND '" + txtGiaLon.Text + "'";
            var da = new SqlDataAdapter(s, c);
            var dt = new DataTable();
            da.Fill(dt);
            dgvPhieu.DataSource = dt;
            for (int i = 0; i < dgvPhieu.Rows.Count; i++)
            {
                lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + double.Parse(dgvPhieu.Rows[i].Cells["TONGTIEN"].Value.ToString()));
                lblTongPhieu.Text = dgvPhieu.RowCount.ToString();
                dgvPhieu.Columns["TONGTIEN"].DefaultCellStyle.Format = "#,##0";
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
        }
        public void TimKiemNgay_PN()
        {
            string s = "select MAPHIEU, THOIGIANTAO, NGUOITAO, TONGTIEN from PHIEUNHAP where THOIGIANTAO BETWEEN '" + dtpPhieu_TuNgay.Text + "' AND '" + dtpPhieu_DenNgay.Text + "'";
            var da = new SqlDataAdapter(s, c);
            var dt = new DataTable();
            da.Fill(dt);
            dgvPhieu.DataSource = dt;
            for (int i = 0; i < dgvPhieu.Rows.Count; i++)
            {
                lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + double.Parse(dgvPhieu.Rows[i].Cells["TONGTIEN"].Value.ToString()));
                lblTongPhieu.Text = dgvPhieu.RowCount.ToString();
                dgvPhieu.Columns["TONGTIEN"].DefaultCellStyle.Format = "#,##0";
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
        }
        public void TimKiemGia_PX()
        {
            string s = "select * from PHIEUXUAT where TONGTIEN BETWEEN '" + txtGiaNho.Text + "' AND '" + txtGiaLon.Text + "'";
            var da = new SqlDataAdapter(s, c);
            var dt = new DataTable();
            da.Fill(dt);
            dgvPhieu.DataSource = dt;
            for (int i = 0; i < dgvPhieu.Rows.Count; i++)
            {
                lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + double.Parse(dgvPhieu.Rows[i].Cells["TONGTIEN"].Value.ToString()));
                lblTongPhieu.Text = dgvPhieu.RowCount.ToString();
                dgvPhieu.Columns["TONGTIEN"].DefaultCellStyle.Format = "#,##0";
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
        }
        public void TimKiemNgay_PX()
        {
            string s = "select * from PHIEUXUAT where THOIGIANTAO BETWEEN '" + dtpPhieu_TuNgay.Text + "' AND '" + dtpPhieu_DenNgay.Text + "'";
            var da = new SqlDataAdapter(s, c);
            var dt = new DataTable();
            da.Fill(dt);
            dgvPhieu.DataSource = dt;
            for (int i = 0; i < dgvPhieu.Rows.Count; i++)
            {
                lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + double.Parse(dgvPhieu.Rows[i].Cells["TONGTIEN"].Value.ToString()));
                lblTongPhieu.Text = dgvPhieu.RowCount.ToString();
                dgvPhieu.Columns["TONGTIEN"].DefaultCellStyle.Format = "#,##0";
            }
            lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
        }
        public void TimKiemPN()
        {
            string s = "select * from PHIEUNHAP where MAPHIEU like '%" + txtSearchCoupon.Text + "%' or NGUOITAO like '%" + txtSearchCoupon.Text + "%'";
            var da = new SqlDataAdapter(s, c);
            var dt = new DataTable();
            da.Fill(dt);
            dgvPhieu.DataSource = dt;
        }
        public void TimKiemPX()
        {
            string s = "select MAPHIEU, THOIGIANTAO, NGUOITAO, TONGTIEN from PHIEUXUAT where MAPHIEU like '%" + txtSearchCoupon.Text + "%' or NGUOITAO like '%" + txtSearchCoupon.Text + "%'";
            var da = new SqlDataAdapter(s, c);
            var dt = new DataTable();
            da.Fill(dt);
        }
        private void dtpPhieu_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (cboSearchCoupon.SelectedIndex == 0)
            {
                TimKiemNgay_PN();
            }
            if (cboSearchCoupon.SelectedIndex == 1)
            {
                TimKiemNgay_PX();
            }
        }
        private void dtpPhieu_DenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (cboSearchCoupon.SelectedIndex == 0)
            {
                TimKiemNgay_PN();
            }
            if (cboSearchCoupon.SelectedIndex == 1)
            {
                TimKiemNgay_PX();
            }
        }
        private void txtGiaNho_TextChanged(object sender, EventArgs e)
        {
            if(cboSearchCoupon.SelectedIndex == 0)
            {
                TimKiemGia_PN();
            }
            if (cboSearchCoupon.SelectedIndex == 1)
            {
                TimKiemGia_PX();
            }
        }

        private void txtGiaLon_TextChanged(object sender, EventArgs e)
        {
            if (cboSearchCoupon.SelectedIndex == 0)
            {
                TimKiemGia_PN();
            }
            if (cboSearchCoupon.SelectedIndex == 1)
            {
                TimKiemGia_PX();
            }
        }

        private void txtSearchCoupon_TextChanged(object sender, EventArgs e)
        {
            lblTongTien.Text = "0";
            lblTongPhieu.Text = "0";
            if (cboSearchCoupon.SelectedIndex == 0)
            {
                TimKiemPN();
                for (int i = 0; i < dgvPhieu.Rows.Count; i++)
                {
                    lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + double.Parse(dgvPhieu.Rows[i].Cells["TONGTIEN"].Value.ToString()));
                    lblTongPhieu.Text = dgvPhieu.RowCount.ToString();
                    dgvPhieu.Columns["TONGTIEN"].DefaultCellStyle.Format = "#,##0";
                }
                lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
                dgvPhieu.Columns["MANHACUNGCAP"].HeaderText = "Nhà cung cấp";
                for (int i = 0; i < dgvPhieu.Rows.Count; i++)
                {
                    dgvPhieu.Rows[i].Cells["MANHACUNGCAP"].Value = s.TenNhaCungCap(dgvPhieu.Rows[i].Cells["MANHACUNGCAP"].Value.ToString());
                }
            }
            if (cboSearchCoupon.SelectedIndex == 1)
            {
                TimKiemPX();
                for (int i = 0; i < dgvPhieu.Rows.Count; i++)
                {
                    lblTongTien.Text = Convert.ToString(double.Parse(lblTongTien.Text) + double.Parse(dgvPhieu.Rows[i].Cells["TONGTIEN"].Value.ToString()));
                    lblTongPhieu.Text = dgvPhieu.RowCount.ToString();
                    dgvPhieu.Columns["TONGTIEN"].DefaultCellStyle.Format = "#,##0";
                }
                lblTongTien.Text = double.Parse(lblTongTien.Text).ToString("#,##0");
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (cboSearchCoupon.SelectedIndex == 0)
            {
                ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
                ctpn.lblMaPhieu.Text = dgvPhieu.CurrentRow.Cells[1].Value.ToString();
                ctpn.lblThoiGianTao.Text = dgvPhieu.CurrentRow.Cells[2].Value.ToString();
                ctpn.lblNguoiTao.Text = dgvPhieu.CurrentRow.Cells[3].Value.ToString();
                ctpn.lblTongTien.Text = dgvPhieu.CurrentRow.Cells[5].Value.ToString();
                ctpn.lblNhaCungCap.Text = dgvPhieu.CurrentRow.Cells[4].Value.ToString();
                ctpn.ShowDialog();
            }
            if (cboSearchCoupon.SelectedIndex == 1)
            {
                ChiTietPhieuXuat ctpx = new ChiTietPhieuXuat();
                ctpx.lblMaPhieu.Text = dgvPhieu.CurrentRow.Cells[1].Value.ToString();
                ctpx.lblThoiGianTao.Text = dgvPhieu.CurrentRow.Cells[2].Value.ToString();
                ctpx.lblNguoiTao.Text = dgvPhieu.CurrentRow.Cells[3].Value.ToString();
                ctpx.lblTongTien.Text = dgvPhieu.CurrentRow.Cells[4].Value.ToString();
                ctpx.ShowDialog();
            }
        }
        private void btnResetProduct_Click(object sender, EventArgs e)
        {
            dgvThongKeSanPham.DataSource = s.ThongKeNhapXuat();
        }

        private void dgvThongKeTaiKhoan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvThongKeTaiKhoan.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
