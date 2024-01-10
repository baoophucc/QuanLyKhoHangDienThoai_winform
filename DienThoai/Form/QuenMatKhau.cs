using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using DienThoai.Class;
using System.Net.Mail;
using System.Net;

namespace DienThoai
{
    public partial class QuenMatKhau : Form
    {
        ForgotPassword fp = new ForgotPassword();
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        String randomCode;
        public static String to;
        public static string email;
        public QuenMatKhau()
        {
            InitializeComponent();
        }
        private void KhoiPhucMatKhau_Load(object sender, EventArgs e)
        {
            
        }

        private void btnOTP_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Chưa nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!fp.IsEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (!fp.KiemTraEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    //Tài khoản : winform.c@gmail.com
                    //Mật khẩu : winform.c123
                    String from, pass, messageBody;
                    Random r = new Random();
                    randomCode = (r.Next(999999)).ToString();
                    MailMessage message = new MailMessage();
                    to = (txtEmail.Text).ToString();
                    from = "winform.c@gmail.com";
                    pass = "qnshbrtvdiltoppx";
                    messageBody = randomCode + " là mã xác minh tài khoản Winform CSharp (C#) của bạn";
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = messageBody;
                    message.Subject = "OTP code from Winform CSharp (C#)";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    try
                    {
                        smtp.Send(message);
                        MessageBox.Show("Mã OTP đã gửi đến email của bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void btnSuccess_Click(object sender, EventArgs e)
        {
            email = txtEmail.Text;
            if (randomCode == (txtOTP.Text).ToString())
            {
                to = txtOTP.Text;
                DoiMatKhau cp = new DoiMatKhau();
                this.Hide();
                cp.Show();
            }
            else
                MessageBox.Show("Mã OTP không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
