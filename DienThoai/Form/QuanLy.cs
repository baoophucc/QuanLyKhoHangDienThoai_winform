using DienThoai.Class;
using DienThoai.Menu;
using DienThoai.QuanLy_Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DienThoai
{
    public partial class QuanLy : Form
    {
        Account a = new Account();
        public QuanLy()
        {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(sp);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                DangNhap dn = new DangNhap();
                dn.Show();
            }
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            lblUsername.Text = a.HienThiHovaTen(DangNhap.username);
            lblRole.Text = a.VaiTro(DangNhap.username);
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy hh:mm:ss");
            timer1.Start();
            if(DangNhap.username != "admin")
            {
                btnAccount.Hide();
                btnStatistical.Hide();
                btnImport_Ticket.Hide();
                btnExport_Ticket.Hide();
                btnExport.Location = new Point(10, 195);
                btnInventory.Location = new Point(10, 236);
            }
            btnProduct.PerformClick();
            /*btnProduct_MouseEnter(sender, e);*/
            /*btnProduct_MouseLeave(sender, e);*/
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(ncc);
        }

        private void btnStatistical_Click(object sender, EventArgs e)
        {
            ThongKe tk = new ThongKe();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(tk);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(tk);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            TonKho tk = new TonKho();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(tk);
        }

        private void btnImports_Click(object sender, EventArgs e)
        {
            NhapHang nh = new NhapHang();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(nh);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            XuatHang xh = new XuatHang();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(xh);
        }

        private void btnImport_Ticket_Click(object sender, EventArgs e)
        {
            PhieuNhap pn = new PhieuNhap();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(pn);
        }

        private void btnExport_Ticket_Click(object sender, EventArgs e)
        {
            PhieuXuat px = new PhieuXuat();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(px);
        }

        private void btnChange_Information_Click(object sender, EventArgs e)
        {
            ChinhSua_TaiKhoan edit_tk = new ChinhSua_TaiKhoan();
            edit_tk.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy HH:mm:ss");
        }

        private void btnProduct_MouseEnter(object sender, EventArgs e)
        {
            btnProduct.ForeColor = Color.Black;
        }

        private void btnProduct_MouseLeave(object sender, EventArgs e)
        {
            btnProduct.ForeColor = Color.White;
        }

        private void btnSupplier_MouseEnter(object sender, EventArgs e)
        {
            btnSupplier.ForeColor = Color.Black;
        }

        private void btnSupplier_MouseLeave(object sender, EventArgs e)
        {
            btnSupplier.ForeColor = Color.White;
        }

        private void btnImports_MouseEnter(object sender, EventArgs e)
        {
            btnImports.ForeColor = Color.Black;
        }

        private void btnImports_MouseLeave(object sender, EventArgs e)
        {
            btnImports.ForeColor = Color.White;
        }

        private void btnImport_Ticket_MouseEnter(object sender, EventArgs e)
        {
            btnImport_Ticket.ForeColor = Color.Black;
        }

        private void btnImport_Ticket_MouseLeave(object sender, EventArgs e)
        {
            btnImport_Ticket.ForeColor = Color.White;
        }

        private void btnExport_MouseEnter(object sender, EventArgs e)
        {
            btnExport.ForeColor = Color.Black;
        }

        private void btnExport_MouseLeave(object sender, EventArgs e)
        {
            btnExport.ForeColor = Color.White;
        }

        private void btnExport_Ticket_MouseLeave(object sender, EventArgs e)
        {
            btnExport_Ticket.ForeColor = Color.White;
        }

        private void btnExport_Ticket_MouseEnter(object sender, EventArgs e)
        {
            btnExport_Ticket.ForeColor = Color.Black;
        }

        private void btnInventory_MouseLeave(object sender, EventArgs e)
        {
            btnInventory.ForeColor = Color.White;
        }

        private void btnInventory_MouseEnter(object sender, EventArgs e)
        {
            btnInventory.ForeColor = Color.Black;
        }

        private void btnAccount_MouseEnter(object sender, EventArgs e)
        {
            btnAccount.ForeColor = Color.Black;
        }

        private void btnAccount_MouseLeave(object sender, EventArgs e)
        {
            btnAccount.ForeColor = Color.White;
        }

        private void btnStatistical_MouseEnter(object sender, EventArgs e)
        {
            btnStatistical.ForeColor = Color.Black;
        }

        private void btnStatistical_MouseLeave(object sender, EventArgs e)
        {
            btnStatistical.ForeColor = Color.White;
        }

        private void btnChange_Information_MouseEnter(object sender, EventArgs e)
        {
            btnChange_Information.ForeColor = Color.Blue;
        }

        private void btnChange_Information_MouseLeave(object sender, EventArgs e)
        {
            btnChange_Information.ForeColor = Color.White;
        }

        private void btnLogout_MouseEnter(object sender, EventArgs e)
        {
            btnLogout.ForeColor = Color.Red;
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.ForeColor = Color.White;
        }
    }
}
