using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienThoai.Class
{
    internal class ChangePassword
    {
        QuanLyDienThoai dt = new QuanLyDienThoai();
        SqlDataAdapter da;
        SqlConnection c = new SqlConnection(@"Data Source=DESKTOP-8ME4HP5\SQLEXPRESS; Initial Catalog=QuanLyDienThoai; Integrated Security=True");
        static string Email;
        public static string email
        {
            get
            {
                return email;
            }
            set
            {
                Email = value;
            }
        }
        public string DoiMatKhau(string matkhau, string email)
        {
            c.Open();
            string s = "update TAIKHOAN set MATKHAU = '" + matkhau + "' where Email = '" + email + "'";
            SqlCommand cmd = new SqlCommand(s, c);
            string kq = cmd.ExecuteNonQuery().ToString();
            c.Close();
            return kq;
        }    
    }
}
