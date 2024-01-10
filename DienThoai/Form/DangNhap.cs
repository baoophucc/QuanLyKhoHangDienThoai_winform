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

namespace DienThoai
{
    public partial class DangNhap : Form
    {
        public static string username;
        Login l = new Login();
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        public DangNhap()
        {
            InitializeComponent();
        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            /*string tk, mk;
            tk = txtUsername.Text;
            mk = txtPassword.Text;
            try
            {
                string s = "Select * from TAIKHOAN where TENTAIKHOAN = '" + tk + "' and MATKHAU = '" + mk + "'"; ;
                SqlDataAdapter da = new SqlDataAdapter(s, c);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    tk = txtUsername.Text;
                    mk = txtPassword.Text;
                    QuanLy ql = new QuanLy();
                    ql.Show();

                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                c.Close();
            }*/
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (l.KiemTraDangNhap(txtUsername.Text, txtPassword.Text))
                {
                    QuanLy ql = new QuanLy();
                    ql.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        private void lblForgetPassword_Click(object sender, EventArgs e)
        {
            QuenMatKhau r = new QuenMatKhau();
            r.Show();
        }
        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.White;
        }
    }
}
