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
    public partial class ChinhSua_TaiKhoan : Form
    {
        Account a = new Account();
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public ChinhSua_TaiKhoan()
        {
            InitializeComponent();
        }
        private void ChinhSua_TaiKhoan_Load(object sender, EventArgs e)
        {
            txtUsername.Text = DangNhap.username;
            txtEmail.Text = a.HienThiEmail(txtUsername.Text);
            txtTenTaiKhoan.Text = a.HienThiHovaTen(txtUsername.Text);
        }
        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text == "" || txtNewPassword.Text == "" || txtConfirmPassword.Text =="")
            {
                MessageBox.Show("Thông tin không được rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                MessageBox.Show("Nhập lại mật khẩu không trùng khớp","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            c.Open();
            string s = "select * from TAIKHOAN where TENTAIKHOAN = '" + txtUsername.Text + "' and MATKHAU = '" + txtPassword.Text + "'";
            SqlCommand cmd = new SqlCommand(s, c);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.ExecuteNonQuery();
            if (dt.Rows.Count > 0)
            {
                a.CapNhatMatKhau(txtNewPassword.Text, txtUsername.Text);
                MessageBox.Show("Cập nhật mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirmPassword.Clear();
                txtPassword.Clear();
                txtNewPassword.Clear();
                txtPassword.Focus();
            }
            else
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
