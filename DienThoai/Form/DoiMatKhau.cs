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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DienThoai
{
    public partial class DoiMatKhau : Form
    {
        ChangePassword cp = new ChangePassword();
        
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if(txtConfirmPassword.Text != txtNewPassword.Text)
                {
                    MessageBox.Show("Nhập lại mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    cp.DoiMatKhau(txtConfirmPassword.Text, txtEmail.Text);
                    MessageBox.Show("Đổi mật khẩu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    DangNhap dn = new DangNhap();
                    dn.Show();
                }    
            }    
            
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtEmail.Text = QuenMatKhau.email;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtNewPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }    
            else
            {
                txtNewPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
            }    
        }
    }
}
